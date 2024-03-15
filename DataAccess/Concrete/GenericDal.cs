using DataAccess.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class GenericDal<T> : IGenericDal<T> where T : BaseEntity
    {
        private readonly List<T> values;
        public GenericDal() 
        {
            values = new List<T>();
        }
        public void Add(T entity)
        {
            values.Add(entity);
        }

        public void Delete(T entity)
        {
            T deletedValue = values.SingleOrDefault(x => x.Id == entity.Id);
            if (deletedValue != null)
            {
                values.Remove(deletedValue);
            }
            else
            {
                Console.WriteLine("Silinmesi istenen" + typeof(T).Name + "bulunamadı!");
            }
        }

        public List<T> GetAll()
        {
            return values;
        }

        //public T GetById(int id)
        //{
        //    T GetValue = values.SingleOrDefault(x => x.Id == id);
        //    if (GetValue != null)
        //    {
        //        return GetValue;
        //    }
     
        //}

        public void Update(T entity)
        {
            T updatedValue = values.SingleOrDefault(x => x.Id == entity.Id);
            if (updatedValue != null)
            {
                updatedValue.Name = entity.Name;
            }
            else
            {
                Console.WriteLine("Güncellenmesi istenen" + typeof(T).Name + "bulunamadı!");
            }
        }
    }
}
