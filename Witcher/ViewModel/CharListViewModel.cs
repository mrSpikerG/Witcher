using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Witcher.Core;
using Witcher.Model;
using Witcher.Model.DBModel;
using Witcher.View;

namespace Witcher.ViewModel {
    class CharListViewModel : ObservableObject {
        private string chapter;
        public string Chapter {
            get { return chapter; }
            set { chapter = value; this.OnPropertyChanged(nameof(Chapter)); }
        }

        private PreviewInfo selectedPreview;
        public PreviewInfo SelectedPreview {
            get { return selectedPreview; }
            set { selectedPreview = value; }
        }

        private List<PreviewInfo> previewInfo;
        public List<PreviewInfo> Preview {
            get { return previewInfo; }
            set { previewInfo = value; }
        }

        private RelayCommand openCharacter;
        public RelayCommand OpenCharacter {
            get {
                return openCharacter ??
                  (openCharacter = new RelayCommand(obj => {
                      if (this.SelectedPreview != null) {
                          CharacterPageWindow table = new CharacterPageWindow(this.Database,SelectedPreview.Id);
                          table.Show();
                          
                      }
                  }));
            }

        }


        private WitcherContext Database;
        public CharListViewModel(string chapter, WitcherContext context) {
            this.Chapter = chapter;
            this.Database = context;
            this.Preview = new List<PreviewInfo>();


           
            this.Database.CharactersChapters.ToList()
                .Where(x => x.ChapterId == this.Database.Chapters.ToList().First(x => x.Name.Equals(chapter)).Id)
                .ToList()
                .ForEach(x => {
                    Character charact = this.Database.Characters.ToList().Where(y => y.Id == x.CharacterId).First();
                    this.Preview.Add(new PreviewInfo(charact.Name, charact.Id, context));
                });


        }
    }
}
