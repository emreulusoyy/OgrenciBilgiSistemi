using DataAccessLayer.Abstruct;
using DataAccessLayer.Repositories;
using OBSEntityLayer.NewConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfIletisimDal : GenericRepository<Iletisim>, IIletisimDal
    {
    }
}
