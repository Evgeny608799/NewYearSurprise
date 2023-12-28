namespace NewYearSurpriseApp
{
    internal partial class Program
    {
        private static readonly int _newYear = DateTime.Now.Year + 1;
        private static readonly DateTime _newYearTime = new DateTime(_newYear, 1, 1);
        private static readonly Font _numbersFont = new Font(CreateSymbols());
        private static Timer _timer = null!;

        static Program() { }

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                PrintLoadingAnim();
                Console.WriteLine(_numbersFont.GetText(new Random().Next(1, 1000).ToString()));

                Thread.Sleep(300);
                Console.Clear();
            }

            _timer = new Timer(async (o) => await UpdateTimerAsync(), null, 0, 1000);

            Console.ReadLine();
        }

        private static void PrintLoadingAnim()
        {
            Console.Write("INITAILIZATION");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }

        private static async Task UpdateTimerAsync()
        {
            Console.Clear();
            
            DateTime now = DateTime.Now;

            if (now >= _newYearTime)
            {
                await _timer.DisposeAsync();
                OnTimerEnded();
                return;
            }

            TimeSpan remainingTime = _newYearTime - now;

            Console.WriteLine($"Left until the new year <{_newYear}> (Something will happen):\n");
            try
            {
                PrintTimer(remainingTime);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка шрифта! {ex.Message}");
            }
        }

        private static void OnTimerEnded()
        {
            Console.WriteLine($"С НОВЫМ ГОДОМ\n{_numbersFont.GetText(_newYear.ToString())}");
        }

        private static void PrintTimer(TimeSpan remainingTime)
        {
            if (remainingTime.Days > 0)
            {
                Console.WriteLine(_numbersFont.GetText(remainingTime.Days.ToString()));
                Console.WriteLine("DAYS\n");
            }

            if (remainingTime.Hours > 0)
            {
                Console.WriteLine(_numbersFont.GetText(remainingTime.Hours.ToString()));
                Console.WriteLine("HOURS\n");
            }

            if (remainingTime.Minutes > 0)
            {
                Console.WriteLine(_numbersFont.GetText(remainingTime.Minutes.ToString()));
                Console.WriteLine("MINUTES\n");
            }

            if (remainingTime.Seconds > 0)
            {
                Console.WriteLine(_numbersFont.GetText(remainingTime.Seconds.ToString()));
                Console.WriteLine("SECONDS\n");
            }
        }
    }
}
