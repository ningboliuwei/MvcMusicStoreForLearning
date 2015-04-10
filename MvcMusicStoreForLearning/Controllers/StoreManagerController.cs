using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStoreForLearning.Models;

namespace MvcMusicStoreForLearning.Controllers
{
	public class StoreManagerController : Controller
	{
		private MusicStoreEntities storeDB = new MusicStoreEntities();
		// GET: StoreManager
		public ActionResult Index()
		{
			//Include() 类似于连接操作，将关联的数据一并返回
			var albums = storeDB.Albums.Include("Genre").Include("Artist");
			return View(albums.ToList());
		}

		// GET: StoreManager/Details/5
		public ActionResult Details(int id)
		{
			Album album = storeDB.Albums.Find(id);
			return View(album);
		}

		// GET: StoreManager/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: StoreManager/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: StoreManager/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: StoreManager/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: StoreManager/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: StoreManager/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
