﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstagramJsonMessages
{
    public class JSONReader
    {
        public Profile getProfile(string jsonPath)
        {
            Profile temp = JsonConvert.DeserializeObject<Profile>(jsonPath);
            return temp;
        }
        public AccountHistory praseLoginHistory(string jsonPath)
        {
            return JsonConvert.DeserializeObject<AccountHistory>(jsonPath);
        }

        public CommentHistory praseCommentHistory(string jsonPath)
        {
            return JsonConvert.DeserializeObject<CommentHistory>(jsonPath);
        }

        public List<ContactInfo> praseContacts(string jsonPath)
        {
            return JsonConvert.DeserializeObject<List<ContactInfo>>(jsonPath);

        }

        public Media praseMedia(string jsonPath)
        {
            return JsonConvert.DeserializeObject<Media>(jsonPath);
           
        }

        public Connections praseConnections( string jsonPath)
        {
            return JsonConvert.DeserializeObject<Connections>(jsonPath);
        }
    }

    public class Connections
    {
        public Dictionary<string, string> blocked_users { get; set; }
        public Dictionary<string, string> close_friends { get; set; }
        public Dictionary<string, string> restricted_users { get; set; }
        public Dictionary<string, string> follow_requests_sent { get; set; }
        public Dictionary<string, string> followers { get; set; }
        public Dictionary<string, string> following { get; set; }
        public Dictionary<string, string> following_hashtags { get; set; }
    }


    public class Media
    {
        public List<Picture> stories { get; set; }
        public List<Picture> videos { get; set; }
        public List<Picture> direct { get; set; }
        public List<Picture> photos { get; set; }

        public void joinData(Media data)
        {
            append(stories, data.stories);
            append(videos, data.videos);
            append(direct, data.direct);
            append(photos, data.photos);
        }
        private void append(List<Picture> storage, List<Picture> import)
        {
            if (import != null)
            {
                storage.AddRange(import);
            }
        }
    }

    public class Picture
    {
        public string caption { get; set; }
        public string taken_at { get; set; }
        public string path { get; set; }
    }

    public class ContactInfo
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string contact { get; set; }
    }

    public class CommentHistory
    {
        public Object[] media_comments { get; set; }
    }

    public class AccountHistory
    {
        public Login[] login_history { get; set; }
    }

    public class Login
    {
        public string ip_address { get; set; }
        public string timestamp { get; set; }
    }

    public class Profile
    {
        public string biography { get; set; }
        public string date_joined { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public bool private_account { get; set; }
        public string name { get; set; }
        public string profile_pic_url { get; set; }
        public string username { get; set; }
    }
}