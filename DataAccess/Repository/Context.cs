using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Context
    {
        private static DBContext context;

        private Context()
        {

        }

        public static DBContext GetContext()
        {
            if (context == null)
            {
                return context = new DBContext();
            }

            else return context;
        }
    }
}
