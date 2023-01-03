using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaibBook.Models.ViewModel
{
    public class WriterVM
    {
        public Writer Writer { get; set; } = new Writer();
        public IEnumerable<Writer> Writers { get; set;} = new List<Writer>();
    }
}
