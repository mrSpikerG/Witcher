using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Witcher.Core;
using Witcher.Model;
using Witcher.Model.DBModel;

namespace Witcher.ViewModel {
    class CharacterPageViewModel : ObservableObject {
        private List<BoxWithText> pageText;
        public List<BoxWithText> PageText {
            get { return pageText; }
            set { pageText = value; this.OnPropertyChanged(nameof(pageText)); }
        }


        private PageTable table;

        public PageTable Table {
            get { return table; }
            set { table = value; this.OnPropertyChanged(nameof(Table)); }
        }



        private int CharacterId;
        private WitcherContext Database;
        public CharacterPageViewModel(WitcherContext context, int id) {
            this.Database = context;
            this.CharacterId = id;
            this.PageText = new List<BoxWithText>();
            this.Database.PageCategories
                .ToList()
                .Where(x => x.CharacterId == id)
                .ToList()
                .ForEach(x => this.Database.PageContexts
                .ToList()
                .Where(y => y.CategoryName
                .Equals(x.CategoryName))
                .ToList()
                .ForEach(y => {
                    this.PageText.Add(new BoxWithText(y.CategoryName, y.VariableContext));
                }));
            string name = this.Database.Characters.ToList().First(x => x.Id == id).Name;
            string img = this.Database.Avatars.ToList().First(x => x.CharacterId == id).PageImage;
            List<BoxWithDoubleText> boxes = new List<BoxWithDoubleText>();


            this.Database.PageTableVariables.ToList().Where(x => x.CategoryName.Equals(name)).ToList().ForEach(x => { boxes.Add(new BoxWithDoubleText(x.VariableName, x.VariableContext)); });

            this.table = new PageTable(name, img, boxes);

        }
    }
}
