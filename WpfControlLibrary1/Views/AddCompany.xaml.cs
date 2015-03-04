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
using System.Windows.Shapes;
using System.ComponentModel.Composition;
using Recruitment.ViewModel;

namespace Recruitment.Views
{
    /// <summary>
    /// Interaction logic for AddCompany.xaml
    /// </summary>
    /// 
    [Export("AddCompany")]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public partial class AddCompany : Window
    {
        public AddCompany()
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(AddCompany_Closing);
        }

        void AddCompany_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //throw new NotImplementedException();
           // e.Cancel = true;
        }
        [Import]
        public AddCompanyViewModel viewModel
        {
            get
            {
                return this.DataContext as AddCompanyViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
