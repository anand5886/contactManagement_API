using Microsoft.EntityFrameworkCore;

namespace HRMS.API.Data.DataSeed
{
    /// <summary>
    /// Seeds initial data to the database
    /// </summary>
    public interface IDataSeeder
    {
        /// <summary>
        /// Method to seed data to the database
        /// </summary>
        /// <param name="context">Database context to be seeded with data</param>
        void SeedData(ModelBuilder context);
    }
}
