using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Witcher.Core;
using Witcher.Model;
using Witcher.View;

namespace Witcher.ViewModel {
    class MainViewModel : ObservableObject {

        private string exitImageLink;
        public string ExitImage {
            get { return exitImageLink; }
            set { exitImageLink = value; this.OnPropertyChanged(nameof(ExitImage)); }
        }

        private string selectedChapter;

        public string SelectedChapter {
            get { return selectedChapter; }
            set { selectedChapter = value; this.OnPropertyChanged(nameof(SelectedChapter)); }
        }

        private List<string> chapters;
        public List<string> Chapters {
            get { return chapters; }
            set { chapters = value; this.OnPropertyChanged("Chapters"); }
        }


        private WitcherContext Database;
        public MainViewModel() {
            this.Database = new WitcherContext();
            this.Chapters = new List<string>();
            this.Database.Chapters.ToList().ForEach(chapt => this.Chapters.Add(chapt.Name));
            
            this.ExitImage = "https://i.imgur.com/j3bYV11.png";
        }

        private RelayCommand openChapter;

        public RelayCommand OpenChapter {
            get { 
                return openChapter ??
                  (openChapter = new RelayCommand(obj => {
                      if (this.SelectedChapter != null) {
                          CharacterListWindow window = new CharacterListWindow(this.SelectedChapter,this.Database);
                          window.Show();
                      }
                  })); 
            }
        }


        public void changeSource(bool isHovered) {
            if (isHovered) {
                this.ExitImage = "https://i.imgur.com/KRWVMiQ.png";
                return;
            }
            this.ExitImage = "https://i.imgur.com/j3bYV11.png";
        }
    }
}
