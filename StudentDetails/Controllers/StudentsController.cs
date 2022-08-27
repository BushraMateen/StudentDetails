using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using StudentDataAccess;

namespace StudentDetails.Controllers
{
    public class StudentsController : ApiController
    {
        public IEnumerable<SchoolData> Get()
        {
            using(STMSEntities entities = new STMSEntities())
            {
                return entities.SchoolDatas.ToList();
            }
        }
    }
}
