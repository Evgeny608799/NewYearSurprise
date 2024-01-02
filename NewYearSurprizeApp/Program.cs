namespace NewYearSurpriseApp
{
    internal partial class Program
    {
        private static readonly int NewYear = DateTime.Now.Year + 1;
        private static readonly DateTime NewYearTime = new (NewYear, 1, 1);
        private static readonly Font NumbersFont = new (CreateSymbols());
        private static Timer _timer = null!;

        static Program() { }

        private static void Main()
        {
            for (var i = 0; i < 10; i++)
            {
                PrintLoadingAnim();
                Console.WriteLine(NumbersFont.GetText(new Random().Next(1, 1000).ToString()));

                Thread.Sleep(300);
                Console.Clear();
            }

            _timer = new Timer(async (o) => await UpdateTimerAsync(), null, 0, 1000);

            Console.ReadLine();
        }

        private static void PrintLoadingAnim()
        {
            Console.Write("INITIALIZATION");
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
            
            var now = DateTime.Now;

            if (now >= NewYearTime)
            {
                await _timer.DisposeAsync();
                OnTimerEnded();
                return;
            }

            var remainingTime = NewYearTime - now;

            Console.WriteLine($"Left until the new year <{NewYear}> (Something will happen):\n");
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
            Console.WriteLine($"С НОВЫМ ГОДОМ\n{NumbersFont.GetText(NewYear.ToString())}");
        }

        private static void PrintTimer(TimeSpan remainingTime)
        {
            if (remainingTime.Days > 0)
            {
                Console.WriteLine(NumbersFont.GetText(remainingTime.Days.ToString()));
                Console.WriteLine("DAYS\n");
            }

            if (remainingTime.Hours > 0)
            {
                Console.WriteLine(NumbersFont.GetText(remainingTime.Hours.ToString()));
                Console.WriteLine("HOURS\n");
            }

            if (remainingTime.Minutes > 0)
            {
                Console.WriteLine(NumbersFont.GetText(remainingTime.Minutes.ToString()));
                Console.WriteLine("MINUTES\n");
            }

            if (remainingTime.Seconds > 0)
            {
                Console.WriteLine(NumbersFont.GetText(remainingTime.Seconds.ToString()));
                Console.WriteLine("SECONDS\n");
            }
        }
    }
}
