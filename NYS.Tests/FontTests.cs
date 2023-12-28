using NewYearSurpriseApp;

namespace NYS.Tests
{
    public class FontTests
    {
        private readonly Dictionary<string, string> _symbols = new()
        {
            { "A", "a" },
            { "B", "b\r\r" },
            { "C", "\rc\r" },
        };
        private readonly Dictionary<string, string> _multilineSymbols = new()
        {
            { "A", "A\nA" },
            { "B", "B\n\rB\n" },
            { "C", "C\nC\rcc\n\n\r!" },
        };

        [Test]
        public void GetSymbolTest()
            => GetSymbolTest(_symbols, _symbols.Values);

        [Test]
        public void GetMultilineSymbolTest()
            => GetSymbolTest(_multilineSymbols, _multilineSymbols.Values);

        private void GetSymbolTest(Dictionary<string, string> symbols, IEnumerable<string> expectedSymbols)
        {
            Font font = new Font(symbols);

            var actualSymbols = new List<string>();

            foreach (var key in symbols.Keys)
            {
                actualSymbols.Add(font.GetSymbol(key));
            }

            Assert.That(actualSymbols, Is.EqualTo(expectedSymbols));
        }

        [Test]
        public void GetTextInOneRowTest()
        {
            Font font = new Font(_symbols);

            string text = "ABC";

            string expected = "abc\r";
            string actual = font.GetText(text);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetTextInOneRowMultilineStringsTest()
        {
            Font font = new Font(_multilineSymbols);

            string text = "ABC";

            string expected = "ABC\r\nABC\rcc\r";
            string actual = font.GetText(text);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}