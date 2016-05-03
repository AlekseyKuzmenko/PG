using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG.Common.Repository;

namespace PG.Common
{
    public interface IDataCrud
    {
        void CreateUser(User user);
        User GetUser(string id);
        void UpdateUser(string id, User user);
        void RemoveUser(string id);
    }
}
