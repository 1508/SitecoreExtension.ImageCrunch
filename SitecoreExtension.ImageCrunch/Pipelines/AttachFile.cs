using System.IO;
using Sitecore.Data.Items;
using Sitecore.Pipelines.Attach;
using Sitecore.Resources.Media;
using SitecoreExtension.ImageCrunch.SmushIt.Entities;

namespace SitecoreExtension.ImageCrunch.Pipelines
{
    public class AttachFile
    {
        public void Process(AttachArgs args)
        {
            MediaItem mediaItem = args.MediaItem;

            CrunchImage.ProcessMediaItem(mediaItem);

        }
    }
}