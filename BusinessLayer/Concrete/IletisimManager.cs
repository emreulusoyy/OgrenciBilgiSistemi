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
    public class IletisimManager : IIletisimService
    {
        IIletisimDal _iletisimDal;

        public IletisimManager(IIletisimDal iletisimDal)
        {
            _iletisimDal = iletisimDal;
        }

        public void TDelete(Iletisim t)
        {
           _iletisimDal.Delete(t);
        }

        public Iletisim TGetByID(int id)
        {
           return _iletisimDal.GetByID(id);
        }

        public List<Iletisim> TGetList()
        {
            return _iletisimDal.GetList();  
        }

        public void TInsert(Iletisim t)
        {
            _iletisimDal.Insert(t);
        }

        public void TUpdate(Iletisim t)
        {
            _iletisimDal.Update(t); 
        }
    }
}
