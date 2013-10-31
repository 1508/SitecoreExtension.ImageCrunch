using System.Runtime.Serialization;

namespace SitecoreExtension.ImageCrunch.SmushIt.Responses
{
    [DataContract]
    public class SmushItResponse
    {
        //{"src":"3b5f6540%2Fwoo","src_size":139906,"dest":"http:\/\/ysmushit.zenfs.com\/results\/3b5f6540%2Fsmush%2Fwoo.jpg","dest_size":131544,"percent":"5.98","id":""}

        //No savings
        //{\"src\":\"41b6ef0a%2Fempty\",\"src_size\":285210,\"error\":\"No savings\",\"dest_size\":-1,\"id\":\"\"}


        [DataMember(Name = "src")]
        public string Src { get; set; }

        [DataMember(Name = "src_size")]
        public string SrcSize { get; set; }

        [DataMember(Name = "dest")]
        public string Dest { get; set; }

        [DataMember(Name = "dest_size")]
        public string DestSize { get; set; }

        [DataMember(Name = "percent_size")]
        public string Percent { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        
    }
}