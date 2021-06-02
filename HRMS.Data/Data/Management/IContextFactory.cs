using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Data.Management
{
    /// <summary>
    /// Context factory interface
    /// </summary>
    public interface IContextFactory
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        IDbContext DbContext { get; }

        string ChangeDatabaseName(string tenantId);
    }
}
