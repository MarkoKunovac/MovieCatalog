using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Filmskikatalog
{
    public class FilmContext : DbContext
    {
        public FilmContext() : base()
        {

        }

        public DbSet<Film> Filmovi { get; set; }
    }
}
