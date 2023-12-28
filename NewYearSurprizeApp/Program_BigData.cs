namespace NewYearSurpriseApp
{
    internal partial class Program
    {
        private static Dictionary<string, string> CreateSymbols()
        {
            return new Dictionary<string, string>()
            {
                #region Numbers 0 - 9
            { "0", """
                |^|
                (*)
                |_|
                """ },
            { "1", """
                 /|
                / |
                  |
                """ },
            { "2", """
                /^\
                 _|
                |__
                """ },
            { "3", """
                -<|
                 -|
                -<|
                """ },
            { "4", """
                 /|
                /_|
                  |
                """ },
            { "5", """
                *--
                |__
                __|
                """ },
            { "6", """
                 /
                / 
                (#)
                """ },
            { "7", """
                --+
                 /
                /
                """ },
            { "8", """
                \_/
                 x
                /_\
                """ },
            { "9", """
                (*)
                 /
                /
                """ },
            #endregion

                { " ", """
                   
                   
                   
                """ }
            };
        }
    }
}
