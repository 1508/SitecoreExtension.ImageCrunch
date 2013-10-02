using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.Upload;

namespace SitecoreExtension.ImageCrunch.Pipelines
{
    public class Upload : UploadProcessor
    {
        public void Process(UploadArgs args)
        {
            Assert.ArgumentNotNull((object)args, "args");

            foreach (Item uploadedItem in args.UploadedItems)
            {
                CrunchImage.ProcessMediaItem(uploadedItem);
            }
        }
    }
}