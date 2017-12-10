using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundBeautifier.Core
{
    /// <summary>
    /// User's subscripe
    /// </summary>
    public class Subscripe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Priority Priority { get; set; }
    }

    public enum Priority
    {
       High, Middle, Low
    }

}
