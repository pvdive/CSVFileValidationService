using System;
using System.Text.RegularExpressions;

namespace FormatValidator
{
    /// <summary>
    /// Seperates a string in to multiple columns based on seperator strings.
    /// </summary>
    internal class ColumnSplitter
    {
        public static string[] Split(string input, string seperator)
        {
            return Regex.Split(input,
                $"{EscapeSeperator(seperator)}(?=([^\"]*\"[^\"]*\")*[^\"]*$)",
                RegexOptions.ExplicitCapture
                );
        }
      
        private static string EscapeSeperator(string seperator)
        {
            return seperator
                .Replace(@"\", @"\\")
                .Replace("^", @"\^")
                .Replace("$", @"\$")
                .Replace(".", @"\.")
                .Replace("|", @"\|")
                .Replace("?", @"\?")
                .Replace("*", @"\*")
                .Replace("+", @"\+")
                .Replace("{", @"\{")
                .Replace("[", @"\[")
                .Replace("(", @"\(")
                .Replace(")", @"\)");
        }
    }
}
