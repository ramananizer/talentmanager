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
using InfraStructure;

namespace TalentManager
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    [Export(typeof(IShellView))]
    public partial class Shell : Window,IShellView
    {
        
        public Shell()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }
        public void Display()
        {
            this.Show();
        }
        [Import]
        private IShellViewModel ViewModel
        {

            set
            {
                this.DataContext = value;
            }
        }
    }
}
