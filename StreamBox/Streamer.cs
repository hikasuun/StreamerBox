using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamBox
{
     public class Streamer
    {
        private string streamerName; // holds streamer name
        private string streamerAlias; // holds alias for streamer
        private Uri twitterURL; // holds URL for streamer's twitter
        private Uri youtubeURL; // holds URL for streamer's youtube

        public Streamer(string name, string alias, Uri twitter, Uri youtube)
        {
            this.streamerName = name;
            this.streamerAlias = alias;
            this.twitterURL = twitter;
            this.youtubeURL = youtube;
        }

        // getters and setters
        public string getStreamerName() { return streamerName; }
        public string getStreamerAlias() { return streamerAlias; }
        public Uri getTwitterURL() { return twitterURL; }
        public Uri getYoutubeURL() { return youtubeURL; }
        public void setStreamerName(string name) { this.streamerName = name; }
        public void setStreamerAlias(string alias) { this.streamerAlias = alias; }
        public void setTwitterURL(Uri url) { this.twitterURL = url; }
        public void setYoutubeURL(Uri url) { this.youtubeURL= url; }

    }
}
