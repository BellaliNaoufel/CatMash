using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Api.Models.Requests
{
    public class CatRequestModel
    {
        public string Url { get; set; }
        public int Score { get; set; }
    }
}
