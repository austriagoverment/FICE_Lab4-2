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
    }

    class Program
    {
        static void Main(string[] args)
        {
          
        }
    }
}
