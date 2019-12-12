using CatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogService.TransferObjects
{
	public class GetAlbumCatalogResponse : ResponseBaseDTO
	{
		public override string responseMessage { get; set; }
		public override int errorCode { get; set; }
		public override int responseStatus { get; set; }
		public List<Album> catalog { get; set; }

	}
}