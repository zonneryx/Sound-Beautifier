using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace SoundBeautifier.Core
{
    public class ServiceUser : IdentityUser
    {
     
        [ForeignKey("Subscripe")]
        public int SubscripeId { get; set; }
        public Subscripe Subscripe { get; set; }
    }

}
