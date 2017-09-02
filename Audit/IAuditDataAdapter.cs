using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit
{
    public interface IAuditDataAdapter
    {
        /// <summary>
        /// Implement this method to provide a different serialization method for the values that need to be serialized before saving.
        /// (old target value and custom fields)
        /// </summary>
        object Serialize<T>(T value);

        /// <summary>
        /// Insert an event to the data source 
        /// </summary>
        /// <param name="auditEvent">The audit event being inserted.</param>
         object InsertEvent(IAuditEvent auditEvent);
    }
}
