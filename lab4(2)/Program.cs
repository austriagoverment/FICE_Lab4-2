using System;

namespace Lab4
{
    public class CityEvent
    {
        private readonly int id;
        private string title;
        private string duration;
        static int counter = 0;

        public CityEvent()
        {
            counter++;
            id = counter;
        }

        public virtual string GetInfo()
        {
            return $"ID: {id}, Title: {title}, Duration: {duration}";
        }

        public bool IsDurationMoreThanThreeHours()
        {
            var parts = duration.Split(' ');
            if (parts.Length == 2 && int.TryParse(parts[0], out int hours))
            {
                return hours > 3;
            }
            return false;
        }
    }

    public class Concert : CityEvent
    {
        public string performer;

        public override string GetInfo()
        {
            return base.GetInfo() + $", Performer: {performer}";
        }
    }

    public class Exhibition : CityEvent
    {
        public string location;

        public override string GetInfo()
        {
            return base.GetInfo() + $", Location: {location}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Concert concert = new Concert();
            concert.title = "RVRB";
            concert.duration = "2 hours";
            concert.performer = "Oakwood, American Football, Foxing";

            Exhibition exhibition = new Exhibition();
            exhibition.title = "Fusion Jams Lucky 7th Birthday";
            exhibition.duration = "8 hours";
            exhibition.location = "Kyrylivska Street 41, Kyiv";

            Console.WriteLine(concert.GetInfo());
            Console.WriteLine(exhibition.GetInfo());

            Console.WriteLine($"Is the concert longer than 3 hours? {concert.IsDurationMoreThanThreeHours()}");
            Console.WriteLine($"Is the exhibition longer than 3 hours? {exhibition.IsDurationMoreThanThreeHours()}");
        }
    }
}
