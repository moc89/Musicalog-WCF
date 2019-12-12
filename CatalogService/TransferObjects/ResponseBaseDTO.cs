using CatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogService.TransferObjects
{
	public abstract class ResponseBaseDTO
	{
		public ResponseBaseDTO()
		{
			this.responseMessage = "Successfull";
			this.errorCode = 0;
			this.responseStatus = 0;
		}

		public abstract string responseMessage { get; set; }
		public abstract int errorCode { get; set; }
		public abstract int responseStatus { get; set; }
	}
}