using _01_BOL;
using _02_BLL;
using _03_UIL.Filter;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _03_UIL.Controllers
{
   
    [Authorize]
    [AuthenticationFilter]
   
    public class UserController : ApiController
    {
        // GET: api/User/5
        public IHttpActionResult Get()
        {

            var re = Request;
            var headers = re.Headers;
          
            int user = RentUser.GetLogin(headers.Authorization.Scheme, headers.Authorization.Parameter);
            return Ok(user);
        }
        // GET: api/User/5
       
        [Authorize(Roles = "admin,worker")]
        public IHttpActionResult Get(string id)
        {
            
            BOLUserInfo user = RentUser.GetLoginUserFrom_db(id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }

        }

        // POST: api/User
        [AllowAnonymous]
        [AddRegister]
        public IHttpActionResult Post([FromBody]BOLUserInfo value)
        {
            RentUser.AddUserTo_db(value);
            return Ok();
        }

        // PUT: api/User/5
        [AddRegister]
        [Authorize(Roles = "admin")]
        public IHttpActionResult Put(string id, [FromBody]BOLUserInfo value)
        {
            RentUser.UpDataTo_db(id, value);
            return Ok();
        }

        // DELETE: api/User/5
        [AddRegister]
        [Authorize(Roles = "admin")]
        public IHttpActionResult Delete(string id)
        {
            RentUser.deleteFrom_db(id);
            return Ok();
        }
    }
}
