using System.IO;

namespace SitecoreExtension.ImageCrunch.SmushIt.Entities
{
    public class SmushItResponse
    {
        public string Format { get; set; }

        public Stream FileStream { get; set; }
    }
}