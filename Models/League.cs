using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PhantasyApi.Models
{
    public class League
    {
        [DataMember(Name = "league_id")]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
