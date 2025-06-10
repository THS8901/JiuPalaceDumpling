using Microsoft.AspNetCore.Mvc;
using DumplingStore.DataAccess.Repository.IRepository;
using DumplingStore.Models;

namespace DumplingStore.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class StoreController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public StoreController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// 顯示 Razor View 頁面：分店資訊
		public IActionResult Stores()
		{
			return View(); // 這裡不用傳 List，因為資料改由 JS 撈取
		}

		// 提供 stores.js Ajax 呼叫用的 JSON 資料
		[HttpGet]
		public IActionResult GetAll()
		{
			List<Store> storeList = _unitOfWork.Store.GetAll().ToList();
			return Json(new { data = storeList });
		}

		// 有 Index 頁面
		public IActionResult Index()
		{
			var storeList = _unitOfWork.Store.GetAll().ToList();
			return View(storeList);
		}
	}
}