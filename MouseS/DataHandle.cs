using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseS
{
    static class DataHandle
    {
        static string path = Directory.GetCurrentDirectory() + @"\Profiles.txt";
        public static List<Profile> LoadProfiles()
        {
            List<Profile> profiles = new List<Profile>();
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
            
            
            return profiles;
        }
        public static void SaveProfiles(List<Profile> profiles)
        {

            string json = JsonConvert.SerializeObject(profiles);
            System.IO.File.WriteAllText(path, json);
        }
    }
}
