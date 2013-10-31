using System;
using System.Linq;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Jobs;
using Sitecore.Shell.Framework.Commands;

namespace SitecoreExtension.ImageCrunch.App.Commands
{
    public class ShrinkImageOnTree : ShrinkImage
    {
        protected override void Shrink(object[] parameters)
        {
            var mediaItem = parameters[0] as Item;

            if (mediaItem == null)
            {
                return;
            }

            Job job = Context.Job;
            try
            {
                CrunchImage.ProcessMediaItem(mediaItem);
                if (job != null)
                {
                    job.Status.LogInfo(string.Format("Done: {0}", mediaItem.Paths.FullPath));
                }
            }
            catch (Exception catche)
            {
                if (job != null)
                {
                    job.Status.LogInfo(string.Format("{0}: {1}",catche.Message, mediaItem.Paths.FullPath));
                }
            }

            foreach (var child in mediaItem.Children)
            {
                this.Shrink(new []{ child });
            }
        }
    }
}