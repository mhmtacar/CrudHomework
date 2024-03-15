using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GenericManager<T> : IGenericManager<T> where T : BaseEntity
    {
        private readonly IGenericDal<T> _genericDal;
        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }
        public void Add(T entity)
        {
            _genericDal.Add(entity);
        }

        public void Delete(T entity)
        {
            _genericDal.Delete(entity);
        }

        public List<T> GetAll()
        {
            return _genericDal.GetAll();
        }

        public void Update(T entity)
        {
            _genericDal.Update(entity);
        }
    }
}
