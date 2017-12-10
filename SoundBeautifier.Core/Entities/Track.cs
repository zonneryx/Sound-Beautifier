using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBeautifier.Core
{
    /// <summary>
    /// WAV-track 
    /// </summary>
    public class Track
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Data's uploaded by user
        /// </summary>
        public byte[] SourceContent { get; set; }
        /// <summary>
        /// Data's after mixing
        /// </summary>
        public byte[] TargetContent { get; set; }
        public string ServiceUserId { get; set; }
        [ForeignKey("ServiceUserId")]
        public ServiceUser ServiceUser { get; set; }
    }

}
