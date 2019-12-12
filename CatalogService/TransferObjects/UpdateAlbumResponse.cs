using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogService.TransferObjects
{
	public class UpdateAlbumResponse : ResponseBaseDTO
	{
		public override string responseMessage { get; set; }
		public override int errorCode { get; set; }
		public override int responseStatus { get; set; }
	}
}