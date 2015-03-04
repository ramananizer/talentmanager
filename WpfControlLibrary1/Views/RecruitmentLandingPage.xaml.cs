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

namespace Recruitment.Views
{
    /// <summary>
    /// Interaction logic for RecruitmentLandingPage.xaml
    /// </summary>
    /// 
    [Export("RecruitmentLandingPage")]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class RecruitmentLandingPage : UserControl
    {
        public RecruitmentLandingPage()
        {
            InitializeComponent();
        }
    }
}
