using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WordpressAPI.Model;

namespace WordpressAPI
{
    public class RESTClient
    {

        private string hostName;

        public string HostName
        {
            get { return hostName; }
            set { hostName = value; }
        }
        
        public  RESTClient(string host)
        {
            HostName = host;
        }
        
        public async Task<List<Category>> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            string path = HostName + "/wp-json/wp/v2/categories";
            HttpClient client = new HttpClient();
            var getAsync =  await client.GetStringAsync(path);
            string categoriesString = getAsync.ToString();
            categories = JsonConvert.DeserializeObject<List<Category>>(categoriesString);
            return categories;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            List<Post> posts = new List<Post>();
            string url = HostName + "/wp-json/wp/v2/posts";
            HttpClient client = new HttpClient();
            var getAsync = await client.GetStringAsync(url);
            string postsString = getAsync.ToString();
            posts = JsonConvert.DeserializeObject<List<Post>>(postsString);
            return posts;
        }
    }
}
