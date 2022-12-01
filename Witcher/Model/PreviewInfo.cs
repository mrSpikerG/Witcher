using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Witcher.Model
{
    class PreviewInfo
    {
        public string  Name { get; set; }
        public string AvatarURI { get; set; }
        public int Id { get; set; }

        public PreviewInfo(string name, string avatarURI) {
            Name = name;
            AvatarURI = avatarURI;  
        }

        public PreviewInfo(string name, int id, WitcherContext context) : this(name, context.Avatars.ToList().First(x => x.CharacterId == id).PreviewImage){
            this.Id = id;    
        }

        public override string ToString() {
            return this.Name;
        }
    }
}
