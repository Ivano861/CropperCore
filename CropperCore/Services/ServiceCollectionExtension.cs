using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropperCore.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBlazorCropper(this IServiceCollection services)
            => services.AddScoped<CropperService>();
    }
}
