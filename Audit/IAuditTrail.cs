using System;

namespace Audit
{
    public interface IAuditTrail : IDisposable
    {
        /// <summary>
        /// This represents Event type e.g Product Updated. 
        /// </summary>
        string EventType { get; set; }

        /// <summary>
        /// Gets the event related to this scope.
        /// </summary>
        IAuditEvent Event { get; }

        /// <summary>
        /// Gets the data adapter for this AuditTrail instance.
        /// </summary>
        IAuditDataAdapter DataAdapter { get;}

        /// <summary>
        /// Add a textual comment to the event
        /// </summary>
        void Comment(string text);

        /// <summary>
        /// Save Audit Trail
        /// </summary>
        void Save();
    }
}
