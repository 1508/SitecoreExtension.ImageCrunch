namespace SitecoreExtension.ImageCrunch.Kraken
{
    public static class Settings
    {
        private static string _apiKey;
        private static string _apiSecret;
        private static string _maxImageSize;

        public static string ApiKey
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_apiKey))
                {
                    _apiKey =  Sitecore.Configuration.Settings.GetSetting("Kraken.ApiKey");

                }
                return _apiKey;
            }
        }

        public static string ApiSecret
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_apiSecret))
                {
                    _apiSecret = Sitecore.Configuration.Settings.GetSetting("Kraken.ApiSecret");

                }
                return _apiSecret;
            }
            
        }

        public static string MaxImageSize
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_maxImageSize))
                {
                    _maxImageSize = Sitecore.Configuration.Settings.GetSetting("Kraken.MaxImageSize");

                }
                return _maxImageSize;
            }

        }
    }
}