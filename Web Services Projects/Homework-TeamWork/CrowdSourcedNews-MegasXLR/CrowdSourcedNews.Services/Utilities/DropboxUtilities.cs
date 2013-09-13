namespace CrowdSourcedNews.Services.Utilities
{
    using Spring.IO;
    using Spring.Social.Dropbox.Api;
    using Spring.Social.Dropbox.Connect;
    using Spring.Social.OAuth1;
    using System.Diagnostics;
    using System.IO;    
    
    internal static class DropboxUtilities
    {
        private const string DropboxAppKey = "53dn8lcquvt293e";
        private const string DropboxAppSecret = "jveyb20mtdbh5ck";

        private const string OAuthTokenFileName = "OAuthTokenFileName.txt";

        public static IDropbox CreateAndLoginDropBox()
        {
            DropboxServiceProvider dropboxServiceProvider =
                new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);

            // Authenticate the application (if not authenticated) and load the OAuth token
            //if (!File.Exists(OAuthTokenFileName))
            //{
            //    AuthorizeAppOAuth(dropboxServiceProvider);
            //}

            OAuthToken oauthAccessToken = LoadOAuthToken();

            // Login in Dropbox
            IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

            return dropbox;
        }

        public static Entry UploadImage(string imagePath, IDropbox dropbox, string folderName)
        {
            string imageName = Path.GetFileName(imagePath);

            Entry uploadFileEntry = dropbox.UploadFileAsync(
                new FileResource(imagePath),
                "/" + folderName + "/" + imageName).Result;

            return uploadFileEntry;
        }

        private static OAuthToken LoadOAuthToken()
        {
            OAuthToken oauthAccessToken = new OAuthToken("88lixsugnarrd19f", "94ao4bfgaao095k");
            return oauthAccessToken;
        }

        //private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
        //{
        //    OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;

        //    OAuth1Parameters parameters = new OAuth1Parameters();
        //    string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
        //        oauthToken.Value, parameters);
        //    Process.Start(authenticateUrl);

        //    AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
        //    OAuthToken oauthAccessToken =
        //        dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;

        //    string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
        //    File.WriteAllLines(OAuthTokenFileName, oauthData);
        //}
    }
}