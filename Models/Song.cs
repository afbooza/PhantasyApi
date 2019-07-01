using PhantasyApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhantasyApi.Models
{
    public class Song
    {
        public int Id { get; set; }
        [DataNames("name", "song")]
        public string Name { get; set; }               
        public int Score { get; set; }
    }
}
