using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Witcher.Core;
using WitcherServer.Model;
using WitcherServer.View;

namespace WitcherServer.ViewModel {
    internal class MainViewModel :ObservableObject{


        private RelayCommand? openChapterCreator;
        public RelayCommand? OpenChapterCreator {
            get {
                return openChapterCreator ??
                  (openChapterCreator = new RelayCommand(obj => {
                    CreateChapterWindow window = new CreateChapterWindow(this.Database);
                      window.Show();
                  }));
            }
        }

        private RelayCommand? openChapterRemover;
        public RelayCommand? OpenChapterRemover {
            get {
                return openChapterRemover ??
                  (openChapterRemover = new RelayCommand(obj => {
                      DeleteChapterWindow window = new DeleteChapterWindow(this.Database);
                      window.Show();
                  }));
            }
        }

        private RelayCommand? openCharacterCreator;
        public RelayCommand? OpenCharacterCreator {
            get {
                return openCharacterCreator ??
                  (openCharacterCreator = new RelayCommand(obj => {
                      CreateCharacterWindow window = new CreateCharacterWindow(this.Database);
                      window.Show();
                  }));
            }
        }

        private RelayCommand? openConnectionRemover;
        public RelayCommand? OpenConnectionRemover {
            get {
                return openConnectionRemover ??
                  (openConnectionRemover = new RelayCommand(obj => {

                      DeleteConnectionCharToChap window = new DeleteConnectionCharToChap();
                      window.Show();
                  }));
            }
        }

        private RelayCommand? openConnectionCreator;
        public RelayCommand? OpenConnectionCreator {
            get {
                return openConnectionCreator ??
                  (openConnectionCreator = new RelayCommand(obj => {
                      CreateConnectionCharToChap window = new CreateConnectionCharToChap();
                      window.Show();
                  }));
            }
        }

        private RelayCommand? openCharacterRemover;
        public RelayCommand? OpenCharacterRemover {
            get {
                return openCharacterRemover ??
                  (openCharacterRemover = new RelayCommand(obj => {
                      DeleteCharacterWindow window = new DeleteCharacterWindow(this.Database);
                      window.Show();
                  }));
            }
        }

        private RelayCommand? openPageTableCreator;
        public RelayCommand? OpenPageTableCreator {
            get {
                return openPageTableCreator ??
                  (openPageTableCreator = new RelayCommand(obj => {
                      CreatePageTableWindow window = new CreatePageTableWindow();
                      window.Show();
                  }));
            }
        }

        private RelayCommand? openPageTableRemover;
        public RelayCommand? OpenPageTableRemover {
            get {
                return openPageTableRemover ??
                  (openPageTableRemover = new RelayCommand(obj => {
                      RemoveTableDescribeWindow window = new RemoveTableDescribeWindow();
                      window.Show();
                  }));
            }
        }

        private WitcherContext Database;
        public MainViewModel() {
            this.Database = new WitcherContext();
        }
    }
}
