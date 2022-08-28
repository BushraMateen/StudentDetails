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
            using (STMSEntities entities = new STMSEntities())
            {
                return entities.SchoolDatas.ToList();
            }
        }
        public HttpResponseMessage Get(int id)
        {
            using (STMSEntities entities = new STMSEntities())
            {
                var entity = entities.SchoolDatas.FirstOrDefault(e => e.id == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id " + id.ToString() + "not found");
                }
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
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (STMSEntities entities = new STMSEntities())
                {
                    var entity = entities.SchoolDatas.FirstOrDefault(e => e.id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id " + id.ToString() + "not found to delete");

                    }
                    else
                    {
                        entities.SchoolDatas.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Deleted succesfully");

                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

            }
        }
        public HttpResponseMessage Put(int id, [FromBody] SchoolData schooldata)
        {
            try
            {
                using (STMSEntities entities = new STMSEntities())
                {
                    var entity = entities.SchoolDatas.FirstOrDefault(e => e.id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id = " + id.ToString() + "not found to update");

                    }
                    else
                    {
                        entity.SchoolCode = schooldata.SchoolCode;
                        entity.SchoolName = schooldata.SchoolName;
                        entity.District = schooldata.District;
                        entity.Block = schooldata.Block;
                        entity.Cluster = schooldata.Cluster;
                        entity.Status = schooldata.Status;
                        entity.SchoolCode = schooldata.SchoolCode;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity, "updated succesfully");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }   
    } 
