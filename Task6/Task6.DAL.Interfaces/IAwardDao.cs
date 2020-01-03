using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;

namespace Task6.DAL.Interfaces
{
    public interface IAwardDao
    {
        Award Add(Award award);
        Award GetById(int id);
        IEnumerable<Award> GetAll();
    }
}
