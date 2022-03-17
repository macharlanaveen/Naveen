using MasterProjectBAL.Product;
using MasterProjectCommonUtility.Configuration;
using MasterProjectCommonUtility.Logger;
using MasterProjectDAL.DataModel;
using MasterProjectDAL.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterProjectWebAPI.Helper
{
    public class ServiceRegistry
    {
        public void ConfigureDependencies(IServiceCollection services, AppsettingsConfig appSettings)
        {
            #region Bussiness Layer
            services.AddScoped<IProductService, ProductService>();
            #endregion

            #region Data Layer
            services.AddScoped<IProductRepository, ProductRepository>();
            #endregion

            #region Common Layer
            services.AddSingleton<ILoggerManager, LoggerManager>();
            #endregion
        }
        public void ConfigureDataContext(IServiceCollection services, AppsettingsConfig appSettings)
        {
            var connString = appSettings.MasterProjectData.ConnectToDb.ConnectionString;
            services.AddDbContextPool<IMasterProjectContext, MasterProjectContext>(options =>
            {
                options.UseMySQL(connString);
            }, 500);
            }
    }
}
