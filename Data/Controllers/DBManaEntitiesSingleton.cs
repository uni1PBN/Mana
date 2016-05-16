using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Controllers
{
    public class DBManaEntitiesSingleton
    {
        private static DBManaEntities instance;
        private DBManaEntitiesSingleton() { }
        public static DBManaEntities Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBManaEntities();
                }
                return instance;
            }
        }
    }
}
