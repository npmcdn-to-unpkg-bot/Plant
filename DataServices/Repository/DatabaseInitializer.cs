using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServices.Repository
{
    public class DatabaseInitializer
    {
        public DatabaseInitializer(IServiceProvider serviceProvider)
        {
            //var context = (ApplicationDbContext)serviceProvider.GetService(ApplicationDbContext>();
            //context.Database.EnsureCreated();

        }

        public void EnsureSeedData()
        {

        }
    }
}
