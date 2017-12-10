using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundBeautifier.Core
{
    /// <summary>
    /// VST Plugin asssembly
    /// </summary>
    public class PluginAssembly
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public byte[] Content { get; set; }
    }

}
