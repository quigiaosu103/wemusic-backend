namespace wemusic
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000") // Add the origin of your React app
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Other configurations
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    // Production environment configurations
                }

                app.UseRouting();

                // Apply CORS before the endpoints
                app.UseCors("AllowReactApp");

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    // Other endpoint mappings
                });
        }
    }
}
