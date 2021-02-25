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
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Net.Http;
	using System.Text;
	using System.Text.Json;
	using System.Text.RegularExpressions;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Web;
	using System.Xml.Linq;


	internal enum Status
	{
		OK,
		Working,
		Error,
		Message
	}


	internal class Translator
	{
		public static readonly List<string> Codes = new List<string>
		{
			#region Code
			"af",		// Afrikaans
			"sq",		// Albanian
			"am",		// Amharic
			"ar",		// Arabic
			"hy",		// Armenian
			"az",		// Azerbaijani
			"eu",		// Basque
			"be",		// Belarusian
			"bn",		// Bengali
			"bs",		// Bosnian
			"bg",		// Bulgarian
			"ca",		// Catalan
			"ceb",		// Cebuano
			"ny",		// Chichewa - (n/a)
			"zh-CN",	// Chinese (Simplified)
			"zh-TW",	// Chinese (Traditional)
			"co",		// Corsican
			"hr",		// Croatian
			"cs",		// Czech
			"da",		// Danish
			"nl",		// Dutch
			"en",		// English
			"eo",		// Esperanto
			"et",		// Estonian
			"tl",		// Filipino = fil-PH
			"fi",		// Finnish
			"fr",		// French
			"fy",		// Frisian
			"gl",		// Galician
			"ka",		// Georgian
			"de",		// German
			"el",		// Greek
			"gu",		// Gujarati
			"ha",		// Hausa
			"ht",		// Haitian Creole... not supported by Windows?
			"haw",		// Hawaiian
			"iw",		// Hebrew = he-IL
			"hi",		// Hindi
			"hmn",		// Hmong - (n/a)
			"hu",		// Hungarian
			"is",		// Icelandic
			"ig",		// Igbo
			"id",		// Indonesian
			"ga",		// Irish
			"it",		// Italian
			"ja",		// Japanese
			"jw",		// Javanese - (n/a)
			"kn",		// Kannada
			"kk",		// Kazakh
			"km",		// Khmer
			"rw",		// Kinyarwanda
			"ko",		// Korean
			"ku",		// Kurdish (Kurmanji)
			"ky",		// Kyrgyz
			"lo",		// Lao
			"la",		// Latin
			"lv",		// Latvian
			"lt",		// Lithuanian
			"lb",		// Luxembourgish
			"mk",		// Macedonian
			"mg",		// Malagasy
			"ms",		// Malay
			"ml",		// Malayalam
			"mt",		// Maltese
			"mi",		// Maori
			"mr",		// Marathi
			"mn",		// Mongolian
			"my",		// Myanmar (Burmese)
			"ne",		// Nepali
			"no",		// Norwegian
			"or",		// Odia (Oriya)
			"ps",		// Pashto
			"fa",		// Persian
			"pl",		// Polish
			"pt",		// Portuguese
			"pa",		// Punjabi
			"ro",		// Romanian
			"ru",		// Russian
			"sm",		// Samoan - (n/a)
			"sr",		// Serbian
			"gd",		// Scots Gaelic
			"st",		// Sesotho
			"sn",		// Shona
			"sd",		// Sindhi
			"si",		// Sinhala
			"sk",		// Slovak
			"sl",		// Slovenian
			"so",		// Somali
			"es",		// Spanish
			"su",		// Sundanese - (n/a)
			"sw",		// Swahili
			"sv",		// Swedish
			"tg",		// Tajik
			"ta",		// Tamil
			"tt",		// Tatar
			"te",		// Telugu
			"th",		// Thai
			"tr",		// Turkish
			"tk",		// Turkmen
			"uk",		// Ukrainian
			"ur",		// Urdu
			"ug",		// Uyghur
			"uz",		// Uzbek
			"vi",		// Vietnamese
			"cy",		// Welsh
			"xh",		// Xhosa
			"yi",		// Yiddis
			"yo",		// Yoruba
			"zu"		// Zulu
			#endregion Code
		};

		private static readonly Dictionary<string, string> FileCodeMap = new Dictionary<string, string>
		{
			{ "tl", "fil-PH" },
			{ "iw", "he-IL" }
		};

		private static readonly Dictionary<string, string> FileNameMap = new Dictionary<string, string>
		{
			{ "ny", "Chichewa" },
			{ "hmn", "Hmong" },
			{ "ht", "Haitian Creole" },
			{ "jw", "Javanese" },
			{ "sm", "Samoan" },
			{ "su", "Sudanese" }
		};

		private const string GoogleUri =
			"https://translate.googleapis.com/translate_a/single?" +
			"client=gtx&sl={0}&tl={1}&hl=en&dt=t&dt=bd&dj=1&source=icon&tk={2}&q={3}";

		private const string ApiToken = "467103.467103";
		private const string NL = "\n";

		private const string InflationPattern = @"([^\s](?:[^\w\d\s\p{L}]))|((?:[^\w\d\s\p{L}])[^\s])";

		private readonly Regex inflation = new Regex(InflationPattern);
		private HttpClient client = null;


		// = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
		// Languages...

		/// <summary>
		/// Gets the Windows-specific culture name, e.g. en -> en-US, for naming 
		/// satellite assemblies
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public static string GetCultureName(string code)
		{
			return FileCodeMap.ContainsKey(code)
				? FileCodeMap[code]
				: CultureInfo.GetCultureInfo(code).TextInfo.CultureName;
		}


		/// <summary>
		/// Gets the display name of the language for UI controls
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public static string GetDisplayName(string code)
		{
			if (FileCodeMap.ContainsKey(code))
			{
				code = FileCodeMap[code];
			}

			return FileNameMap.ContainsKey(code)
				? FileNameMap[code]
				: CultureInfo.GetCultureInfo(code).DisplayName;
		}


		// = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
		// Data Management...

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
			/*
			  <data name="DemoString" xml:space="preserve">
				<value>Foobar</value>
				<comment>NO</comment>
			  </data>
			*/
			var xs = root.GetNamespaceOfPrefix("xml");

			// this should filter out all non-string entries and leave only strings
			return root.Elements("data")
				.Where(e => e.Attribute(xs + "space") != null &&
							e.Attribute("type") == null &&
							e.Attribute("name")?.Value.StartsWith(">>") != true &&
							// SKIP is a special flag indicating this entry should not be translated
							e.Elements("comment").FirstOrDefault()?.Value.Contains("SKIP") != true)
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
					// keep all edited entries
					d.Element("comment")?.Value.Contains("EDIT") == true ||
					// keep only entries that don't exist in target
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
		// Inflation test...

		public bool Inflated(string original, string translation)
		{
			var oi = inflation.Matches(original).Count;
			var ti = inflation.Matches(translation).Count;
			return oi != ti;
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
		public async Task<string> Translate(
			string text, string fromCode, string toCode, CancellationTokenSource cancellation)
		{
			if (client == null)
			{
				client = new HttpClient
				{
					Timeout = new TimeSpan(0, 0, 1000 * 20)
				};
			}

			var response = await client.GetAsync(
				string.Format(GoogleUri, fromCode, toCode, ApiToken, HttpUtility.UrlEncode(text)),
				cancellation.Token);

			if (response.IsSuccessStatusCode)
			{
				ParseJsonResult(await response.Content.ReadAsStringAsync(), out var result);
				return result;
			}

			var status = (int)response.StatusCode;
			throw new HttpException(status, $"HTTP status {status}");
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="json"></param>
		/// <param name="result"></param>
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
					// escape Unicode \u0000 escape sequences to store in XML [<>&'"]
					text = Regex.Unescape(text.Substring(1, text.Length - 2)).XmlEscape();
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
		 * NOTE, tried to batch up strings, up to 1K of chars, with a delimiter,
		 * but the free Google Translator doesn't handle most languages correctly;
		 * e.g. given a batch with 10 strings, Google may only return 7 of them
		 * and it's unclear which 7 it will return?
		 * 
		 */

		public delegate void StatusCallback(string message, Color? color = null, bool increment = false);


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

				var name = data[index].Element("comment")?.Value.Contains("EDIT") == true
					? $"{data[index].Attribute("name").Value} (EDITED)"
					: data[index].Attribute("name").Value;

				logger($"{count}/{data.Count}: {name}", increment: true);

				var builder = new StringBuilder();

				// handle values with multiple lines (comboboxes)
				var parts = value.Split('\n');
				for (int i = 0; i < parts.Length && !cancellation.IsCancellationRequested; i++)
				{
					var result = await TranslateWithRetry(
						parts[i], fromCode, toCode, cancellation, logger);

					if (!string.IsNullOrEmpty(result) && !cancellation.IsCancellationRequested)
					{
						builder.Append(result);

						if (i < parts.Length - 1)
							builder.Append(NL);
					}
				}

				if (builder.Length > 0)
				{
					var result = builder.ToString();
					data[index].Element("value").Value = result;

					// 2192 is right-arrow
					logger($" \u2192 '{value}' to '{result}'" + NL);

					if (Inflated(value, result))
					{
						logger("*** possible inflation detected ***" + NL, Color.Maroon);
					}
				}
				else
				{
					logger("unknown error" + NL, Color.Red);
				}

				if (index < data.Count - 1)
				{
					await Task.Delay(delay);
				}
			}

			return index == data.Count;
		}


		private async Task<string> TranslateWithRetry(
			string text, string fromCode, string toCode,
			CancellationTokenSource cancellation, StatusCallback logger)
		{
			var retry = 0;
			var minutes = 5;

			// the reset window seems to be less than 24 hours but not sure how long...

			while (retry < 24 * 3) // 1 day split up into 20 minute retries
			{
				try
				{
					var result = await Translate(text, fromCode, toCode, cancellation);
					return result;
				}
				catch (HttpException exc)
				{
					logger(
						$"Retry {retry}/23, waiting {minutes} minutes, " +
						$"starting at {DateTime.Now}; {exc.Message}" + NL,
						Color.Red);

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


		/// <summary>
		/// Remove the EDIT markers from the source file after we're done applying
		/// the changes to all output files
		/// </summary>
		/// <param name="path"></param>
		public static int ClearMarkers(string path)
		{
			var root = XElement.Load(path);
			var comments = root.Elements("data").Elements("comment")
				.Where(e => e.Value.Contains("EDIT"))
				.ToList();

			if (comments.Count > 0)
			{
				foreach (var comment in comments)
				{
					comment.Value = Regex.Replace(comment.Value, @"\s*EDIT\s*", string.Empty);
				}

				root.Save(path);
			}

			return comments.Count;
		}
	}
}
