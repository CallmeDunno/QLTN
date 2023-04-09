using BTL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchAPIController : ControllerBase
    {
        QltnContext db = new QltnContext();

        [HttpGet("{type}/{dtsd}/{mdsd}")]
        public IEnumerable<ThongTinNha> getthongtinnhabyaddr(int type, int dtsd, int mdsd)
        {
            return db.ThongTinNhas.Where(x => x.MaLoai == type && x.MaDtsd == dtsd && x.MaMdsd == mdsd);
        }
    }
}
