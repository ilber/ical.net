using System;
using Ical.Net.Interfaces.Components;
using Ical.Net.Interfaces.DataTypes;

namespace Ical.Net
{
	public interface IAlarmOccurrence
	{
		IPeriod Period { get; set; }

		IRecurringComponent Component { get; set; }

		IAlarm Alarm { get; set; }

		IDateTime DateTime { get; set; }
	}
}
