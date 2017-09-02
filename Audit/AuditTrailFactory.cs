using System;

namespace Audit
{
    public  class AuditTrailFactory
    {
        /// <summary>
        /// Creates an audit trail object for a target object ,event type , dataAdapter and User.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="target">The reference object getter.</param>
        /// <param name="dataAdapter">Data Adapter object that will strore the event</param>
        /// <param name="user">User who is creating the change</param>
        public static IAuditTrail Create(string eventType, Func<object> target, IAuditDataAdapter dataAdapter, IAuditEventUser user)
        {
            return new AuditTrail(new AuditOptions(eventType, target, dataAdapter,user));
        }
    }

}
