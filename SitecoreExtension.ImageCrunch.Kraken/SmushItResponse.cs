using System.Runtime.Serialization;

namespace SitecoreExtension.ImageCrunch.Kraken
{
    [DataContract]
    public class Response
    {
        //{
        //  "success": true,
        //  "file_name": "header.jpg",
        //  "original_size": 324520,
        //  "kraked_size": 165358,
        //  "saved_bytes": 159162,
        //  "kraked_url": "http://dl.kraken.io/ecdfa5c55d5668b1b5fe9e420554c4ee/header.jpg"
        //}

        //No savings
        //{\"src\":\"41b6ef0a%2Fempty\",\"src_size\":285210,\"error\":\"No savings\",\"dest_size\":-1,\"id\":\"\"}


        [DataMember(Name = "file_name")]
        public string Src { get; set; }

        [DataMember(Name = "original_size")]
        public string SrcSize { get; set; }

        [DataMember(Name = "kraked_url")]
        public string Dest { get; set; }

        [DataMember(Name = "kraked_size")]
        public string DestSize { get; set; }
        
    }
}