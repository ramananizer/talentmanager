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
using System.ComponentModel.Composition;
using Recruitment.ViewModel;

namespace Recruitment.Views
{
    /// <summary>
    /// Interaction logic for AddRequirementView.xaml
    /// </summary>
    /// 
    [Export("AddRequirementView")]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.Shared)]
    public partial class AddRequirementView : UserControl
    {
        public AddRequirementView()
        {
            InitializeComponent();
        }
        [Import]
        public AddRequirementViewModel viewModel
        {
            get
            {
                return this.DataContext as AddRequirementViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
