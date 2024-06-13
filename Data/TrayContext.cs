using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tray.Models;

namespace Tray.Data
{
    public class TrayContext : DbContext
    {
        public TrayContext (DbContextOptions<TrayContext> options)
            : base(options)
        {
        }

        public DbSet<Tray.Models.TrayModel> TrayModel { get; set; } = default!;
    }
}
