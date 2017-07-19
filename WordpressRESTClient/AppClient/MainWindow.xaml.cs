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
            List<Category> resp = await client.GetAllCategories();
            ListCategories.ItemsSource = resp;
        }

        private async void PostsCaller_Click(object sender, RoutedEventArgs e)
        {
            List<Post> resp = await client.GetAllPosts();
            //ListPosts.ItemsSource = resp;

        }
    }
}
