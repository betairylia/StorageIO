using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageIO
{
    abstract class User
    {
        public List<Permisson> permissonList;

        public virtual void init()
        {

        }
    }

    class Solder : User
    {
        public List<Invoice> selfSells;
    }
}
