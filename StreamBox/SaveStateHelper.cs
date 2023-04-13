using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace StreamBox
{
    [Serializable]
    public class userSaveState // holds user configs
    {
        private string userName; // holds user name
        private ArrayList streamerArrayList = new ArrayList(); // generic list -> array list, SOAP cannot serialze generic lists

        public string UserName { get => userName; set => userName = value; }
        public ArrayList StreamerArrayList { get => streamerArrayList;set => streamerArrayList = value; }
    }

    public class SaveStateHelper
    {
        public userSaveState currentSaveState = new userSaveState();
        // Lists are unserializable using SOAP, convert back when deserialized
        public List<Streamer> deserializedStreamerList = new List<Streamer>(); // hold deserialized list
        public SaveStateHelper(BaseForm currentForm)
        {
            currentSaveState.UserName = currentForm.getUserName();
            currentSaveState.StreamerArrayList.AddRange(currentForm.streamerList);
        }

        public SaveStateHelper() { }

        public void writeUserState(String filePath)
        {
            IFormatter localFormatter = new SoapFormatter();
            Stream localStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            localFormatter.Serialize(localStream, currentSaveState);
            localStream.Close();
        }

        public void readUserState(String filePath)
        {
            IFormatter localFormatter = new SoapFormatter();
            Stream localStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
            currentSaveState = (userSaveState)localFormatter.Deserialize(localStream);
            //convert back to original type
            arrayToList();
            localStream.Close();
        }

        public void arrayToList()
        {
            foreach (Streamer streamer in currentSaveState.StreamerArrayList)
            {
                deserializedStreamerList.Add(streamer);
            }
        }
    }
}
