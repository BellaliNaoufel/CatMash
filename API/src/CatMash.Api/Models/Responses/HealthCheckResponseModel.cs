using CatMash.Api.HealthChecks;
using System;
using System.Collections.Generic;

namespace CatMash.Api.Models.Responses
{
    public class HealthCheckResponseModel
    {
        public string Status { get; set; }

        public IEnumerable<HealthCheck> Checks { get; set; }

        public TimeSpan Duration { get; set; }
    }
}