using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MouseS
{
    static class DataHandle
    {
        static HttpClient client = new HttpClient();
        //static string path = Directory.GetCurrentDirectory() + @"\Profiles.txt";
        public static List<Profile> LoadProfiles()
        {
            List<Profile> profiles = new List<Profile>();
            /*
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                profiles = JsonConvert.DeserializeObject<List<Profile>>(text);
            }
            else
            {
                Profile Defalut = new Profile();
                Defalut.Name = "Defalut Profile";
                Defalut.DubbleClick = 500;
                Defalut.MouseSpeed = 10;
                Defalut.ScrollSpeed = 3;
                profiles.Add(Defalut);
            }
            
            */

            string text = GetDataAPI(client,1).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            text = text.Substring(2);
            profiles = JsonConvert.DeserializeObject<List<Profile>>(text);

            return profiles;
        }
        public static void SaveProfiles(List<Profile> profiles)
        {
            
            string json = JsonConvert.SerializeObject(profiles);
            /*
            System.IO.File.WriteAllText(path, json);
            */
        }

        public static Task<HttpResponseMessage> GetDataAPI(HttpClient client, int ID)
        {
            return client.GetAsync("https://hynekma16.sps-prosek.cz/API/?ID=" + ID);
        }


    }
}
