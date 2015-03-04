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

namespace ControlPanel
{
    /// <summary>
    /// Interaction logic for ControlPanelView.xaml
    /// </summary>
    /// 
    [Export("ControlPanelView")]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.Shared)]
    public partial class ControlPanelView : UserControl
    {
        public ControlPanelView()
        {
            InitializeComponent();
        }
        [Import]
        public ControlPanelViewModel ViewModel
        {
            get
            {
                return this.DataContext as ControlPanelViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
