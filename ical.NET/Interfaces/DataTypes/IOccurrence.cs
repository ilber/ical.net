using Ical.Net.Interfaces.DataTypes;
using Ical.Net.Interfaces.Evaluation;

namespace Ical.Net
{
	public interface IOccurrence
	{
		IPeriod Period { get; set; }
		IRecurrable Source { get; set; }
	}
}
