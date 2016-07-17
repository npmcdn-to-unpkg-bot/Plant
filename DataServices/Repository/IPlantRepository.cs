using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace DataServices.Repository
{
    interface IPlantRepository
    {
        DbSet<Tree> Trees { get; set; }
    }
}
