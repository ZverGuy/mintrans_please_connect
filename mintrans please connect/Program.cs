using System;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace mintrans_please_connect
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }

        public static async Task MainAsync(string[] args)
        {
            try
            {
                var outputFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Usage.png");
                var fileInfo = new FileInfo(outputFile);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                using var browserFetcher = new BrowserFetcher();
                await browserFetcher.DownloadAsync();
                await using var browser = await Puppeteer.LaunchAsync(
                    new LaunchOptions { Headless = true });
                await using var page = await browser.NewPageAsync();
                await page.GoToAsync("https://mtrans.rk.gov.ru/ru/structure/opendata_9102011880_forma1");
                await Task.Delay(TimeSpan.FromSeconds(45));
                await page.ScreenshotAsync(outputFile);
                Console.WriteLine($"ОНО СКРИНШОТНУЛОСЬ, файл в {outputFile}");
            }
            catch (Exception e)
            {
                Console.WriteLine("ДА НЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕТ");
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}