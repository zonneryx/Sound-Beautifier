using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SoundBeautifier.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.CodeFirst.Migrations
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<SoundBeatifierDbContext>
    {
        protected override void Seed(SoundBeatifierDbContext context)
        {
            //var manager = new UserManager<ServiceUser>(new UserStore<ServiceUser>(context));

            var subscripe = new Subscripe()
            {
                Name = "Basic",
                Priority = Priority.Middle
            };


            var user = new ServiceUser()
            {
                UserName = "Admin",
                Email = "test@user.ru",
                EmailConfirmed = true,
                Subscripe = subscripe
            };
            context.Users.Add(user);
            context.SaveChanges();
            //manager.Create(user, "1234");

        }
    }
}
