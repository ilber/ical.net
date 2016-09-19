using System;
using System.Reflection;
using Ical.Net.Interfaces.DataTypes;
using Ical.Net.Interfaces.Serialization;
using Ical.Net.Interfaces.Serialization.Factory;
using Ical.Net.Serialization.iCalendar.Serializers.DataTypes;
using Ical.Net.Serialization.iCalendar.Serializers.Other;

namespace Ical.Net.Serialization.iCalendar.Factory
{
    public class DataTypeSerializerFactory : ISerializerFactory
    {
        /// <summary>
        /// Returns a serializer that can be used to serialize and object
        /// of type <paramref name="objectType"/>.
        /// <note>
        ///     TODO: Add support for caching.
        /// </note>
        /// </summary>
        /// <param name="objectType">The type of object to be serialized.</param>
        /// <param name="ctx">The serialization context.</param>
        public virtual ISerializer Build(Type objectType, ISerializationContext ctx)
        {
            if (objectType != null)
            {
                ISerializer s;

                if (typeof (IAttachment).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                {
                    s = new AttachmentSerializer();
                }
                else if (typeof (IAttendee).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                {
                    s = new AttendeeSerializer();
                }
                else if (typeof (IDateTime).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                {
                    s = new DateTimeSerializer();
                }
                else if (typeof (IFreeBusyEntry).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                {
                    s = new FreeBusyEntrySerializer();
                }
                else if (typeof (IGeographicLocation).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                {
                    s = new GeographicLocationSerializer();
                }
                else if (typeof (IOrganizer).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                {
                    s = new OrganizerSerializer();
                }
                else if (typeof (IPeriod).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                {
                    s = new PeriodSerializer();
                }
                else if (typeof (IPeriodList).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                {
                    s = new PeriodListSerializer();
                }
                else if (typeof (IRecurrencePattern).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                {
                    s = new RecurrencePatternSerializer();
                }
                else if (typeof (IRequestStatus).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                {
                    s = new RequestStatusSerializer();
                }
                else if (typeof (IStatusCode).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                {
                    s = new StatusCodeSerializer();
                }
                else if (typeof (ITrigger).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                {
                    s = new TriggerSerializer();
                }
                else if (typeof (IUtcOffset).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                {
                    s = new UtcOffsetSerializer();
                }
                else if (typeof (IWeekDay).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                {
                    s = new WeekDaySerializer();
                }
                // Default to a string serializer, which simply calls
                // ToString() on the value to serialize it.
                else
                {
                    s = new StringSerializer();
                }

                // Set the serialization context
                s.SerializationContext = ctx;

                return s;
            }
            return null;
        }
    }
}