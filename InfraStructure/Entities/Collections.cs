using InfraStructure.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace InfraStructure.Entities
{
    public static class Globals
    {
        private static ObservableCollection<Requirement> _AllRequirements;
        public static ObservableCollection<Requirement> AllRequirements
        {
            get
            {
                _AllRequirements = _AllRequirements ?? new ObservableCollection<Requirement>();
                return _AllRequirements;
            }
        }

        private static ObservableCollection<Company> allCompanies;
        public static ObservableCollection<Company> AllCompanies
        {
            get
            {
                allCompanies = allCompanies ?? new ObservableCollection<Company>();
                return allCompanies;
            }
        }
    }
}