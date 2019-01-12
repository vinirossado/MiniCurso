using Microsoft.Extensions.Configuration;
using OnStock.Integrator;
using System.IO;
using System.Text.RegularExpressions;
using Integr = OnStock.Integrator;

namespace MyHome.Services
{
    public class UploadService
    {
        private static readonly string _urlPattern = @"^http(s)://?";
        //private static readonly string _urlPattern = @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$";
        private static readonly string _extPattern = @"jpg|jpeg|png|gif|bmp|webp";

        private static OnStockIntegrator GetIntegrator()
        {
            var config = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();

            return new OnStockIntegrator(config["OnStock"]);
        }

        public static string UploadImage(string filename, string source)
        {
            if (filename != null && source != null)
            {
                var urlRegex = new Regex(_urlPattern);

                if (!urlRegex.IsMatch(source))
                {
                    var tiposRegex = new Regex(_extPattern);
                    var ext = tiposRegex.Match(source);
                    if (ext.Success)
                    {
                        var integrador = GetIntegrator();
                        var onStock = new Integr.OnStock($"{filename}.{ext}", source);
                        var retorno = integrador.Upload(onStock);
                        return retorno;
                    }
                }
            }

            return source;
        }

        public static void DeleteImage(string url)
        {
            var integrador = GetIntegrator();
            integrador.Delete(url);
        }
    }
}
