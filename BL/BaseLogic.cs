using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BaseLogic : IDisposable
    {
        public static ShachlavDB db = new ShachlavDB();
        public void Test()
        {
            using (ShachlavDB TestDb = new ShachlavDB())
            {
                TestDb.MaterialCategory.Add(new MaterialCategory() { Id = 1, Name = "tt" });
                TestDb.SaveChanges();
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
   
}
