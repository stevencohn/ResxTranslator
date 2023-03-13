//************************************************************************************************
// Copyright © 2020 Steven M Cohn.  All rights reserved.
//************************************************************************************************

namespace ResxTranslator.Panels
{
	using System.Windows.Forms;


	internal class LanguageComboBox : ComboBox
	{
		public LanguageComboBox()
		{
			PopulateLanguages();
		}


		private void PopulateLanguages()
		{
			foreach (var code in Translator.Codes)
			{
				Items.Add(Translator.GetDisplayName(code));
			}
		}
	}
}
