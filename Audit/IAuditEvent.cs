using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Audit
{
    public interface IAuditEvent
    {
        /// <summary>
        /// This represents Event type e.g Product Updated. 
        /// </summary>
         string EventType { get; set; }
       
        /// <summary>
        /// Target entity.
        /// </summary>
         IAuditTargetEntity TargetEntity { get; set; }

        /// <summary>
        /// Comments.
        /// </summary>
         List<string> Comments { get; set; }

        /// <summary>
        /// The date then the event was created
        /// </summary>
         DateTime CreatedDate { get; set; }

        /// <summary>
        /// User Who created an event
        /// </summary>
        IAuditEventUser User { get; set; }

       
    }
}
