

namespace Audit
{
    internal class AuditTargetEntity :IAuditTargetEntity
    {
        /// <summary>
        /// The type of the object that needs to be audited
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The value of the object before save
        /// </summary>
        public object Old { get; set; }

        /// <summary>
        /// The value of the object after save
        /// </summary>
        public object New { get; set; }

    }
}
