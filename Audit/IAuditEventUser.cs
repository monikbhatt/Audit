
namespace Audit
{
    public interface IAuditEventUser
    {/// <summary>
        /// First Name of user who created the event 
        /// </summary>
      
         string FirstName { get; set; }

        /// <summary>
        /// Last Name of user who created the event 
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// UserName of user who created the event 
        /// </summary>

        string UserName { get; set; }


        /// <summary>
        /// Email of user who created the event 
        /// </summary>
        string Email { get; set; }
    }
}
