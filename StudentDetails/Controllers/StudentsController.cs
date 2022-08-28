using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public SchoolData Get(int id)
        {
            using (STMSEntities entities = new STMSEntities())
            {
                return entities.SchoolDatas.FirstOrDefault(e => e.id == id);
            }
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] SchoolData schooldata)
        {
            try
            {
                using (STMSEntities entities = new STMSEntities())
                {
                    entities.SchoolDatas.Add(schooldata);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, schooldata);
                    message.Headers.Location = new Uri(Request.RequestUri + schooldata.id.ToString());
                    return message;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }
    }
}
