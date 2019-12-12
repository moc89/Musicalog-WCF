using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatalogService;
using CatalogService.Models;
using CatalogService.TransferObjects;

namespace UnitTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void AddAlbumRecord()
		{

			CatalogService.CatalogService service = new CatalogService.CatalogService();

			CreateAlbumRequest testAlbum = new CreateAlbumRequest();
			testAlbum.album = new Album();
			testAlbum.album.AlbumName = "HASAN BARIS";
			testAlbum.album.Artist = "London";
			testAlbum.album.Stock = 3;
			try
			{
				var _res = service.CreateAlbumRecord(testAlbum);
			}
			catch (Exception ex)
			{
				throw;
			}
			return;
		}

		[TestMethod]
		public void DeleteAlbum()
		{

			CatalogService.CatalogService service = new CatalogService.CatalogService();

			try
			{
				DeleteAlbumRequest testAlbum = new DeleteAlbumRequest();
				testAlbum.albumID = 6;

				var _resp = service.DeleteAlbum(testAlbum);

			}
			catch (Exception ex)
			{
				throw;
			}

			return;
		}

		[TestMethod]
		public GetAlbumCatalogResponse GetAlbumCatalog()
		{

			CatalogService.CatalogService service = new CatalogService.CatalogService();

			GetAlbumCatalogResponse _resp = new GetAlbumCatalogResponse();
			try
			{
				_resp = service.GetAlbumCatalog();

			}
			catch (Exception ex)
			{

				throw;
			}

			return _resp;
		}

		[TestMethod]
		public GetAlbumRecordResponse GetAlbumRecord()
		{

			CatalogService.CatalogService service = new CatalogService.CatalogService();

			GetAlbumRecordRequest testAlbum = new GetAlbumRecordRequest();
			testAlbum.albumID= 4;
			GetAlbumRecordResponse _resp = new GetAlbumRecordResponse();
			try
			{
				 _resp = service.GetAlbumRecord(testAlbum);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return _resp;
		}

		[TestMethod]
		public UpdateAlbumResponse UpdateAlbum()
		{

			CatalogService.CatalogService service = new CatalogService.CatalogService();

			UpdateAlbumRequest testAlbum = new UpdateAlbumRequest();
			testAlbum.album = new Album();
			testAlbum.album.AlbumName = "HASAN BARIS";
			testAlbum.album.Artist = "Trabzon";
			testAlbum.album.Stock = 7;
			testAlbum.album.AlbumID = 5;
			UpdateAlbumResponse _resp = new UpdateAlbumResponse();

			try
			{
				_resp = service.UpdateAlbum(testAlbum);

			}
			catch (Exception ex)
			{

				throw ex;
			}

			return _resp;
		}
	}
}
