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
using WitcherServer.Models.DBModel;

namespace WitcherServer.ViewModel {
    internal class CreateChapterViewModel {


        private string? chapterName;

        public string? ChapterName {
            get { return chapterName; }
            set { chapterName = value; }
        }


        private RelayCommand createChapter;
        public RelayCommand CreateChapter {
            get {
                return createChapter ??
                  (createChapter = new RelayCommand(obj => {
                      if (ChapterName != null) {
                          try {
                              using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                                  var sqlQuery = "INSERT INTO Chapters ([Name]) VALUES(@ChapterName)";
                                  db.Execute(sqlQuery, new { ChapterName });
                              }
                              MessageBox.Show($"{ChapterName} успешно добавлен", "Success");
                              this.ChapterName = null;
                          } catch (Exception ex) {
                              MessageBox.Show($"{ex.Message}", "Exception");
                          }
                      }
                  }));
            }
        }
        private WitcherContext? Database;
        public CreateChapterViewModel(WitcherContext? context) {
            this.Database = context;
            this.ChapterName = "ChapterName";
        }
    }
}
