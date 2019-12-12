using CatalogService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
using CatalogService.TransferObjects;
using System.Runtime.InteropServices;

namespace CatalogService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class CatalogService : ICatalogService
	{
		private const string ConnectionString = "CatalogDBConnString";
		public string GetConnectionString()
		{
			return ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString;
		}

		public CreateAlbumResponse CreateAlbumRecord(CreateAlbumRequest createAlbumRequest)
		{
			CreateAlbumResponse response = new CreateAlbumResponse();
			try
			{
				using (SqlConnection con = new SqlConnection(GetConnectionString()))
				{
					string Query = @"INSERT INTO [Musicalog].[dbo].[Catalog] (AlbumName,Artist,Type,Stock)   
                                               Values(@AlbumName,@Artist,@Type,@Stock)";

					SqlCommand cmd = new SqlCommand(Query, con);
					cmd.Parameters.AddWithValue("@AlbumName", createAlbumRequest.album.AlbumName);
					cmd.Parameters.AddWithValue("@Artist", createAlbumRequest.album.Artist);
					cmd.Parameters.AddWithValue("@Type", createAlbumRequest.album.Type);
					cmd.Parameters.AddWithValue("@Stock", createAlbumRequest.album.Stock);

					con.Open();
					cmd.ExecuteNonQuery();
					con.Close();
				}

				response.responseMessage = "Record Added Successfully !";

			}
			catch (FaultException<COMException> fex)
			{
				response.responseMessage = "Error CreateAlbumRecord!" + fex.Detail.Message;
				response.errorCode = fex.Detail.ErrorCode;
			}
			return response;
		}

		public DeleteAlbumResponse DeleteAlbum(DeleteAlbumRequest request)
		{
			DeleteAlbumResponse response = new DeleteAlbumResponse();
			try
			{
				using (SqlConnection con = new SqlConnection(GetConnectionString()))
				{
					string Query = @"DELETE FROM [Musicalog].[dbo].[Catalog] WHERE AlbumID=@AlbumID";

					SqlCommand cmd = new SqlCommand(Query, con);
					cmd.Parameters.AddWithValue("@AlbumID", request.albumID);

					con.Open();
					cmd.ExecuteNonQuery();
					con.Close();
				}

				response.responseMessage = "Record Deleted Successfully !";
			}
			catch (FaultException<COMException> fex)
			{
				response.responseMessage = "Error DeleteAlbum!" + fex.Detail.Message;
				response.errorCode = fex.Detail.ErrorCode;
			}
			return response;
		}

		public GetAlbumCatalogResponse GetAlbumCatalog()
		{
			GetAlbumCatalogResponse response = new GetAlbumCatalogResponse();

			try
			{
				using (SqlConnection con = new SqlConnection(GetConnectionString()))
				{
					string Query = @"SELECT * FROM [Musicalog].[dbo].[Catalog]";


					SqlCommand command = new SqlCommand(Query, con);
					con.Open();
					SqlDataReader reader = command.ExecuteReader();

					List<Album> catalog = new List<Album>();
					while (reader.Read())
					{
						var album = new Album();
						// reader index is the column name from query
						// You can also use column index, for example reader.GetString(0)
						album.AlbumID = Convert.ToInt32(reader["AlbumID"]);
						album.AlbumName = reader["AlbumName"] as string;
						album.Artist = reader["Artist"] as string;
						album.Stock = Convert.ToInt32(reader["Stock"]);
						album.Type = reader["Type"] as string;
						catalog.Add(album);
					}
					con.Close();

					response.catalog = catalog;
					response.responseMessage = "Get all Catalog respond Successfully!";
				}
			}
			catch (FaultException<COMException> fex)
			{
				response.responseMessage = "Error GetAlbumCatalog!" + fex.Detail.Message;
				response.errorCode = fex.Detail.ErrorCode;
			}
			return response;
		}

		public GetAlbumRecordResponse GetAlbumRecord(GetAlbumRecordRequest request)
		{
			GetAlbumRecordResponse response = new GetAlbumRecordResponse();

			try
			{
				using (SqlConnection con = new SqlConnection(GetConnectionString()))
				{
					string Query = @"SELECT * FROM [Musicalog].[dbo].[Catalog] WHERE AlbumID=@AlbumID";

					SqlCommand command = new SqlCommand(Query, con);
					command.Parameters.AddWithValue("AlbumID", request.albumID);
					con.Open();
					SqlDataReader reader = command.ExecuteReader();

					Album album = new Album();
					while (reader.Read())
					{
						album.AlbumID = Convert.ToInt32(reader["AlbumID"]);
						album.AlbumName = reader["AlbumName"] as string;
						album.Artist = reader["Artist"] as string;
						album.Stock = Convert.ToInt32(reader["Stock"]);
						album.Type = reader["Type"] as string;
					}

					con.Close();
					response.album = album;
					response.responseMessage = "Get Album respond Successfully!";
				}
			}
			catch (FaultException<COMException> fex)
			{
				response.responseMessage = "Error GetAlbumRecord!" + fex.Detail.Message;
				response.errorCode = fex.Detail.ErrorCode;
			}
			return response;
		}

		public UpdateAlbumResponse UpdateAlbum(UpdateAlbumRequest album)
		{
			UpdateAlbumResponse response = new UpdateAlbumResponse();
			try
			{
				using (SqlConnection con = new SqlConnection(GetConnectionString()))
				{
					string Query = @"UPDATE [Musicalog].[dbo].[Catalog] SET AlbumName=@AlbumName,Artist=@Artist,Type=@Type,Stock=@Stock WHERE AlbumID=@AlbumID";

					SqlCommand command = new SqlCommand(Query, con);
					command.Parameters.AddWithValue("@AlbumID", album.album.AlbumID);
					command.Parameters.AddWithValue("@AlbumName", album.album.AlbumName);
					command.Parameters.AddWithValue("@Artist", album.album.Artist);
					command.Parameters.AddWithValue("@Type", album.album.Type);
					command.Parameters.AddWithValue("@Stock", album.album.Stock);
					
					con.Open();
					command.ExecuteNonQuery();
					con.Close();

					response.responseMessage = "Album Updated Successfully!";
				}
			}
			catch (FaultException<COMException> fex)
			{
				response.responseMessage = "Error UpdateAlbum!" + fex.Detail.Message;
				response.errorCode = fex.Detail.ErrorCode;
			}
			return response;
		}
	}
}
