﻿using CatalogService.Models;
using CatalogService.TransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CatalogService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface ICatalogService
	{
		[OperationContract]
		GetAlbumRecordResponse GetAlbumRecord(GetAlbumRecordRequest request);

		[OperationContract]
		CreateAlbumResponse CreateAlbumRecord(CreateAlbumRequest request);

		[OperationContract]
		GetAlbumCatalogResponse GetAlbumCatalog();

		[OperationContract]
		DeleteAlbumResponse DeleteAlbum(DeleteAlbumRequest request);

		[OperationContract]
		UpdateAlbumResponse UpdateAlbum(UpdateAlbumRequest request);

	}
}
