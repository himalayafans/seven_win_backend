﻿using PetaPoco.Providers;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Application.Options;

namespace SevenWinBackend.Data
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly SettingOptions OptionSettings;

        public UnitOfWorkFactory(SettingOptions optionSettings)
        {
            OptionSettings = optionSettings ?? throw new ArgumentNullException(nameof(optionSettings));
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(CreateDatabase());
        }

        internal PetaPoco.IDatabase CreateDatabase()
        {
            var db = DatabaseConfiguration.Build()
                    .UsingConnectionString(this.OptionSettings.ConnectionString)
                    .UsingProvider<PostgreSQLDatabaseProvider>()
                    .UsingDefaultMapper<ConventionMapper>(m =>
                    {
                        m.InflectTableName = (inflector, tn) => inflector.Underscore(tn);
                        m.InflectColumnName = (inflector, cn) => inflector.Underscore(cn);
                        m.IsPrimaryKeyAutoIncrement = (inflector) => false;
                    })
                    .Create();
            return db;
        }
    }
}
