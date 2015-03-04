using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Commands;
using Recruitment.Views;
using Microsoft.Practices.ServiceLocation;

namespace Recruitment.ViewModel
{
    [Export(typeof(AddRequirementViewModel))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.Shared)]
   public class AddRequirementViewModel
    {
        private DelegateCommand<Object> _SaveCommand;
        public DelegateCommand<Object> SaveCommand
        {
           //
            get
            {
                _SaveCommand = _SaveCommand ?? new DelegateCommand<Object>(OnSaveCommand);
                return _SaveCommand;
            }
        }

        private void OnSaveCommand(Object obj)
        {

        }

        private DelegateCommand<Object> _AddCompanyCommand;
        public DelegateCommand<Object> AddCompanyCommand
        {
            get
            {
                _AddCompanyCommand = _AddCompanyCommand ?? new DelegateCommand<Object>(OnAddCompanyCommand);
                return _AddCompanyCommand;
            }
        }

        private void OnAddCompanyCommand(Object obj)
        {
            AddCompany a = ServiceLocator.Current.GetInstance(typeof(AddCompany),"AddCompany") as AddCompany;
            a.Show();
        }
    }
}
