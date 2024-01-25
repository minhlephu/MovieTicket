using Microsoft.EntityFrameworkCore;
using Movie.INFARSTRUTURE;
using Movie.SERVICES.Interfaces.IRepositories;
using Movie.SERVICES.Interfaces;
using Movie.SERVICES.Repositories;
using MovieApi.Extensions.Mappers;

namespace MovieApi.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICinemaRepository, CinemaRepository>();

            services.AddAutoMapper(typeof(UserMapper).Assembly);
            return services;
        }
    }
}
