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
			ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name");
			ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name");
			return View();
		}

		// POST: StoreManager/Create
		// 带[HttpPost]的都是用于“真正地”写入数据的方法
		[HttpPost]
		public ActionResult Create(Album album)
		{
			// TODO: Add insert logic here
			//检查表单的数据是否通过了验证
			if (ModelState.IsValid)
			{
				//保存数据
				storeDB.Albums.Add(album);
				storeDB.SaveChanges();

				//并显示新的专辑列表
				return RedirectToAction("Index");
			}

			//若没有通过验证，则重新显示带验证信息的表单
			ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
			ViewBag.AritistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);

			return View(album);

		}

		// GET: StoreManager/Edit/5
		public ActionResult Edit(int id)
		{
			Album album = storeDB.Albums.Find(id);

			return View(album);
		}

		// POST: StoreManager/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here
				Album album = storeDB.Albums.Find(id);

				if (TryUpdateModel<Album>(album))
				{
					return RedirectToAction("Index");
				}
				return View();
			}
			catch
			{
				return View();
			}
		}

		// GET: StoreManager/Delete/5
		public ActionResult Delete(int id)
		{
			Album album = storeDB.Albums.Find(id);

			return View(album);
		}

		// POST: StoreManager/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here
				Album album = storeDB.Albums.Find(id);
				storeDB.Albums.Remove(album);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
