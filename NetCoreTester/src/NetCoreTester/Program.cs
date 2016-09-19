using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ical.Net;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using Ical.Net.Serialization.iCalendar.Serializers;

namespace NetCoreTester
{
    public class Program
    {
        private static readonly DateTime _now = DateTime.Now;
        private static readonly DateTime _later = _now.AddHours(1);
        private const string _timeZone = "America/New_York";

        public static void Main(string[] args)
        {
            var e = new Event
            {
                DtStart = new CalDateTime(_now, _timeZone),
                DtEnd = new CalDateTime(_later, _timeZone)
            };

            var c = new Calendar();
            c.Events.Add(e);

            var serializer = new CalendarSerializer(new SerializationContext());
            Console.WriteLine(serializer.SerializeToString(c));

            Console.ReadLine();
        }
    }
}
