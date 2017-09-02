using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Audit
{
    public abstract class AuditDataAdapter : IAuditDataAdapter
    {

        private static readonly JsonSerializer DefaultSerializer = JsonSerializer.Create(new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

        /// <summary>
        /// Override this method to provide a different serialization method for the values that need to be serialized before saving.
        /// (old target value and custom fields)
        /// </summary>
        public virtual object Serialize<T>(T value)
        {
            if (value == null)
            {
                return null;
            }
            return JToken.FromObject(value, DefaultSerializer);
        }

        /// <summary>
        /// Insert an event to the data source returning the event id generated
        /// </summary>
        /// <param name="auditEvent">The audit event being inserted.</param>
        public abstract object InsertEvent(IAuditEvent auditEvent);
    }
}
