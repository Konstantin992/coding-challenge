using MHP.CodingChallenge.Backend.Dependency.Inquiry;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MHP.CodingChallenge.Backend.Dependency.Notifications;

namespace MHP.CodingChallenge.Backend.Dependency
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<InquiryService>();

            services.AddMediatR(typeof(EmailHandler));
            services.AddMediatR(typeof(PushNotificationHandler));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}
