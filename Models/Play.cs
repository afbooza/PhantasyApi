using PhantasyApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhantasyApi.Models
{
    public class Play
    {
        public int Id { get; set; }
        [DataNames("location", "location")]
        public string Location { get; set; }
        [DataNames("date", "date")]
        public DateTime Date { get; set; }

    }
}
