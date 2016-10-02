using System;
using Ical.Net.Interfaces.DataTypes;
using Ical.Net.Interfaces.Evaluation;

namespace Ical.Net.DataTypes
{
	public class Occurrence : IComparable<IOccurrence>, IOccurrence
	{
		public IPeriod Period { get; set; }
		public IRecurrable Source { get; set; }

		public Occurrence(IOccurrence ao)
		{
			Period = ao.Period;
			Source = ao.Source;
		}

		public Occurrence(IRecurrable recurrable, IPeriod period)
		{
			Source = recurrable;
			Period = period;
		}

		public bool Equals(IOccurrence other)
		{
			return Equals(Period, other.Period) && Equals(Source, other.Source);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}
			return obj is IOccurrence && Equals((IOccurrence)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Period?.GetHashCode() ?? 0) * 397) ^ (Source?.GetHashCode() ?? 0);
			}
		}

		public override string ToString()
		{
			var s = "IOccurrence";
			if (Source != null)
			{
				s = Source.GetType().Name + " ";
			}

			if (Period != null)
			{
				s += "(" + Period.StartTime + ")";
			}

			return s;
		}

		public int CompareTo(IOccurrence other)
		{
			return Period.CompareTo(other.Period);
		}
	}
}