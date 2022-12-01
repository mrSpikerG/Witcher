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
    internal class DeleteChapterViewModel : ObservableObject {

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

        private RelayCommand deleteChapter;
        public RelayCommand DeleteChapter {
            get {
                return deleteChapter ??
                  (deleteChapter = new RelayCommand(obj => {
                      try {
                          if (this.SelectedChapter != null) {

                              using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                                  var sqlQuery = "DELETE FROM Chapters WHERE [Name] = @SelectedChapter";
                                  db.Execute(sqlQuery, new { SelectedChapter });
                              }
                              MessageBox.Show($"{this.SelectedChapter} успешно удален", "Success");
                              this.Chapters.Remove(SelectedChapter);
                          }
                      } catch (Exception ex) {
                          MessageBox.Show($"{ex.Message}", "Exception");
                      }
                  }));
            }
        }

        private WitcherContext Database;
        public DeleteChapterViewModel(WitcherContext context) {
            this.Database = context;
            this.Chapters = new List<string>();
            this.Database.Chapters.ToList().ForEach(chapt => this.Chapters.Add(chapt.Name));
        }
    }
}
