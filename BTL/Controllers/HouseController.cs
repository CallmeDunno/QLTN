using BTL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BTL.Controllers
{
    //Vũ
    public class HouseController : Controller
    {
        private readonly ILogger<HouseController> _logger;
        QltnContext db = new QltnContext();

        public HouseController(ILogger<HouseController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(int ? page)
        {
            int pageSize = 6;
            int pageNumber=  page == null || page < 0 ? 1 : page.Value;
            var lstphong = db.ThongTinNhas.AsNoTracking().OrderBy(x => x.MaLoai);
            PagedList<ThongTinNha> lst = new PagedList<ThongTinNha>(lstphong, pageNumber, pageSize);
            return View(lst);
        }
    }

}
