using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Api.Models.Responses
{
    public class CatResponseModel
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public int Score { get; set; }
    }
}
