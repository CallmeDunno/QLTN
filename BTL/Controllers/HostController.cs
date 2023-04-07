using Azure;
using BTL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BTL.Controllers
{  
    public class HostController : Controller
    {
        private readonly ILogger<HostController> _logger;
        QltnContext db = new QltnContext();

        public HostController(ILogger<HostController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstchu = db.ChuNhas.AsNoTracking().OrderBy(x => x.MaChuNha);
            PagedList<ChuNha> lst = new PagedList<ChuNha>(lstchu, pageNumber, pageSize);
            return View(lst);
        }

        public IActionResult HostDetail(int MaChuNha)
        {
            var chunha = db.ChuNhas.Where(x => x.MaChuNha == MaChuNha).FirstOrDefault();
            var nha = db.ThongTinNhas.Where(x => x.MaChuNha == MaChuNha).ToList();
            HostDetail hostDetail = new HostDetail 
            {
                ThongTinNha = nha,
                ChuNha = chunha
            };
            if (hostDetail == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(hostDetail);
            }
        }
    }
}
