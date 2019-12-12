using CatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogService.TransferObjects
{
	public class UpdateAlbumRequest :  RequestBaseDTO
	{
		public Album album { get; set; }
	}
}