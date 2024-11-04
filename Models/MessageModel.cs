using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightChoices.Models
{
    internal class MessageModel
    {
        public int Id { get; set; }
        public string Messages { get; set; }
        public string Titles { get; set; }
        public string Messanger { get; set; }
        public string MessageOwner {  get; set; }

        public byte[] MessangerImage { get; set; }
        public byte[] MessageOwnImage { get; set; }
        public DateTime date { get; set; } = DateTime.Now;

    }
}
