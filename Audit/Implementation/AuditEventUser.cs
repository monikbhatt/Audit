using Newtonsoft.Json;

namespace Audit
{
    public class AuditEventUser : IAuditEventUser
    {

        /// <summary>
        /// First Name of user who created the event 
        /// </summary>
        [JsonProperty("FirstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name of user who created the event 
        /// </summary>
        [JsonProperty("LastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        /// <summary>
        /// UserName of user who created the event 
        /// </summary>
        [JsonProperty("UserName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }


        /// <summary>
        /// Email of user who created the event 
        /// </summary>
        [JsonProperty("Email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
    }
}
