using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreWebApp.Models
{
    public class ResponseModel
    {
        public Pagination pagination { get; set; }
        public StockViewModel data = new StockViewModel();
    }
    public class Pagination
    {
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public int total { get; set; }
    }

    public class StockViewModel
    {
        [JsonProperty(PropertyName = "adj_close")]
        public string close { get; set; }
        [JsonProperty(PropertyName = "symbol")]
        public string ticker { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string dateTime { get; set; }
        [JsonProperty(PropertyName = "adj_volume")]
        public string volume { get; set; }
    }
