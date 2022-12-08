using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace DatabaseMeme.Controllers
{

    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Login(string name, string password)
        {
            var db = new MemeDbContext();
            var u = db.Useris.Where(x => x.Username == name && x.Password == password).FirstOrDefault();
            if (u == null)
            {
                return NotFound("user nu poate fi gasit");
            }
             string o = u.Id.ToString();
            return o;
        }

        [HttpPost]

        public ActionResult <Useri> register (string name, string password, string email)
        {
            /*bool NameisMissing = false;
            bool PassisMissing = false;
            bool EmailMissing = false;*/
            string missing = "";
            if(string.IsNullOrWhiteSpace(name))
            {
                missing += "name: is missing\n";
            }
            if(string.IsNullOrWhiteSpace(password))
            {
                missing += "password: is missing\n";
            }
            if(string.IsNullOrWhiteSpace(email))
            {
                missing += "email : is missing";
            }
            //if (missing == "")
            {
                var db = new MemeDbContext();
                var u = new Useri();
                u.Username = name;
                u.Password = password;
                u.Email = email;
                db.Useris.Add(u);
                db.SaveChanges();
                return u;
            }
            //return BadRequest(missing);
        }
    }
}
