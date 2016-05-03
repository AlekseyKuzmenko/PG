using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG.Common.Repository;
using PG.DataAccessLayer.Repository;

namespace App
{
    class Program
    {
        static void Main()
        {
            User user = new User("John", "Snow");
            DataAccess data = new DataAccess();
            data.CreateUser(user);
            Console.ReadKey();
        }
    }
}
