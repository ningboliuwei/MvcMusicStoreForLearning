using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using MvcMusicStoreForLearning.Models;

namespace MvcMusicStoreForLearning.Controllers
{
	public class StoreController : Controller
	{
		private MusicStoreEntities storeDB = new MusicStoreEntities();
		// GET: Store
		public ActionResult Index()
		{
			var genres = storeDB.Genres.ToList();

			return View(genres);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="genre">参数：如 genre=disco 和具体的参数名有关，自动获得参数值，
		/// 多个 URL 参数的话就在参数列表中增加参数即可</param>
		/// <returns></returns>
		public ActionResult Browse(string genre)
		{
			var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);

			return View(genreModel);
		}

		/// <summary>
		/// 将从 Model 获得的原始数据经过处理，转换为表现出来的数据
		/// </summary>
		/// <param name="id">直接通过 /Store/Details/5 的这种形式获得 id 的值</param>
		/// <returns></returns>
		public ActionResult Details(int id)
		{
			var album = storeDB.Albums.Find(id);

			return View(album);
		}
	}
}