using AspNetCoreWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace AspNetCoreWebApp.Controllers
{
    public class DataDownloader : IDataDownloader
    {
        public DataDownloader()
        {
        }

        public List<StockViewModel> GetData()
        {
            string url = "http://api.marketstack.com/v1/eod/latest?access_key={0}&symbols={1}";

            // Choose any tickers you want
            List<string> tickers = new List<string> { "MSFT", "IBM", "AAPL" };

            // This holds all the data
            List<StockViewModel> objList = new List<StockViewModel>();

            using (WebClient wc = new WebClient())
            {
                // Loop through all ticker symbols
                foreach (var item in tickers)
                {
                    string currUrl = String.Format(url, apiKey, item);
                    var json = wc.DownloadString(currUrl);
                    Console.WriteLine(json);

                    dynamic parsedData =  JsonConvert.DeserializeObject(json);
                    dynamic d1 = parsedData.data;
                    DateTime date = DateTime.Parse(d1[0].date.ToString());
                    double closeprice = Convert.ToDouble(d1[0].adj_close.ToString());
                    double volume = Convert.ToDouble(d1[0].volume.ToString());
                    // We have our data. Add it to the list
                    objList.Add(new StockViewModel { dateTime = date.ToShortDateString(),
                        ticker = item,
                        close = closeprice.ToString(),
                        volume = volume.ToString() });
                }
            }
            return objList;
        }
        private void OnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            // Useful later if we get large downloads
        }
        private string apiKey = "555b83f8eb321725d34deaa9967299b8";
    }
}
