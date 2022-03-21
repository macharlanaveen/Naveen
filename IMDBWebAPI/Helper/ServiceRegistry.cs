using IMDBBAL.Actor;
using IMDBBAL.Movie;
using IMDBBAL.Producer;
using IMDBDAL.ActorRepo;
using IMDBDAL.DataModel;
using IMDBDAL.MovieRepo;
using IMDBDAL.ProducerRepo;
using MasterProjectCommonUtility.Configuration;
using MasterProjectCommonUtility.Logger;
using MasterProjectDAL.DataModel;
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
            services.AddScoped<IProducerService, ProducerService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IActorService, ActorService>();
            #endregion

            #region Data Layer
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            #endregion

            #region Common Layer
            services.AddSingleton<ILoggerManager, LoggerManager>();
            #endregion
        }
        public void ConfigureDataContext(IServiceCollection services, AppsettingsConfig appSettings)
        {
            var connString = appSettings.MasterProjectData.ConnectToDb.ConnectionString;
            services.AddDbContextPool<InaveendbContext, naveendbContext>(options =>
            {
                options.UseMySQL(connString);
            }, 500);
            }
    }
}
