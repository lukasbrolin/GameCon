using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    class UserRepository : IDisposable
    {
        public DatingSiteContext _context { get; set; }

        public UserRepository(DatingSiteContext context)
        {
            this._context = context;
        }

        public void Dispose()
        {

        }
    }
}
