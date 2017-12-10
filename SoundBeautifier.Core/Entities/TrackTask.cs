using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundBeautifier.Core
{
    /// <summary>
    /// The task to be performed
    /// </summary>
    public class TrackTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public Track Track { get; set; }
        /// <summary>
        /// Plugins presets, which must be used on track
        /// </summary>
        public List<PluginPreset> PluginsPresets { get; set; }

        public TrackTaskStatus TrackTaskStatus { get; set; }
    }

    public enum TrackTaskStatus {
        Unknown, Canceled, Planned, Started, ErrorDuringExecution, Completed
    }

}
