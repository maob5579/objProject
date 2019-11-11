using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Text;

namespace MockWcfClient.Models
{
    public class UserServiceClient
    {
        private string BASE_URL = "http://localhost:58375/Services/UserService.svc/";
        public List<User> GetAllUsers()
        {
            try
            {
                var webclient = new WebClient();
                var json = webclient.DownloadString(BASE_URL + "GetAllUsers");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<User>>(json);
            }
            catch
            {
                return null;
            }
        }

        public User GetUserById(string UserId)
        {
            try
            {
                var webclient = new WebClient();
                string url = string.Format(BASE_URL + "GetUserById/{0}", UserId);
                var json = webclient.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<User>(json);
            }
            catch
            {
                return null;
            }
        }

        public bool Create(User user)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(User));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, user);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "Create", "POST", data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(User user)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(User));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, user);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "Edit", "PUT", data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(User user)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(User));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, user);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "Delete", "DELETE", data);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}