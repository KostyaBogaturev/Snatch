namespace snatch
{
    using System;
    using System.Threading
    using System.Threading.Tasks;
    using HtmlAgilityPack;
    using System.Collections.Generic;
    using Helper;
    using System.Linq;

    public class Program
    {
        private const string privatCourseJson = "https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5";
        private const string minFinCourse = "https://minfin.com.ua/currency/auction/usd/buy/kharkov/";

        public static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        private static async Task RunAsync()
        {
            var client = new HttpClientWrapper();
            List<PrivateRate> privat = await client.GetAsync<List<PrivateRate>>(privatCourseJson);
            PrivateRate curent = privat.Where(w=>w.Ccy=="USD"&&w.Base_ccy=="UAH").FirstOrDefault();
            var allCurency = await client.GetAsync(minFinCourse);
            var document = new HtmlDocument();
            document.LoadHtml(allCurency);
            var buyUsd = document.DocumentNode.SelectNodes("//*[@id=\"exchanges-page-container\"]" +
                "/div[1]/div[1]/div[3]/div/div/div[1]/span/text()").FirstOrDefault();
            var saleUsd = document.DocumentNode.SelectNodes("//*[@id=\"exchanges-page-container\"]" +
                "/div[1]/div[1]/div[3]/div/div/div[2]/span/text()").FirstOrDefault();
            if (curent.Buy > double.Parse(saleUsd.InnerHtml) || curent.Sale < double.Parse(buyUsd.InnerHtml))
                Console.WriteLine("Пора грабить караваны");
        }
    }
}
