using System.IO;

namespace SitecoreExtension.ImageCrunch.Entities
{
    public class CrunchResult
    {
        public string Format { get; set; }

        public Stream FileStream { get; set; }
    }
}