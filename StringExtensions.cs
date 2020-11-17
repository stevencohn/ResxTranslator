//************************************************************************************************
// Copyright © 2020 Steven M Cohn.  All rights reserved.
//************************************************************************************************

namespace ResxTranslator
{
	using System.Text;


	/// <summary>
	/// This is a customization of the System.Security.SecurityElement.Escape method
	/// that ignores apostrophies (&apos;) and double-quotes (&quot;)
	/// </summary>
	internal static class StringExtensions
	{
		private static readonly string[] EscapePairs = new string[]
		{
            // these must be all once character escape sequences or a new escaping algorithm is needed
            "<", "&lt;",
			">", "&gt;",
			"&", "&amp;"
		};

		private static readonly char[] EscapeChars = new char[] { '<', '>', '&' };


		public static string XmlEscape(this string str)
		{
			if (str == null)
				return null;

			StringBuilder sb = null;

			int strLen = str.Length;
			int index; // Pointer into the string that indicates the location of the current '&' character
			int newIndex = 0; // Pointer into the string that indicates the start index of the "remaining" string (that still needs to be processed).

			do
			{
				index = str.IndexOfAny(EscapeChars, newIndex);

				if (index == -1)
				{
					if (sb == null)
						return str;
					else
					{
						sb.Append(str, newIndex, strLen - newIndex);
						return sb.ToString();
					}
				}
				else
				{
					if (sb == null)
						sb = new StringBuilder();

					sb.Append(str, newIndex, index - newIndex);
					sb.Append(GetEscapeSequence(str[index]));

					newIndex = (index + 1);
				}
			}
			while (true);

			// no normal exit is possible
		}


		private static string GetEscapeSequence(char c)
		{
			int iMax = EscapePairs.Length;

			for (int i = 0; i < iMax; i += 2)
			{
				string strEscSeq = EscapePairs[i];
				string strEscValue = EscapePairs[i + 1];

				if (strEscSeq[0] == c)
					return strEscValue;
			}

			return c.ToString();
		}
	}
}