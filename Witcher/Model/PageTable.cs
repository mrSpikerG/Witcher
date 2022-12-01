using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Witcher.Model {
    internal class PageTable {
        public string? Name { get; set; }
        public string? Avatar { get; set; }
       
        public List<BoxWithDoubleText> Boxes { get; set; }

        public PageTable(string name, string avatar, List<BoxWithDoubleText> boxes) {
            this.Name = name;
            this.Avatar = avatar;
          
            this.Boxes = boxes;
        }
    }
}
