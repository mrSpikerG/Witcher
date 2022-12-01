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
    internal class DeletePageTableViewModel {

        private string characterName;
        public string CharacterName {
            get { return characterName; }
            set { characterName = value; }
        }

       

        private string variableName;
        public string VariableName {
            get { return variableName; }
            set { variableName = value; }
        }

        private RelayCommand removePageTable;
        public RelayCommand RemovePageTable {
            get {
                return removePageTable ??
                  (removePageTable = new RelayCommand(obj => {
                      if (CharacterName == null)
                          return;

                      try {
                          using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                              var sqlQuery = "DELETE FROM PageTableVariables WHERE [CategoryName] = @CharacterName AND [VariableName] = @VariableName";
                              db.Execute(sqlQuery, new { CharacterName, VariableName });
                          }
                          MessageBox.Show($"Титул {CharacterName}'а успешно удален", "Success");
                          this.CharacterName = null;
                      } catch (Exception ex) {
                          MessageBox.Show($"{ex.Message}", "Exception");
                      }

                  }));
            }
        }

        public DeletePageTableViewModel() {
            this.CharacterName = "CharacterName";
            this.VariableName = "VariableName";
        }
    }
}
