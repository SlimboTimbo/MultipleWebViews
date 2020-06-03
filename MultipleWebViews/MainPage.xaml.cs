using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using MultipleWebViews.ViewModels;

using System.Collections.ObjectModel;

namespace MultipleWebViews
{

    public partial class MainPage : ContentPage
    {

        public ObservableCollection<PageViewModel> pages { get; set; }

        public MainPage()
        {

            InitializeComponent();

            pages = new ObservableCollection<PageViewModel>();
            pages.Add(new PageViewModel { Id = "1", Name = "Test 1" });
            pages.Add(new PageViewModel { Id = "2", Name = "Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 " });
            pages.Add(new PageViewModel { Id = "3", Name = "Test 3" });
            pages.Add(new PageViewModel { Id = "4", Name = "Test 4 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2" });

            lstView.ItemsSource = pages;
        }
    }
}
