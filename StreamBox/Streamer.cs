using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamBox
{
    internal class Streamer
    {
        private string streamerName; // holds streamer name
        private string streamerPicture; // holds path to steamer image
        private Uri twitterURL; // holds URL for streamer's twitter
        private Uri twitchURL; // holds URL for streamer's twitch
        private Uri youtubeURL; // holds URL for streamer's youtube
        private Uri wikiURL; // hold URL to streamer's wiki

        // getters and setters
        string getStreamerName() { return streamerName; }
        private string getStreamerPicture() { return streamerPicture; }
        private Uri getTwitterURL() { return twitterURL; }


    }
}
