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
    public class DerslerManager : IDerslerService
    {
        IDerslerDal _derslerDal;

        public DerslerManager(IDerslerDal derslerDal)
        {
            _derslerDal = derslerDal;
        }

        public void TDelete(Dersler t)
        {
            _derslerDal.Delete(t);
        }

        public Dersler TGetByID(int id)
        {
            return _derslerDal.GetByID(id);
        }

        public List<Dersler> TGetList()
        {
            return _derslerDal.GetList();
        }

        public void TInsert(Dersler t)
        {
            _derslerDal.Insert(t);
        }

        public void TUpdate(Dersler t)
        {
            _derslerDal.Update(t);  
        }
    }
}
