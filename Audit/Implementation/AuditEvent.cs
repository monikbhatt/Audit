using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Audit
{
    internal class AuditEvent : IAuditEvent
    {
        /// <summary>
        /// This represents Event type e.g Product Updated. 
        /// </summary>

        public string EventType { get; set; }
        /// <summary>
        /// Target entity.
        /// </summary>
        [JsonProperty("TargetEntity", NullValueHandling = NullValueHandling.Ignore)]
        public IAuditTargetEntity TargetEntity { get; set; }

        /// <summary>
        /// Comments.
        /// </summary>
        [JsonProperty("Comments", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Comments { get; set; }

        /// <summary>
        /// The date then the event was created
        /// </summary>
        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// User Who created an event
        /// </summary>
        [JsonProperty("User")]
        public IAuditEventUser User { get; set; }


    }
}
