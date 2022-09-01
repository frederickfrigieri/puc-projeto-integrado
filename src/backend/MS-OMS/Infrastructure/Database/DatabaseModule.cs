using Application._Configuration.Data;
using Autofac;
using Domain;
using Domain._SeedWork;
using Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class DatabaseModule : Autofac.Module
    {
        private readonly string _databaseConnectionString;

        public DatabaseModule(string databaseConnectionString)
        {
            this._databaseConnectionString = databaseConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _databaseConnectionString)
                .InstancePerLifetimeScope();

            builder.RegisterType<Repository>()
                .As<IRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<CurrentContext>();
                    dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);

                    return new CurrentContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}