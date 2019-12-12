using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CatalogService.Models
{
	[DataContract]
	public class Album
	{
		int _albumID;
		string _albumName = "";
		string _artist = "";
		string _type = "";
		int _stock;

		[DataMember]
		public int AlbumID
		{
			get { return _albumID; }
			set { _albumID = value; }
		}

		[DataMember]
		public string AlbumName
		{
			get { return _albumName; }
			set { _albumName = value; }
		}

		[DataMember]
		public string Artist
		{
			get { return _artist; }
			set { _artist = value; }
		}

		[DataMember]
		public string Type
		{
			get { return _type; }
			set { _type = value; }
		}

		[DataMember]
		public int Stock
		{
			get { return _stock; }
			set { _stock = value; }
		}
	}
}