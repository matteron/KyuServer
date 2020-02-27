using System;
using System.Collections.Generic;

namespace KyuApi.Business.ViewModels.Requests
{
    public class EntryRequest
    {
	    public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Type { get; set; }
        public List<int> Tags { get; set; }
    }
}