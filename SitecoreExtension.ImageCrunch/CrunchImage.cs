using System;
using System.IO;
using System.Runtime.CompilerServices;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Jobs;
using Sitecore.Resources.Media;
using SitecoreExtension.ImageCrunch.Entities;
using SitecoreExtension.ImageCrunch.Factory;
using SitecoreExtension.ImageCrunch.Interfaces;

namespace SitecoreExtension.ImageCrunch
{
    public class CrunchImage
    {
        public static void ProcessMediaItem(MediaItem mediaItem)
        {
            if (mediaItem.MimeType == "image/jpeg" || mediaItem.MimeType == "image/pjpeg" ||
                mediaItem.MimeType == "image/gif" || mediaItem.MimeType == "image/png")
            {
                ICruncher cruncher = Cruncher.GetCruncher();

                if (cruncher == null)
                {
                    Log.Error("Could not find cruncher!", typeof (CrunchImage));
                    return;
                }

                if (mediaItem.Size >= cruncher.MaxImageSize)
                {
                    return;
                }

                var mediaStream = mediaItem.GetMediaStream();


                try
                {
                    CrunchResult result = cruncher.CrunchStream(mediaStream);
                    if (result == null)
                    {
                        Log.Error(string.Format("Could not shrink media file {0}", mediaItem.InnerItem.Paths.Path),
                            typeof (CrunchImage));
                    }

                    Sitecore.Resources.Media.Media media = MediaManager.GetMedia(mediaItem);

                    using (var stream = new MemoryStream())
                    {
                        result.FileStream.CopyTo(stream);

                        stream.Position = 0;
                        media.SetStream(stream, Path.GetExtension(result.Format).TrimStart('.'));
                    }
                }
                catch (Exception exception)
                {
                    Job job = Context.Job;

                    if (job != null)
                    {
                        job.Status.LogError("Image could not be reduced in size");
                    }

                    Log.Error(string.Format("Image crunch failed: {0}", mediaItem.InnerItem.Paths.FullPath), exception,
                        (typeof (CrunchImage)));
                }
            }
        }
    }
}