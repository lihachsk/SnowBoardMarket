using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowBoardMarket.Models
{
    public class SnowboardModel
    {
        public long Id { get; set; }

        public long CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public string Cpu { get; set; }

        public string Camera { get; set; }

        public string Size { get; set; }

        public string Weight { get; set; }

        public string Display { get; set; }

        public string Battery { get; set; }

        public string Memory { get; set; }
    }
}
