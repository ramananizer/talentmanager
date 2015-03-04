using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using System.ComponentModel.Composition;
using InfraStructure;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition.Hosting;
using Microsoft.Practices.ServiceLocation;
using System.Collections;
using Recruitment.Views;
using System.Windows;

namespace Recruitment
{
  [ModuleExport(typeof(Recruitment))]
   public class Recruitment:IModule
    {
         private CompositionContainer container=null;
        
        [ImportingConstructor]
         public Recruitment(ICommandObject cmd)
         {
             cmdObject = cmd;
             cmdObject.Command = new DelegateCommand<Object>(OnRecruitmentCommand);
             cmd.CommandName = "Recruitment";
             // ;
         }

         private void OnRecruitmentCommand(Object obj)
         {

             Uri viewNav = new Uri("RecruitmentLandingPage", UriKind.Relative);
             regionManager.RequestNavigate("MainRegion", viewNav);
         }
        public void Initialize()
        {
            ShellViewModel.NavigationItems.Add(cmdObject);

            ModuleSection section = new ModuleSection();
            section.SectionHeader = "Recruitment";

           


            ICommandObject cmdObject1 = ServiceLocator.Current.GetInstance<ICommandObject>();    //container.GetExportedValue<ICommandObject>();
            cmdObject1.CommandName = "Add Candidate";

            ICommandObject cmdObject2 = ServiceLocator.Current.GetInstance<ICommandObject>(); //container.GetExportedValue<ICommandObject>();
            cmdObject2.CommandName = "Add Skill";

            ICommandObject cmdObject3 = ServiceLocator.Current.GetInstance<ICommandObject>(); //container.GetExportedValue<ICommandObject>();
            cmdObject3.CommandName = "Add Company";
            cmdObject3.Command = new DelegateCommand<Object>(OnAddCompany);

            ICommandObject cmdObject4 = ServiceLocator.Current.GetInstance<ICommandObject>(); //container.GetExportedValue<ICommandObject>();
            cmdObject4.CommandName = "Add Requirement";
            cmdObject4.Command = new DelegateCommand<Object>(OnAddRequirement);

            ICommandObject cmdObject5 = ServiceLocator.Current.GetInstance<ICommandObject>(); //container.GetExportedValue<ICommandObject>();
            cmdObject5.CommandName = "All Companies";
            cmdObject5.Command = new DelegateCommand<Object>(OnAllCompaniesCommand);

            section.SectionItems.Add(cmdObject1);
            section.SectionItems.Add(cmdObject2);
            section.SectionItems.Add(cmdObject3);
            //section.SectionItems.Add(cmdObject2);
            section.SectionItems.Add(cmdObject4);
            section.SectionItems.Add(cmdObject5);
           // MSections.Add(section);
           // ShellViewModel.Sections.Add(section);
          IList l=  ServiceLocator.Current.GetInstance(typeof(Object), "Sections") as IList;
          l.Add(section);
        }

        [Import]
        private IRegionManager regionManager;
        [Import]
        private IShellViewModel ShellViewModel;
        private ICommandObject cmdObject;

        private List<ModuleSection> _MSections;
        public List<ModuleSection> MSections
        {
            get
            {
                _MSections = _MSections ?? new List<ModuleSection>();
                return _MSections;
            }
        }

        private void OnAddRequirement(Object obj)
        {
            AddRequirementView view = ServiceLocator.Current.GetInstance(typeof(Object), "AddRequirementView") as AddRequirementView; ;
            Window wnd = new Window();
            wnd.Content = view;
            wnd.Show();
        }

        private void OnAddCompany(Object obj)
        {
            AddCompany view =  ServiceLocator.Current.GetInstance(typeof(Object), "AddCompany") as AddCompany;
            view.WindowStyle = WindowStyle.ThreeDBorderWindow;
            view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            view.Owner = Shell as Window;
            view.ShowDialog();
        }

        private void OnAllCompaniesCommand(Object obj)
        {
            
        }

        [Import]
        private IShellView Shell;
    }
}
