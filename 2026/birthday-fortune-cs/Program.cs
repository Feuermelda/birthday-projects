

internal class Program
{
    private static void Main(string[] args)
    {
        int check = BirthdayChecker();
        if (check == 0)
        {
            Presents();
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Thread.Sleep(1000);
            Fortune();
        }
    }

    private static int BirthdayChecker()
    {
        DateTime bdaydt;
        bool correct = true;
        string bday;

        do
        {
            Console.WriteLine("Please enter your birthday (dd.mm.yyyy):");
            bday = Console.ReadLine();

            try
            {
                bdaydt = DateTime.Parse(bday);
                correct = true;
            }
            catch (Exception e)
            {
                correct = false;
            }

            if (!correct)
            {
                Console.WriteLine("Please enter a valid date (dd.mm.yyyy).\n");
            }

        } while (!correct);

        bdaydt = DateTime.Parse(bday);
        DateTime today = DateTime.Today;
        DateTime bdaythisyear = today; // will be overwritten but otherwise VS complains

        if (bdaydt.Day == 29 && bdaydt.Month == 2)
        {
            bool leap = DateTime.IsLeapYear(today.Year);

            if(!leap) 
            {
                bdaythisyear = new DateTime(today.Year + today.Year % 4, bdaydt.Month, bdaydt.Day); // equals next bday
            }
        } else
        {
            bdaythisyear = new DateTime(today.Year, bdaydt.Month, bdaydt.Day);
        }
            
        int diff = bdaythisyear.CompareTo(today);


        if (diff > 0)
        {
            // birthday still in the future
            TimeSpan daysleft = bdaythisyear.Subtract(today);
            Console.WriteLine($"Your birthday this year is in {daysleft.Days} days.");
        } else if (diff < 0)
        {
            // birthday already passed
            TimeSpan dayspassed = today.Subtract(bdaythisyear);
            DateTime nextbday;

            if (bdaydt.Day == 29 && bdaydt.Month == 2)
            {
                nextbday = new DateTime(today.Year + 4, bdaydt.Month, bdaydt.Day);
            } 
            else
            {
                nextbday = new DateTime(today.Year + today.Year % 4, bdaydt.Month, bdaydt.Day);
            }
                
            TimeSpan daysbetween = nextbday.Subtract(today);
            Console.WriteLine($"Your birthday this year was {dayspassed.Days} days ago.\n" +
                $"Your next birthday is in {daysbetween.Days} days.");
            
        } else
        {
            // birthday is today
            Console.WriteLine("Today is your birthday.\nHappy Birthday!!!");
        }

        return diff;
    }

    private static void Presents()
    {
        Console.WriteLine("\nGathering received presents...\n");
        Thread.Sleep(3000);

        List<string> giftpool = new List<string> 
        {
            "Plushie",
            "Candle",
            "Flowers",
            "Retro game",
            "Tea set",
            "Vinyl",
            "Book",
            "Money",
            "LEGO",
            "Perfume",
            "Cigarettes",
            "Vacation",
            "Clothes",
            "Vouchers",
            "Candy"
        };

        Random rnd = new Random();
        int presentcount = rnd.Next(1, 16);
        Console.WriteLine($"You have received {presentcount} presents.");
        for(int i = 0; i < presentcount; i++)
        {
            int presentindex = rnd.Next(0, giftpool.Count);
            Console.WriteLine($"- {giftpool[presentindex]}");
            giftpool.RemoveAt(presentindex);
        }
    }

    private static void Fortune()
    {
        Console.WriteLine("\nAnalyzing fortune prophecies...\n");
        Thread.Sleep(3000);

        List<string> theme = new List<string>
        {
            "This year feels like a building year. You may not see huge changes overnight, but many small steps will slowly create something important.",
            "This could be a year where you finally turn ideas into real projects instead of just thinking about them.",
            "This year may bring more change than expected. Some things might feel scary at first, but not every change is bad.",
            "This year seems calmer and more stable. That may sound boring, but peace can be a gift too.",
            "This might be a year of growth, even if it doesn’t always feel comfortable while it happens.",
            "This year could surprise you with how much progress comes from simply staying consistent."
        };

        List<string> challenge = new List<string>
        {
            "Your biggest challenge may be not giving up too early when something feels harder than expected.",
            "This year may test your patience. Some things will take longer than you want, and that can be frustrating.",
            "You may struggle with wanting everything to be perfect before starting. Sometimes good enough really is enough.",
            "One challenge this year may be learning when to push harder and when to rest instead.",
            "You might need to stop overthinking certain decisions and trust yourself a little more.",
            "This year may challenge you to let go of things that no longer help you."
        };

        List<string> surprise = new List<string>
        {
            "Something you have wanted for a long time may finally become real this year.",
            "A small decision may unexpectedly lead to something much bigger than you imagined.",
            "This year may bring a moment that reminds you how far you have already come.",
            "You may discover a new hobby, skill, or passion that becomes important to you.",
            "An opportunity may appear when you least expect it, so stay open to surprises.",
            "This year may contain more joy in small everyday moments than in big dramatic events."
        };

        Random rnd = new Random();

        int fortune1 = rnd.Next(0, 6);
        int fortune2 = rnd.Next(0, 6);
        int fortune3 = rnd.Next(0, 6);

        Console.WriteLine(theme[fortune1]);
        Console.WriteLine(challenge[fortune2]);
        Console.WriteLine(surprise[fortune3]);

    }
}