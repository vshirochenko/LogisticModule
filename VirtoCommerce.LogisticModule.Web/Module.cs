﻿using GoogleMaps.LocationServices;
using Microsoft.Practices.Unity;
using VirtoCommerce.Domain.Commerce.Services;
using VirtoCommerce.InventoryModule.Data.Repositories;
using VirtoCommerce.LogisticModule.Data.Services;
using VirtoCommerce.Platform.Core.Modularity;

namespace LogisticModule
{
    public class Module : ModuleBase
    {
        // private const string _connectionStringName = "VirtoCommerce";
        private readonly IUnityContainer _container;

        public Module(IUnityContainer container)
        {
            _container = container;
        }

        public override void SetupDatabase()
        {
            // Modify database schema with EF migrations
            // using (var context = new PricingRepositoryImpl(_connectionStringName))
            // {
            //     var initializer = new SetupDatabaseInitializer<MyRepository, Data.Migrations.Configuration>();
            //     initializer.InitializeDatabase(context);
            // }
        }

        public override void Initialize()
        {
            _container.RegisterType<ILocationService, GoogleLocationService>(new InjectionConstructor());
            _container.RegisterType<ILogisticService, LogisticServiceImpl>();
        }

        public override void PostInitialize()
        {
            base.PostInitialize();

            // This method is called for each installed module on the second stage of initialization.

            // Register implementations 
            // _container.RegisterType<IMyService, MyService>();

            // Resolve registered implementations:
            // var settingManager = _container.Resolve<ISettingsManager>();
            // var value = settingManager.GetValue("Pricing.ExportImport.Description", string.Empty);
        }
    }
}
