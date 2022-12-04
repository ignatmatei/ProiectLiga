using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMeme.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class dbmController : ControllerBase
    {
        [HttpGet]
        public Useri[] getuser()
        {
            using var db = new MemeDbContext();
            return db.Useris.ToArray();
        }
        [HttpGet]
        public Meme[] getmeme()
        {
            using var db = new MemeDbContext();
            return db.Memes.ToArray();
        }
        [HttpGet]

        public Meme[] getMeme(long memeid)
        {
            using var db = new MemeDbContext();
            var memes = db.Memes.Where(x => x.Id == memeid).ToArray();
            return memes;
        }
        [HttpDelete]

        public void deleteMeme(long id) {
            var m = new Meme();
            m.Id = id;
            using  var db = new MemeDbContext();
            db.Memes.Remove(m);
            db.SaveChanges();
        }
    }
}
