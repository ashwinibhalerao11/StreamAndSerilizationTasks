using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamAndSerilizationTask
{
    [Serializable]
    public class SerilizeProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int price { get; set; }
    }
}
