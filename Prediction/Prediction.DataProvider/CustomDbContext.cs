using Microsoft.EntityFrameworkCore;
using Prediction.DataProvider.Abstraction;
using Prediction.DataProvider.Models;
using System.ComponentModel.DataAnnotations;

namespace Prediction.DataProvider
{
    public class CustomDbContext : DbContext
    {

        //Add your table here
        public DbSet<VoxelModel> VoxelTable { get; set; }
        public DbSet<ExtremeModel> ExtermeTable { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var pathToFile = "D:\\Dokumenty\\Visual Studio\\Solutions\\Prediction\\Prediction\\databaseFile.db";
            var connectionString = "Data Source = " + pathToFile;
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
