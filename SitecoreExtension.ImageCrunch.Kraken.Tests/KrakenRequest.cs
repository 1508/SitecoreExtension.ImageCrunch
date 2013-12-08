using System.IO;
using System.Reflection;
using NUnit.Framework;
using SitecoreExtension.ImageCrunch.Entities;

namespace SitecoreExtension.ImageCrunch.Kraken.Tests
{
    [TestFixture]
    public class KrakenRequest
    {
        [Test]
        public void CreateRequest()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "SitecoreExtension.ImageCrunch.Kraken.Tests.TestResources.testPicture.jpg";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                var cruncher = new KrakenCruncher();

                CrunchResult request = cruncher.CrunchStream(memoryStream);

            }
                       
        }
    }
}