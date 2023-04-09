using BTL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTL.Controllers
{
    public class SearchController : Controller
    {
        QltnContext db = new QltnContext();
        public IActionResult Index()
        {
            var loainha = db.LoaiNhas.ToList();
            var dtsd = db.DoiTuongSuDungs.ToList();
            var mdsd = db.MucDichSuDungs.ToList();
            ViewModelSearch viewModelSearch = new ViewModelSearch
            {
                LoaiNhaList = loainha,
                DoiTuongSuDungList = dtsd,
                MucDichSuDungList = mdsd
            };
            return View(viewModelSearch);
        }
    }
}
