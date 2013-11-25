using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sitecore.Reflection;
using SitecoreExtension.ImageCrunch.Interfaces;

namespace SitecoreExtension.ImageCrunch.Factory
{
    public abstract class Cruncher : ICruncher
    {

        public static Cruncher GetCruncher()
        {
            var providerObject = (Cruncher)Sitecore.Configuration.Settings.GetProviderObject("ImageCruncher", typeof(Cruncher));

            
            return providerObject;
        }

        public abstract Entities.CrunchResult CrunchStream(Stream stream);
        public abstract decimal MaxImageSize { get; set; }
    }
}
