// StreamEvents.cs
// Class to hold information about individual streams
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamBox
{
    public class StreamEvents
    {
        private Streamer streamerName;
        private DateTime streamDateTime;
        private Uri streamURL;
        //private string streamTitle; // TO BE ADDED IN FUTURE UPDATE

        public StreamEvents(Streamer s, DateTime d, Uri u)
        {
            this.streamerName = s;
            this.streamDateTime = d;
            this.streamURL = u;
            //this.streamTitle = t; 
        }

        public Streamer getStreamer() { return streamerName;}
        public DateTime getStreamDate() { return streamDateTime;}
        public Uri getStreamURL() { return streamURL;}
        //public string getStreamTitle() { return streamTitle;}
    }
}
