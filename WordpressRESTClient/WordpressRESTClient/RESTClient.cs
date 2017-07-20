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

        public RESTClient(string host)
        {
            HostName = host;
        }

        public async Task<List<Category>> GetAllCategories(int limit = 0)
        {
            List<Category> categories = new List<Category>();
            string url = HostName + "/wp-json/wp/v2/categories";
            if (limit != 0)
                url = url + "?per_page=" + limit;
            HttpClient client = new HttpClient();
            var getAsync = await client.GetStringAsync(url);
            string categoriesString = getAsync.ToString();
            categories = JsonConvert.DeserializeObject<List<Category>>(categoriesString);
            return categories;
        }

        public async Task<List<Post>> GetAllPosts(int limit = 0)
        {
            List<Post> posts = new List<Post>();
            string url = HostName + "/wp-json/wp/v2/posts";
            if (limit != 0)
                url = url + "?per_page=" + limit;
            HttpClient client = new HttpClient();
            var getAsync = await client.GetStringAsync(url);
            string postsString = getAsync.ToString();
            posts = JsonConvert.DeserializeObject<List<Post>>(postsString);
            return posts;
        }

        public async Task<List<Post>> GetPostsByCategoryId(int id, int limit = 0)
        {
            List<Post> posts = new List<Post>();
            string url = HostName + "/wp-json/wp/v2/posts?categories=" + id;
            if (limit != 0)
                url = url + "&per_page=" + limit;
            HttpClient client = new HttpClient();
            var getAsync = await client.GetStringAsync(url);
            string postsString = getAsync.ToString();
            posts = JsonConvert.DeserializeObject<List<Post>>(postsString);
            return posts;
        }


        public async Task<Media> GetFeaturedImageById(int id)
        {
            Media media = new Media();
            string url = HostName + "/wp-json/wp/v2/media/" + id;
            HttpClient client = new HttpClient();
            var getAsync = await client.GetStringAsync(url);
            string mediaString = getAsync.ToString();
            media = JsonConvert.DeserializeObject<Media>(mediaString);
            return media;
        }
    }

}