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
    public class MufredatManager : IMufredatService
    {
        IMufredatDal _mufredatDal;

        public MufredatManager(IMufredatDal mufredatDal)
        {
            _mufredatDal = mufredatDal;
        }

        public void TDelete(Mufredat t)
        {
           _mufredatDal.Delete(t);  
        }

        public Mufredat TGetByID(int id)
        {
            return _mufredatDal.GetByID(id);
        }

        public List<Mufredat> TGetList()
        {
            return _mufredatDal.GetList();
        }

        public void TInsert(Mufredat t)
        {
            _mufredatDal.Insert(t);
        }

        public void TUpdate(Mufredat t)
        {
            _mufredatDal.Update(t);
        }
    }
}
