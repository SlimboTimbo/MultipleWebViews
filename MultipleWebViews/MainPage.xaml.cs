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
            pages.Add(new PageViewModel { Id = "1", Name = "<div style='border: 1px solid #000;'><p style='margin: 0px;'>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p><div class='message-buttons'><a class='btn btn-true' data-data='{}' data-answerid='69d9c98c-0001-0001-0001-202002251317'><p>True</p></a><a class='btn btn-false btn-selected' data-data='{}' data-answerid='69d9c98c-0001-0001-0002-202002251317'><p>False</p></a></div></div>" });

            pages.Add(new PageViewModel { Id = "2", Name = "Vivamus id urna erat" });
            pages.Add(new PageViewModel { Id = "3", Name = "<div style='border: 1px solid #000;' data-foruser='9663cd86247747ddc5ca07aa263e63a687520cfd069ab8d06ed0dee26ed65bff' data-identifier='e07f7d60-e75c-4b00-a595-92fe7b75ccf8' data-placeholder='Selection' data-required='true' data-advice='false' data-type='text' data-data='{' isallowwhitespace':false, 'isfirstinflow':true, 'isrequired':true }'=' data-questionaireid='69d9c98c-0000-0000-0000-202002251317' data-questionid='69d9c98c-0001-0001-0000-202002251317'><div><p>Aenean sed ultricies turpis , et rutrum odio.</p><div class='message-buttons buttons-icons btns-disabled'><a class='btn btn-true' data-data='{}' data-answerid='69d9c98c-0001-0001-0001-202002251317'><p>True</p></a><a class='btn btn-false btn-selected' data-data='{}' data-answerid='69d9c98c-0001-0001-0002-202002251317'><p>False</p></a></div></div></div>" });
            pages.Add(new PageViewModel { Id = "4", Name = "<div style='border: 1px solid #000;'><div><p style='margin: 0px;'>Test 1</p></div></div>" }); ;
            pages.Add(new PageViewModel { Id = "5", Name = "Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 " });
            pages.Add(new PageViewModel { Id = "6", Name = "Test 3" });
            pages.Add(new PageViewModel { Id = "7", Name = "Test 4 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2 Test 2" });

            lstView.ItemsSource = pages;
        }
    }
}
