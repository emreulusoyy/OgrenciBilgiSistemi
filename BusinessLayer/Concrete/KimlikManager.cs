using BusinessLayer.Abstruct;
using DataAccessLayer.Abstruct;
using OBSEntityLayer.NewConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class KimlikManager : IKimlikService
    {
        IKimlikDal _kimlikDal;

        public KimlikManager(IKimlikDal kimlikDal)
        {
            _kimlikDal = kimlikDal;
        }

        public void TDelete(Kimlik t)
        {
           _kimlikDal.Delete(t);    
        }

        public Kimlik TGetByID(int id)
        {
           return _kimlikDal.GetByID(id);
        }

        public List<Kimlik> TGetList()
        {
            return _kimlikDal.GetList();
        }

        public void TInsert(Kimlik t)
        {
            _kimlikDal.Insert(t);
        }

        public void TUpdate(Kimlik t)
        {
            _kimlikDal.Update(t);
        }
    }
}
