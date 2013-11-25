using System.IO;
using SitecoreExtension.ImageCrunch.Entities;

namespace SitecoreExtension.ImageCrunch.Interfaces
{
    public interface ICruncher
    {
        CrunchResult CrunchStream(Stream stream);
        decimal MaxImageSize { get; }
    }
}