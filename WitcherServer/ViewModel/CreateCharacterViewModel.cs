using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Witcher.Core;
using WitcherServer.Model;

namespace WitcherServer.ViewModel {
    internal class CreateCharacterViewModel : ObservableObject {
        private string name;
        public string Name {
            get { return name; }
            set { name = value; this.OnPropertyChanged("Name"); }
        }

        private string? previewIMG;
        public string? PreviewIMG {
            get { return previewIMG; }
            set { previewIMG = value; this.OnPropertyChanged("PreviewIMG"); }
        }

        private string? pageIMG;
        public string? PageIMG {
            get { return pageIMG; }
            set { pageIMG = value; this.OnPropertyChanged("PageIMG"); }
        }

        private string chapterId;

        public string ChapterId {
            get { return chapterId; }
            set { chapterId = value; this.OnPropertyChanged("ChapterId"); }
        }

        private RelayCommand createChapter;
        public RelayCommand CreateChapter {
            get {
                return createChapter ??
                  (createChapter = new RelayCommand(obj => {
                      try {
                          if (this.Name == null)
                              return;
                          if (this.ChapterId == null)
                              return;
                          if (this.PreviewIMG == null)
                              return;
                          if (this.PageIMG == null)
                              return;


                          using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                              var sqlQuery = "INSERT INTO Characters ([Name]) VALUES(@Name)";
                              db.Execute(sqlQuery, new { this.Name });
                          }

                          int id = this.Database.Characters.First(x => x.Name.Equals(this.Name)).Id;

                          using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                              var sqlQuery = "INSERT INTO CharactersChapter ([CharacterId],[ChapterId]) VALUES(@id,@ChapterId)";
                              db.Execute(sqlQuery, new { id, this.ChapterId });
                          }

                          using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                              var sqlQuery = "INSERT INTO Avatars ([CharacterId],[PageImage],[PreviewImage]) VALUES(@id,@ChapterId,@PreviewIMG)";
                              db.Execute(sqlQuery, new { id, this.ChapterId, this.PreviewIMG });
                          }

                          MessageBox.Show($"{Name} успешно добавлен", "Success");
                      } catch (Exception ex) {
                          MessageBox.Show($"{ex.Message}", "Exception");
                      }
                  }
                  ));
            }
        }

        private WitcherContext Database;
        public CreateCharacterViewModel(WitcherContext context) {
            this.Database = context;
            this.PageIMG = "PageIMG";
            this.PreviewIMG = "PreviewIMG";
            this.Name = "Name";
            this.ChapterId = "ChapterID";
        }


    }
}
