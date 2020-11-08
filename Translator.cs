//************************************************************************************************
// Copyright © 2020 Steven M Cohn.  All rights reserved.
//************************************************************************************************

#pragma warning disable S125   // commented out code
#pragma warning disable S1075  // hardcoded URLs or paths
#pragma warning disable CA1031 // non-specific catch

namespace ResxTranslator
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net.Http;
	using System.Text.Json;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Web;
	using System.Xml.Linq;


	internal enum Status
	{
		OK,
		Working,
		Error
	}


	internal class Translator
	{
		public static readonly List<string> Codes = new List<string>
		{
			#region Code
			"af",		// Afrikaans
			"sq",		// Albanian
			"ar",		// Arabic
			"hy",		// Armenian
			"az",		// Azerbaijani
			"eu",		// Basque
			"be",		// Belarusian
			"bn",		// Bengali
			"bg",		// Bulgarian
			"ca",		// Catalan
			"zh-CN",	// Chinese (Simplified)
			"zh-TW",	// Chinese (Traditional)
			"hr",		// Croatian
			"cs",		// Czech
			"da",		// Danish
			"nl",		// Dutch
			"en",		// English
			"eo",		// Esperanto
			"et",		// Estonian
			"tl",		// Filipino
			"fi",		// Finnish
			"fr",		// French
			"gl",		// Galician
			"ka",		// Georgian
			"de",		// German
			"el",		// Greek
			"gu",		// Gujarati
			"ht",		// Haitian Creole
			"iw",		// Hebrew
			"hi",		// Hindi
			"hu",		// Hungarian
			"is",		// Icelandic
			"id",		// Indonesian
			"ga",		// Irish
			"it",		// Italian
			"ja",		// Japanese
			"kn",		// Kannada
			"km",		// Khmer
			"ko",		// Korean
			"lo",		// Lao
			"la",		// Latin
			"lv",		// Latvian
			"lt",		// Lithuanian
			"mk",		// Macedonian
			"ms",		// Malay
			"mt",		// Maltese
			"no",		// Norwegian
			"fa",		// Persian
			"pl",		// Polish
			"pt",		// Portuguese
			"ro",		// Romanian
			"ru",		// Russian
			"sr",		// Serbian
			"sk",		// Slovak
			"sl",		// Slovenian
			"es",		// Spanish
			"sw",		// Swahili
			"sv",		// Swedish
			"ta",		// Tamil
			"te",		// Telugu
			"th",		// Thai
			"tr",		// Turkish
			"uk",		// Ukrainian
			"ur",		// Urdu
			"vi",		// Vietnamese
			"cy",		// Welsh
			"yi"		// Yiddis
			#endregion Code
		};

		private const string GoogleUri =
			"https://translate.googleapis.com/translate_a/single?" +
			"client=gtx&sl={0}&tl={1}&hl=en&dt=t&dt=bd&dj=1&source=icon&tk={2}&q={3}";

		private const string ApiToken = "467103.467103";

		private HttpClient client = null;


		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		/// <param name="strings"></param>
		/// <param name="seconds"></param>
		/// <returns></returns>
		public static bool Estimate(string path, out int strings, int delayInSeconds, out int seconds)
		{
			try
			{
				var root = XElement.Load(path);

				var data = CollectData(root);

				strings = data.Count;
				seconds = data.Count * delayInSeconds;

				return true;
			}
			catch
			{
				strings = seconds = 0;
				return false;
			}
		}


		public static List<XElement> CollectData(XElement root)
		{
			var xs = root.GetNamespaceOfPrefix("xml");

			// this should filter out all non-string entries and leave only strings
			return root.Elements("data")
				.Where(e => e.Attribute("name")?.Value.StartsWith(">>") != true &&
							e.Attribute("type") == null &&
							e.Attribute(xs + "space") != null)
				.ToList();
		}


		/// <summary>
		/// Filters the data list by keeping only items that don't exist in the
		/// specified resx file. This find all new items that need to be translated
		/// </summary>
		/// <param name="data"></param>
		/// <param name="path"></param>
		/// <returns></returns>
		public static List<XElement> FilterData(List<XElement> data, string path)
		{
			try
			{
				var root = XElement.Load(path);

				return data.Where(d =>
					!root.Elements("data")
						.Any(e => e.Attribute("name")?.Value == d.Attribute("name").Value))
					.ToList();
			}
			catch
			{
				//
			}

			return data;
		}


		// = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
		// One...

		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <param name="fromCode"></param>
		/// <param name="toCode"></param>
		/// <returns></returns>
		public async Task<string> Translate(string text, string fromCode, string toCode)
		{
			if (client == null)
			{
				client = new HttpClient
				{
					Timeout = new TimeSpan(0, 0, 1000 * 20)
				};
			}

			var response = await client.GetAsync(
				string.Format(GoogleUri, fromCode, toCode, ApiToken, HttpUtility.UrlEncode(text)));

			if (response.IsSuccessStatusCode)
			{
				ParseJsonResult(await response.Content.ReadAsStringAsync(), out var result);
				return result;
			}

			var status = (int)response.StatusCode;
			throw new HttpException(status, $"HTTP status {status}");
		}


		private void ParseJsonResult(string json, out string result)
		{
			string text;

			try
			{
				var doc = JsonDocument.Parse(json);

				text = doc.RootElement
					.GetProperty("sentences")[0]
					.GetProperty("trans")
					.GetRawText();

				if (text[0] == '"' && text[text.Length - 1] == '"')
				{
					text = text.Substring(1, text.Length - 2);
				}

				// result = doc.RootElement.ToString();
				result = text;
			}
			catch
			{
				result = null;
			}
		}


		// = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
		// Resx...

		/*
		 * 
		 * NOTE, tried to batch up strings, up to 1K of chars, delimited by ~~~~
		 * but the free Google Translator doesn't handle most languages correctly
		 * so this is temporarily disabled by hard-codng the batch size to 1.
		 * e.g. given a batch with 10 strings, Google may only return 7 of them
		 * and it's unclear which 7 it will return?
		 * 
		 */

		public delegate void StatusCallback(Status status, int count, string message);


		/// <summary>
		/// 
		/// </summary>
		/// <param name="root"></param>
		/// <param name="fromCode"></param>
		/// <param name="toCode"></param>
		/// <param name="logger"></param>
		/// <returns></returns>
		public async Task<bool> TranslateResx(
			List<XElement> data, string fromCode, string toCode, int delayInSecs,
			CancellationTokenSource cancellation,
			StatusCallback logger)
		{
			var delay = delayInSecs * 1000;

			int index = 0;
			int count = 1;
			for (; index < data.Count && !cancellation.IsCancellationRequested; index++, count++)
			{
				var value = data[index].Element("value").Value;

				if (value.Length == 0)
				{
					continue;
				}

				logger(Status.Working, index,
					$"Translating {data[index].Attribute("name").Value} ({count}/{data.Count})");

				var result = await TranslateWithRetry(
					value, fromCode, toCode, cancellation, logger);

				if (!string.IsNullOrEmpty(result))
				{
					logger(Status.OK, count, $" \u2192 '{value}' to '{result}'");
					data[index].Element("value").Value = result;
				}
				else
				{
					logger(Status.Error, 0, "error");
				}

				await Task.Delay(delay);
			}

			logger(Status.OK, count, $"Translated {count}/{data.Count} strings to {toCode}");

			return index == data.Count;
		}


		private async Task<string> TranslateWithRetry(
			string batch, string fromCode, string toCode,
			CancellationTokenSource cancellation,
			StatusCallback logger)
		{
			var retry = 0;
			var minutes = 5;

			// the reset window seems to be less than 24 hours but not sure how long...

			while (retry < 24 * 3) // 1 day split up into 20 minute retries
			{
				try
				{
					var result = await Translate(batch.ToString(), fromCode, toCode);
					return result;
				}
				catch (HttpException exc)
				{
					logger(Status.Error, 0,
						$"Retry {retry}/23, waiting {minutes} minutes, " +
						$"starting at {DateTime.Now}; {exc.Message}");

					retry++;

					await Task.Delay(new TimeSpan(0, minutes, 0), cancellation.Token);

					if (minutes == 5)
					{
						minutes = 10;
					}
					else if (minutes < 30)
					{
						minutes += 10;
					}
				}
			}

			return null;
		}
	}
}
