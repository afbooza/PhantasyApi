using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhantasyApi.Models
{
    public class ComboList
    {
        public List<Song> songs { get; set; }
        public List<Play> plays { get; set; }
    }
}
