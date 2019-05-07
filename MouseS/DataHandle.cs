using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MouseS
{
    static class DataHandle
    {
        static HttpClient client = new HttpClient();
        static string urlAddress = "https://hynekma16.sps-prosek.cz/API/";
        //static string path = Directory.GetCurrentDirectory() + @"\Profiles.txt";
        public static List<Profile> LoadProfiles(int ID)
        {
            List<Profile> profiles = new List<Profile>();

            HttpResponseMessage uff = GetDataAPI(client, ID).GetAwaiter().GetResult();
            string text = uff.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            text = text.Substring(2);


            if(uff.StatusCode == HttpStatusCode.OK)
            {
                if(text != "")
                {
                    try
                    {
                        profiles = JsonConvert.DeserializeObject<List<Profile>>(text);
                    }
                    catch (Exception e)
                    {
                        profiles.Add(SetDefalutProfile());
                    }
                }
                else { profiles.Add(SetDefalutProfile()); }
            }
            else { profiles.Add(SetDefalutProfile()); }


            
            

            return profiles;
        }
        public static Profile SetDefalutProfile()
        {
            Profile Defalut = new Profile();
            Defalut.Name = "Defalut Profile";
            Defalut.DubbleClick = 500;
            Defalut.MouseSpeed = 10;
            Defalut.ScrollSpeed = 3;
            return Defalut;
        }
        public static void SaveProfiles(List<Profile> profiles, int ID)
        {
            
            string json = JsonConvert.SerializeObject(profiles);

            SaveDataAPI(ID, json);

           
        }

        public static Task<HttpResponseMessage> GetDataAPI(HttpClient client, int ID)
        {
            return client.GetAsync(urlAddress + "?ID=" + ID);
        }

        public static void SaveDataAPI(int ID, string Json)
        {
            





            using (WebClient client = new WebClient())
            {
                NameValueCollection postData = new NameValueCollection()
       {
              { "ID", ID.ToString() },  //order: {"parameter name", "parameter value"}
              { "Json", Json }
       };

                // client.UploadValues returns page's source as byte array (byte[])
                // so it must be transformed into a string
                string pagesource = Encoding.UTF8.GetString(client.UploadValues(urlAddress, postData));
            }

        }
    }
}
