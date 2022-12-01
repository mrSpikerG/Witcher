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
    internal class DeleteCharacterViewModel : ObservableObject {


        private string characterName;

        public string CharacterName {
            get { return characterName; }
            set { characterName = value; this.OnPropertyChanged(nameof(CharacterName)); }
        }

        private RelayCommand deleteCharacter;
        public RelayCommand DeleteCharacter {
            get {
                return deleteCharacter ??
                  (deleteCharacter = new RelayCommand(obj => {
                      try {
                          if (CharacterName == null)
                              return;

                          int id = this.Database.Characters.First(x => x.Name.Equals(this.CharacterName)).Id;

                          using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                              var sqlQuery = "DELETE FROM CharactersChapter WHERE [CharacterId] = @id";
                              db.Execute(sqlQuery, new { id });
                          }

                          using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                              var sqlQuery = "DELETE FROM PageTableVariables WHERE [CategoryName] = @CharacterName";
                              db.Execute(sqlQuery, new { CharacterName });
                          }

                          using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                              var sqlQuery = "DELETE FROM Avatars WHERE [CharacterId] = @id";
                              db.Execute(sqlQuery, new { id });
                          }

                          this.Database.PageCategories.Where(x => x.CharacterId == id).ToList().ForEach(x => {

                              string category = x.CategoryName;
                              using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                                  var sqlQuery = "DELETE FROM PageContext WHERE [CategoryName] = @category";
                                  db.Execute(sqlQuery, new { category });
                              }
                          });

                          using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                              var sqlQuery = "DELETE FROM PageCategories WHERE [CharacterId] = @id";
                              db.Execute(sqlQuery, new { id });
                          }

                          using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                              var sqlQuery = "DELETE FROM Characters WHERE [Id] = @id";
                              db.Execute(sqlQuery, new { id });
                          }

                          MessageBox.Show($"{this.CharacterName} успешно удалён", "Success");
                          this.CharacterName = null;
                      } catch (Exception ex) {
                          MessageBox.Show($"{ex.Message}", "Exception");
                      }
                  }));
            }
        }


        private WitcherContext Database;
        public DeleteCharacterViewModel(WitcherContext context) {
            this.Database = context;
            this.CharacterName = "CharacterName";
        }
    }
}
