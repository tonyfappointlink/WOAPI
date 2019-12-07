using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOAPI.WOContext
{
    public class WOModel : WOModelBase
    {

        public WOModel(DbContextOptions<WOModelBase> options) : base(options)
        {
            
            Database.OpenConnection();
        }

        public WOModel(string s) 
        {
            
            Database.OpenConnection();
        }

    }
}
