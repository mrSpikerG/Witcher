using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Witcher.Model {
    internal class BoxWithDoubleText {

        public string? BoxName { get; set; }
        public string? BoxValue { get; set; }

        public BoxWithDoubleText( string? boxName, string? boxValue) {
            BoxName = boxName;
            BoxValue = boxValue;    
        }
    }
}
