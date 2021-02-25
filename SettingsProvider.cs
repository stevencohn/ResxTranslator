//************************************************************************************************
// Copyright © 2021 Steven M Cohn.  All rights reserved.
//************************************************************************************************

namespace ResxTranslator
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Xml.Linq;


	/// <summary>
	/// Loads, save, and manages user settings
	/// </summary>
	internal class SettingsProvider
	{
		private readonly string path;
		private readonly XElement root;


		/// <summary>
		/// Initialize a new provider.
		/// </summary>
		public SettingsProvider()
		{
			var attribute = Assembly.GetExecutingAssembly()
				.GetCustomAttributes<AssemblyProductAttribute>()
				.FirstOrDefault();

			var appData = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				attribute != null ? attribute.Product : "RoboTranslator");

			path = Path.Combine(appData, "Settings.xml");

			if (File.Exists(path))
			{
				try
				{
					root = XElement.Load(path);
				}
				catch
				{
					//
				}
			}

			if (root == null)
			{
				// file not found so initialize with defaults
				root = new XElement("settings");
			}
		}


		public string Get(string name)
		{
			var element = root.Elements(name).FirstOrDefault();
			if (element != null)
			{
				return element.Value;
			}

			return null;
		}


		public void Set(string name, string value)
		{
			var element = root.Elements(name).FirstOrDefault();
			if (element == null)
			{
				root.Add(new XElement(name, value));
			}
			else
			{
				element.Value = value;
			}
		}


		public void Save()
		{
			var dir = Path.GetDirectoryName(path);
			if (!Directory.Exists(dir))
			{
				try
				{
					Directory.CreateDirectory(dir);
				}
				catch
				{
					//
				}
			}

			root.Save(path, SaveOptions.None);
		}
	}
}
