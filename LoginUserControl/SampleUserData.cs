using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUserControl
{
    public class SampleUserData
    {
        // Get sample user data for testing
        public static IEnumerable<User> GetAll()
        {
            yield return new User("WenjieZhou", "wenjiezhou2333");
            yield return new User("JohnPeter", "johnpeter123");
            yield return new User("LarryBird", "happyday888");
            yield return new User("BillGates", "realbillgates");
            yield return new User("SteveJobs", "apple4u");
        }
    }
}
