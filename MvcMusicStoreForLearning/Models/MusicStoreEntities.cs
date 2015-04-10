﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcMusicStoreForLearning.Models;

namespace MvcMusicStoreForLearning.Models
{
	public class MusicStoreEntities:DbContext
	{
		public DbSet<Album> Albums { get; set; }

		public DbSet<Genre> Genres { get; set; }

		public DbSet<Artist> Artists { get; set; } 
	}
}