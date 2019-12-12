using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogService.TransferObjects
{
	public class GetAlbumRecordRequest : RequestBaseDTO
	{
		public int albumID { get; set; }
	}
}