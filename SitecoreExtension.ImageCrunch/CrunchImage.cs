using System.IO;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Resources.Media;
using SitecoreExtension.ImageCrunch.SmushIt.Entities;

namespace SitecoreExtension.ImageCrunch
{
    public class CrunchImage
    {
        public static void ProcessMediaItem(MediaItem mediaItem)
        {
            if (mediaItem.MimeType == "image/jpeg" || mediaItem.MimeType == "image/pjpeg" ||
               mediaItem.MimeType == "image/gif" || mediaItem.MimeType == "image/png")
            {

                if (mediaItem.Size >= 1048576)
                {
                    return;
                }

                var mediaStream = mediaItem.GetMediaStream();
                SmushItResponse result = SmushIt.SmushItRequest.SmushIt(mediaStream);

                if (result == null)
                {
                    Log.Error(string.Format("Could not shrink media file {0}", mediaItem.InnerItem.Paths.Path), typeof(CrunchImage));
                    return;
                }

                Sitecore.Resources.Media.Media media = MediaManager.GetMedia(mediaItem);

                using (var stream = new MemoryStream())
                {
                    result.FileStream.CopyTo(stream);

                    stream.Position = 0;
                    media.SetStream(stream, Path.GetExtension(result.Format).TrimStart('.'));
                }

            }
        }
    }
}