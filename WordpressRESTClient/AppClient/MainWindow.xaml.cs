using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WordpressAPI;
using WordpressAPI.Model;



namespace AppClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static string hostName = "http://amdavadblogs.apps-1and1.com";
        RESTClient client = new RESTClient(hostName);
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void CategoriesCaller_Click(object sender, RoutedEventArgs e)
        {
            int limit = 0;
            if (!String.IsNullOrEmpty(LimitText.Text))
                limit = Convert.ToInt32(LimitText.Text);
            List<Category> resp = await client.GetAllCategories(limit);
            ListCategories.ItemsSource = resp;
        }

        private async void PostsCaller_Click(object sender, RoutedEventArgs e)
        {
            int limit = 0;
            if (!String.IsNullOrEmpty(LimitText.Text))
                limit = Convert.ToInt32(LimitText.Text);
            List<Post> resp = await client.GetAllPosts(limit);
            ListPosts.ItemsSource = resp;
        }

        private async void PostsByCategory_Click(object sender, RoutedEventArgs e)
        {
            int categoryId = Convert.ToInt32(textCategoryId.Text);
            int limit = 0;
            if (!String.IsNullOrEmpty(LimitText.Text))
                limit = Convert.ToInt32(LimitText.Text);
            List<Post> resp = await client.GetPostsByCategoryId(categoryId, limit);
            ListPosts.ItemsSource = resp;
        }
    
        private async void MediaById_Click(object sender, RoutedEventArgs e)
        {
            int Media = Convert.ToInt32(textMediaId.Text);
            Media resp = await client.GetFeaturedImageById(Media);
            textFeaturedMedia.Text = "FeaturedMediaURL : " + resp.media_details.sizes.medium.source_url.ToString();
            FeaturedImage.Source = new BitmapImage(new Uri(resp.media_details.sizes.medium.source_url.ToString()));
        }
    }
}
