namespace CrowdSourcedNews.Services.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;

    public static class PubNubSender
    {
        private static string channel = "articles-channel";

        private static PubnubAPI pubnub = new PubnubAPI
            (
                "pub-c-1e071e25-f030-4efe-82e4-19bb24939b3b",               // PUBLISH_KEY
                "sub-c-4bd5dcc4-04e5-11e3-991c-02ee2ddab7fe",               // SUBSCRIBE_KEY
                "sec-c-ZDEyMWMyYzYtZTA5Yi00NTZhLWI0ODQtMTdiZjdjOGU0MDBl",   // SECRET_KEY
                true                                                        // SSL_ON?
            );

        public static void Send(string message)
        {
            pubnub.Publish(channel, message);
        }
    }
}
