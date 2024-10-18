using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightChoices.Models
{
    internal class PostedModel
    {
        public int Id { get; set; } = 0;
        public string posterName { get; set; }
        public string posterUsername { get; set; }
        public string posteremail { get; set; }
        public byte[] posterImage { get; set; }


        public int postId { get; set; }
        public string posttext { get; set; }
        public byte[] postimage { get; set; } 
        public byte[] postVideo { get; set; }
        public byte[] postaudio { get; set; }
        public int like { get; set; } 
        public string comment {  get; set; }
        public int share { get; set; } 




    }
}
