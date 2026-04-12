using System;

namespace Lab4
{
    public class CityEvent
    {
        private readonly int id;
        public string title;
        public string duration;
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

    class Program
    {
        static void Main(string[] args)
        {
          
        }
    }
}
