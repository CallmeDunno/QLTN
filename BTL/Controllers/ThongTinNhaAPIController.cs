using BTL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinNhaAPIController : ControllerBase
    {
        QltnContext db = new QltnContext();

        [HttpGet("{type}")]
        public IEnumerable<ThongTinNha> getthongtinnhabyvalue(int? type)
        {
            switch (type)
            {
                case 1: return db.ThongTinNhas.OrderBy(x => x.NgayDangTai);
                case 2: return db.ThongTinNhas.OrderBy(x => x.GiaPhong);
                case 3: return db.ThongTinNhas.OrderByDescending(x => x.GiaPhong);
                default: return db.ThongTinNhas.ToList();
            }
        }

        [HttpGet("{type}/{id}")]
        public IEnumerable<ThongTinNha> getthongtinnhabyhost(int? type, int? id)
        {
            switch (type)
            {
                case 1: return db.ThongTinNhas.Where(x => x.MaChuNha == id).OrderBy(x => x.NgayDangTai);
                case 2: return db.ThongTinNhas.Where(x => x.MaChuNha == id).OrderBy(x => x.GiaPhong);
                case 3: return db.ThongTinNhas.Where(x => x.MaChuNha == id).OrderByDescending(x => x.GiaPhong);
                default: return db.ThongTinNhas.Where(x => x.MaChuNha == id).ToList();
            }
        }
    }
}
