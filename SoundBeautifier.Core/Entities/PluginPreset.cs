using System.ComponentModel.DataAnnotations;

namespace SoundBeautifier.Core
{
    /// <summary>
    /// Plugin preset
    /// </summary>
    public class PluginPreset
    {
        [Key]
        public int Id { get; set; }
        public Plugin Plugin { get;set;}
        /// <summary>
        /// Preset description
        /// </summary>
        public string Parameters { get; set; }
    }
}
