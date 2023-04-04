using BTL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BTL.Controllers
{
    public class HouseController : Controller
    {
        private readonly ILogger<HouseController> _logger;
        QltnContext db = new QltnContext();

        public HouseController(ILogger<HouseController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber=  page == null || page < 0 ? 1 : page.Value;
            var lstphong = db.ThongTinNhas.AsNoTracking().OrderBy(x => x.MaNha);
            PagedList<ThongTinNha> lst = new PagedList<ThongTinNha>(lstphong, pageNumber, pageSize);
            return View(lst);
        }

        public IActionResult HouseDetail(int MaNha)
        {
            var nha = db.ThongTinNhas.SingleOrDefault(x => x.MaNha == MaNha);
            /*var chunha = db.ChuNhas.SingleOrDefault(x => x.MaChuNha == nha.MaChuNha);
            var dichvu = db.Dich.SingleOrDefault(x => x.)*/
            if (nha == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(nha);
            }
        }
    }

}
