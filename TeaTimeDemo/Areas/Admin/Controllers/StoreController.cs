using DumplingStore.DataAccess.Repository.IRepository;
using DumplingStore.Models;
using DumplingStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using DumplingStore.DataAccess.Data;
using DumplingStore.DataAccess.Repository;
using DumplingStore.DataAccess.Repository.IRepository;
using DumplingStore.Models;
using DumplingStore.Models.ViewModels;
using DumplingStore.Utility;
using static System.Net.Mime.MediaTypeNames;

namespace DumplingStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.Role_Admin)]

	public class StoreController : Controller
	{

		private readonly IUnitOfWork _unitOfWork;


		public StoreController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{

			List<Store> objStoreList = _unitOfWork.Store.GetAll().ToList();

			return View(objStoreList);
		}

		public IActionResult Upsert(int? id)
		{

			if (id == null || id == 0)
			{

				return View(new Store());
			}
			else
			{

				Store storeObj = _unitOfWork.Store.Get(u => u.Id == id);
				return View(storeObj); // 這裡要把資料傳進去
			}
		}
		[HttpPost]
		public IActionResult Upsert(Store storeObj)
		{

			if (ModelState.IsValid)
			{

				if (ModelState.IsValid)
				{

					if (storeObj.Id == 0)
					{
						_unitOfWork.Store.Add(storeObj);
					}
					else
					{
						_unitOfWork.Store.Update(storeObj);
					}
				}


				_unitOfWork.Save();
				TempData["success"] = "店鋪新增成功!"; 
				return RedirectToAction("Index");
			}
			else
			{
				return View(storeObj); 
			}
		}


		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{

			List<Store> objStoreList =
			_unitOfWork.Store.GetAll().ToList();
			return Json(new { data = objStoreList });
		}


		[HttpDelete]
		public IActionResult Delete(int? id)
		{

			var storeToBeDeleted = _unitOfWork.Store.Get(u => u.Id == id);
			if (storeToBeDeleted == null)
			{
				return Json(new { success = false, message = "刪除失敗" });
			}

			_unitOfWork.Store.Remove(storeToBeDeleted);
			_unitOfWork.Save();
			return Json(new { success = true, message = "刪除成功" });
		}
		#endregion
	}
}
