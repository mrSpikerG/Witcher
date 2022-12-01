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
    internal class ConnectionCharToChapViewModel : ObservableObject {


        private string? chapterId;
        public string? ChapterId {
            get { return chapterId; }
            set { chapterId = value; this.OnPropertyChanged(nameof(ChapterId)); }
        }

        private string? characterId;

        public string? CharacterId {
            get { return characterId; }
            set { characterId = value; this.OnPropertyChanged(nameof(CharacterId)); }
        }


        private RelayCommand createChapter;
        public RelayCommand CreateChapter {
            get {
                return createChapter ??
                  (createChapter = new RelayCommand(obj => {
                      try {
                          if (ChapterId == null)
                              return;
                          if (CharacterId == null)
                              return;

                          if (this.Connection == ConnectionType.Create) {
                              using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                                  var sqlQuery = "INSERT INTO CharactersChapter ([ChapterId], [CharacterId]) VALUES(@ChapterId,@CharacterId)";
                                  db.Execute(sqlQuery, new { ChapterId, CharacterId });
                              }
                              MessageBox.Show($"{ChapterId} и {CharacterId} успешно связаны", "Success");
                          } else {
                              using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                                  var sqlQuery = "DELETE FROM CharactersChapter WHERE [ChapterId] = @ChapterId AND [CharacterId] = @CharacterId";
                                  db.Execute(sqlQuery, new { ChapterId, CharacterId });
                              }
                              MessageBox.Show($"{ChapterId} и {CharacterId} успешно отвязаны", "Success");
                          }
                          this.ChapterId = null;
                          this.CharacterId = null;
                      } catch (Exception ex) {
                          MessageBox.Show($"{ex.Message}", "Exception");
                      }
                  }));
            }
        }

        private ConnectionType Connection;
        public ConnectionCharToChapViewModel(ConnectionType connectionType) {
            this.Connection = connectionType;
            this.CharacterId = "CharacterId";
            this.ChapterId = "ChapterId";
        }
    }
    enum ConnectionType {
        Create,
        Delete
    }
}
