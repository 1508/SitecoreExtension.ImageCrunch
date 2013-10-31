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
                try
                {
                    CrunchImage.ProcessMediaItem(uploadedItem);
                }
                catch (System.Exception exception)
                {
                    Log.Error(string.Format("Could not shrink item {0}", uploadedItem.Paths.FullPath), exception, this);
                }
            }
        }
    }
}