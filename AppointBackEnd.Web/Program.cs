using HotChocolate.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction())
{
    // builder.Configuration.UseKeyVault();
}

// builder.Services.AddDb(builder.Configuration);
// builder.Services.AddCoreServices();
// builder.Services.AddAuth(builder.Configuration);
// builder.Services.AddSingleton<ISessionContext, HttpSessionContext>();
// builder.Services.AddGraph();
// builder.Services.Configure<SmtpOptions>(options => builder.Configuration.GetSection(SmtpOptions.Key).Bind(options));
// builder.Services.Configure<DocParserOptions>(options => builder.Configuration.GetSection(DocParserOptions.Key).Bind(options));
builder.Services.AddHealthChecks();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapGraphQL().WithOptions(new GraphQLServerOptions
{
    Tool = { Enable = app.Environment.IsDevelopment() },
});
app.MapFallbackToFile("index.html");

// app.MapAuthEndpoints();
app.MapHealthChecks("/health");
// app.MapEnvironmentEndpoints();

app.Run();

public partial class Program
{
}