using System.ComponentModel.DataAnnotations;

namespace SoundBeautifier.Core
{
    /// <summary>
    /// VST Plugin asssembly
    /// </summary>
    public class Plugin
    {
        [Key]
        public int Id { get; set; }
        public PluginAssembly PluginAssembly { get; set; }
        public PluginType PluginType { get; set; }
    }
}
