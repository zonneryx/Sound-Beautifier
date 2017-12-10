using System.Data.Entity;
using EntityFramework.CodeFirst.Migrations;
using SoundBeautifier.Core;
using Microsoft.AspNet.Identity.EntityFramework;

public class SoundBeatifierDbContext : IdentityDbContext<ServiceUser>
{

    public SoundBeatifierDbContext() : base ("DefaultConnection")
    {
        //Important performance code
        //Configuration.AutoDetectChangesEnabled = false; 
        //Configuration.LazyLoadingEnabled = false;
        //Configuration.ProxyCreationEnabled = false;
    }

    static SoundBeatifierDbContext()
    {
        Database.SetInitializer(new ApplicationDbInitializer());
    }

    public static SoundBeatifierDbContext Create()
    {
        return new SoundBeatifierDbContext();
    }

    public DbSet<Track> Tracks { get; set; }
    public DbSet<TrackTask> TrackTasks { get; set; }
    public DbSet<Plugin> Plugins { get; set; }
    public DbSet<PluginPreset> PluginPresets { get; set; }
    public DbSet<PluginAssembly> PluginAssemblies { get; set; }
    public DbSet<Subscripe> Subscripes { get; set; }
}
