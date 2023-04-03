using BTL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BTL.Controllers
{  
    public class HostController : Controller
    {
        QltnContext db = new QltnContext();
        private readonly ILogger<HostController> _logger;

        public HostController(ILogger<HostController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstchunha = db.ChuNhas.AsNoTracking().OrderBy(x => x.MaChuNha).ToList();
            PagedList<ChuNha> lst = new PagedList<ChuNha>(lstchunha, pageNumber, pageSize);
            return View(lst);
        }

       /* public IActionResult Index(int )
        {
            var chunhas = db.ChuNhas.ToList();
            //ViewBag.ChuNhas = chunhas;
            return View(chunhas);
        }*/
    }
}
