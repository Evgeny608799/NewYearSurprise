using System.Text;

namespace NewYearSurpriseApp
{
    internal class Font
    {
        /// <summary>
        /// The dictionary of fonts symbols
        /// </summary>
        private readonly Dictionary<string, string> _symbols;

        /// <summary>
        /// Use the empty symbols dictionary
        /// </summary>
        internal Font() : this([]) { }

        /// <summary>
        /// Create a font by dictionary of symbols
        /// </summary>
        /// <param name="symbols">Dictionary of symbols</param>
        internal Font(Dictionary<string, string> symbols)
        {
            _symbols = symbols;
        }


        /// <summary>
        /// Get symbol by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns a single symbol</returns>
        /// <exception cref="ArgumentException">Occurs when an attempt to get non-existent symbol</exception>
        public string GetSymbol(string name)
        {
            if (!_symbols.ContainsKey(name)) 
                throw new ArgumentException($"Symbol {name} dont contain in this font", nameof(name));

            return _symbols[name];
        }


        /// <summary>
        /// Get multiline text in one row
        /// </summary>
        /// <param name="text">The text that will be converted as the symbols of fonts</param>
        /// <returns>Converted text as the symbols of fonts</returns>
        public string GetText(string text)
        {
            var stringBuilder = new StringBuilder();

            foreach (var c in text)
            {
                var symbol = GetSymbol(c.ToString());

                if (stringBuilder.ToString() != "")
                {
                    var temp = stringBuilder.ToString();
                    stringBuilder.Remove(stringBuilder.Length - temp.Length, temp.Length).Append(ConcatMultiple(temp, symbol));
                }
                else
                {
                    stringBuilder.Append(symbol);
                }
            }

            return stringBuilder.ToString();
        }


        /// <summary>
        /// Concat multiline symbols in one row
        /// </summary>
        /// <param name="left">Text in left part</param>
        /// <param name="right">Text in right part</param>
        /// <returns>United symbols in one row</returns>
        private string ConcatMultiple(string left, string right)
        {
            var leftLines = ExtractLines(left);
            var rightLines = ExtractLines(right);

            var consolidatedLines = leftLines.Zip(rightLines);

            var sb = new StringBuilder();

            foreach(var (first, second) in consolidatedLines)
            {
                sb.AppendLine(first + second);
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        /// <summary>
        /// Split string as lines
        /// </summary>
        /// <param name="line">The string that will be split as lines</param>
        /// <returns>Lines of string</returns>
        private IEnumerable<string> ExtractLines(string line)
            => line.Split('\n').Select(x => x.Trim('\r'));
    }
}
