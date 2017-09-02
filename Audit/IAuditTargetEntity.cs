using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit
{
    public interface IAuditTargetEntity
    {
        /// <summary>
        /// The type of the object that needs to be audited
        /// </summary>
         string Type { get; set; }

        /// <summary>
        /// The value of the object before save
        /// </summary>
         object Old { get; set; }

        /// <summary>
        /// The value of the object after save
        /// </summary>
         object New { get; set; }
    }
}
