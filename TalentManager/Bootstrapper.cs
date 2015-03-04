using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions;
using System.ComponentModel.Composition.Hosting;
using Microsoft.Practices.Prism.Modularity;
using System.Windows;
using InfraStructure;
using Infrastructure.Behaviour;
//using Microsoft.Practices.S
namespace TalentManager
{
    class Bootstrapper:MefBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            
            return this.Container.GetExportedValue<IShellView>() as DependencyObject;
           // this.Container.GetExportedValue<IApplicationStartUpService>().Start();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            
        }

        protected override void ConfigureAggregateCatalog()
        {
            //return base.CreateAggregateCatalog();
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(AutoPopulateExportedViewsBehavior).Assembly));
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            // When using MEF, the existing Prism ModuleCatalog is still the place to configure modules via configuration files.
            return new ConfigurationModuleCatalog();
           
        }

        protected override void InitializeShell()           
        {
            base.InitializeShell();

            //Application.Current.MainWindow = (Shell)this.Shell;
            //Application.Current.MainWindow.Show();

           
        }
        protected override void InitializeModules()
        {
            base.InitializeModules();
            this.Container.GetExportedValue<IApplicationStartUpService>().Start();
        }

        protected override Microsoft.Practices.Prism.Regions.IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var factory = base.ConfigureDefaultRegionBehaviors();
            factory.AddIfMissing("AutoPopulateExportedViewsBehavior", typeof(AutoPopulateExportedViewsBehavior));
            return factory;
        }
    }
}
