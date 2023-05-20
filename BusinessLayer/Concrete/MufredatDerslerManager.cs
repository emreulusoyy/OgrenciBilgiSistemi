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
    public class MufredatDerslerManager : IMufredatDerslerService
    {
        IMufredatDerslerDal _mufredatDerslerDal;

        public MufredatDerslerManager(IMufredatDerslerDal mufredatDerslerDal)
        {
            _mufredatDerslerDal = mufredatDerslerDal;
        }

        public void TDelete(MufredatDersler t)
        {
            
            _mufredatDerslerDal.Delete(t);
        }

        public MufredatDersler TGetByID(int id)
        {
           return _mufredatDerslerDal.GetByID(id);
        }

        public List<MufredatDersler> TGetList()
        {
            return _mufredatDerslerDal.GetList();
        }

        public void TInsert(MufredatDersler t)
        {
            _mufredatDerslerDal.Insert(t);
        }

        public void TUpdate(MufredatDersler t)
        {
            _mufredatDerslerDal.Update(t);
        }
    }
}
