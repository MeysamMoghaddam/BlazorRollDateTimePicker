using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollDateTimePicker
{
    public static class RegisterDIService
    {
        public static IServiceCollection AddRollDate(this IServiceCollection services)
        {
            services.AddScoped<IDateTimePickerJsInterop, DateTimePickerJsInterop>();
            return services;
        }
    }
}
