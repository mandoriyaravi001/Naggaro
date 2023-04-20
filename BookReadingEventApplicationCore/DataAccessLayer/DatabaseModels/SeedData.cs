using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DatabaseModels
{
    public static class SeedData
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            using (var context = new EventDataContext
                    (serviceProvider.GetRequiredService<
                    DbContextOptions<EventDataContext>>()))
            {


            context.User.AddRange
            (  );
            context.SaveChanges();

            context.Event.AddRange
            (
            );
            context.SaveChanges();

             context.Comment.AddRange
             ( );
            context.SaveChanges();
            }
        }
    }
}
