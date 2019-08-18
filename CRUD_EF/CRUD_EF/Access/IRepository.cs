using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EF.Access
{
    public interface IRepository<T>
    {
        bool Add(T item);
        T ReadOne(long id);
        T ReadOne(string credential1, string credential2);
        List<T> ReadAll();
        void Update(long id, T newItem);
        bool Delete(long id);
        bool Exist(string credential1, string credential2);
    }
}
