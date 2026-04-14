using System;

namespace Lab4
{
    public class CityEvent
    {
        private readonly int id;
        public string Title { get; set; }
        public string Duration { get; set; }
        static int counter = 0;

        public CityEvent()
        {
            counter++;
            id = counter;
        }

        public bool IsDurationMoreThanThreeHours()
        {
            var parts = Duration.Split(' ');
            if (parts.Length == 2 && int.TryParse(parts[0], out int hours))
            {
                return hours > 3;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Duration: {Duration}";
        }

        public override bool Equals(object obj)
        {
            if (obj is CityEvent otherEvent)
            {
                return id == otherEvent.id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }

    public class Concert : CityEvent
    {
        public string Performer { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Performer: {Performer}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Concert otherConcert)
            {
                return base.Equals(otherConcert) && Performer.Equals(otherConcert.Performer, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Performer);
        }
    }

    public class Exhibition : CityEvent
    {
        public string Location { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Location: {Location}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Exhibition otherExhibition)
            {
                return base.Equals(otherExhibition) && Location.Equals(otherExhibition.Location, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Location);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Concert concert1 = new Concert { Title = "RVRB", Duration = "2 hours", Performer = "Oakwood, American Football, Foxing" };
            Exhibition exhibition = new Exhibition { Title = "Fusion Jams Lucky 7th Birthday", Duration = "8 hours", Location = "Kyrylivska Street 41, Kyiv" };

            Console.WriteLine(concert1);
            Console.WriteLine(exhibition);

            Concert concert2 = new Concert { Title = "RVRB", Duration = "2 hours", Performer = "Oakwood, American Football, Foxing" };
            Console.WriteLine($"чи дорівнюють концерти? {concert1.Equals(concert2)}");
            
            bool isLongerThanThreeHours = exhibition.IsDurationMoreThanThreeHours();
            Console.WriteLine($"чи йде більше 3х годин {isLongerThanThreeHours}");
            
            bool isConcertLongerThanThreeHours = concert1.IsDurationMoreThanThreeHours();
            Console.WriteLine($"чи є концерт довшим за 3 години? {isConcertLongerThanThreeHours}");

            Console.WriteLine($"хеш код концерту1: {concert1.GetHashCode()}");
            Console.WriteLine($"хеш код концерту2: {concert2.GetHashCode()}");
        }
    }
}