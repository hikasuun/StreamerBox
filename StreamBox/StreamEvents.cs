﻿// StreamEvents.cs
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
        private Streamer streamerName; // holds streamer object
        private DateTime streamDateTime; // holds date and time of event
        private Uri streamURL; // holds url to stream

        public StreamEvents(Streamer s, DateTime d, Uri u)
        {
            this.streamerName = s;
            this.streamDateTime = d;
            this.streamURL = u;
        }

        public Streamer getStreamer() { return streamerName;}
        public DateTime getStreamDate() { return streamDateTime;}
        public Uri getStreamURL() { return streamURL;}
    }
}
