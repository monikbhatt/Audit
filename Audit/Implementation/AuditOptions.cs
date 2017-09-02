
using System;

namespace Audit
{
    internal class AuditOptions
    {
        /// <summary>
        /// Gets or sets the string representing the type of the event.
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// Gets or sets the target object getter 
        /// </summary>
        public Func<object> TargetGetter { get; set; }

        /// <summary>
        /// Gets or sets the data Adapter to use.
        /// </summary>
        public IAuditDataAdapter DataAdapter { get; set; }

        /// <summary>
        /// Gets or sets the AuditEvent to track object change
        /// </summary>
        public IAuditEvent AuditEvent { get; set; }

        /// <summary>
        /// Gets or sets the Target Entity to track
        /// </summary>
        public IAuditTargetEntity TargetEntity { get; set; }

        /// <summary>
        /// Gets or sets the User that created the event
        /// </summary>
        public IAuditEventUser User { get; set; }

        /// <summary>
        /// Creates an instance of options for an audit scope creation.
        /// </summary>
        /// <param name="eventType">A string representing the type of the event.</param>
        /// <param name="targetGetter">The target object getter.</param>
        /// <param name="dataAdapter">Data Adapter to be used</param>
        /// <param name="auditEventUser">User who created the event</param>
        public AuditOptions(
            string eventType ,
            Func<object> targetGetter ,
            IAuditDataAdapter dataAdapter ,
            IAuditEventUser auditEventUser = null
           )
        {
            EventType = eventType ?? "Default";
            TargetGetter = targetGetter;
            DataAdapter = dataAdapter;
            User = auditEventUser;
            var targetValue = TargetGetter.Invoke();
            TargetEntity = new AuditTargetEntity()
            {
                //Serialize the target object and store its intitial value in event.
                Old = DataAdapter.Serialize(targetValue),
                Type = targetValue?.GetType().FullName
            };
            AuditEvent = new AuditEvent
            {
                CreatedDate = DateTime.Now,
                EventType = EventType,
                User =  User
            };

        }

        
    }
}
