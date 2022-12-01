using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Witcher.Model {
    internal class BoxWithText {
        public string Parent { get; set; }
        public string Text { get; set; }

        public BoxWithText(string parent, string text) {
            Parent = parent;
            this.Text = text;
        }
    }
}
