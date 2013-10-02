using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SitecoreExtension.ImageCrunch.SmushIt.Entities;

namespace SitecoreExtension.ImageCrunch.SmushIt.Tests
{
    [TestFixture]
    public class SmushItRequest
    {
        [Test]
        public void CreateRequest()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "SitecoreExtension.ImageCrunch.SmushIt.Tests.TestResources.testPicture.jpg";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                SmushItResponse request = SmushIt.SmushItRequest.SmushIt(memoryStream);

            }
                       
        }
    }
}