using BookStoreApi.Services;
using Newtonsoft.Json;
using System.Diagnostics;//timer mekanizması için 
using System.Net;

namespace BookStoreApi.Middlewares
{
    public class CustomExceptionMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew(); //Bu bir izleme açar
            try
            {
                
                string message = "[Request] HTTP " + context.Request.Method + "-" + context.Request.Path;
                _loggerService.Write(message);
                await _next(context);//Bundan öncesi requesti çağırdığın zaman çalışır Burdan sonrası Response döndükten sonra çalışır


                watch.Stop();
                message = "[Response] HTTP " + context.Request.Method + "-" + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms ";
                _loggerService.Write(message);//Bunu bu şekilde kullanarak konsol bağımlılığını kaldırmış olduk
                //Logları göstermek istediğim yere göre servisler oluşturup
                //program.cs de onlar arasından seçim yaparak kullanabilirim. 
            }
            catch (Exception ex)
            {

                //şimdi sen validatorlardan bir hata aldın diyelim
                //bu durumda await satırında kod kırılacak yani senin saatin durmayacak
                //yada sen response alamayacaksın bu yüzden ilk saati durdur
                watch.Stop();
                await HandleExeption(context, ex, watch); //validatorden dönen msjlar için


            }

        }

        private Task HandleExeption(HttpContext context, Exception ex, Stopwatch watch)
        {
            string message = "[Error]  HTTP " + context.Request.Method + "-" + context.Response.StatusCode + "Error Message : " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms " ;
            _loggerService.Write(message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(new {error = ex.Message}, Formatting.None);

            return context.Response.WriteAsync(result);

        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder) 
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
