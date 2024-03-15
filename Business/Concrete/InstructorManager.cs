using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InstructorManager : GenericManager<Instructor>, IInstructorManager
    {
        public InstructorManager(IGenericDal<Instructor> genericDal) : base(genericDal)
        {
        }
    }
}
