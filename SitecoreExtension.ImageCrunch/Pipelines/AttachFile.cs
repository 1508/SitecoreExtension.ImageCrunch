using System.IO;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.Attach;
using Sitecore.Resources.Media;

namespace SitecoreExtension.ImageCrunch.Pipelines
{
    public class AttachFile
    {
        public void Process(AttachArgs args)
        {
            MediaItem mediaItem = args.MediaItem;

            try
            {
                CrunchImage.ProcessMediaItem(mediaItem);
            }
            catch (System.Exception exception)
            {
                Log.Error(string.Format("Could not shrink item {0}", mediaItem.InnerItem.Paths.FullPath), exception, this);
            }

        }
    }
}