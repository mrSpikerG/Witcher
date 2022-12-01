using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows;
using Witcher.Core;
using WitcherServer.Model;

namespace WitcherServer.ViewModel {
    internal class CreatePageTableViewModel {


        private string characterName;
        public string CharacterName {
            get { return characterName; }
            set { characterName = value; }
        }

        private string variableContext;
        public string VariableContext {
            get { return variableContext; }
            set { variableContext = value; }
        }

        private string variableName;
        public string VariableName {
            get { return variableName; }
            set { variableName = value; }
        }



        private RelayCommand createChapter;
        public RelayCommand CreateChapter {
            get {
                return createChapter ??
                  (createChapter = new RelayCommand(obj => {
                      if (CharacterName == null)
                          return;
                      if (VariableContext == null)
                          return;
                      if (variableName == null)
                          return;


                      try {
                          using (IDbConnection db = new SqlConnection(Settings.Connection)) {
                              var sqlQuery = "INSERT INTO PageTableVariables ([CategoryName],[VariableName],[VariableContext]) VALUES(@CharacterName,@VariableName,@VariableContext)";
                              db.Execute(sqlQuery, new { CharacterName, VariableName, VariableContext });
                          }
                          MessageBox.Show($"Титул {CharacterName}'а успешно добавлен", "Success");
                          this.CharacterName = null;
                      } catch (Exception ex) {
                          MessageBox.Show($"{ex.Message}", "Exception");
                      }

                  }));
            }
        }

        public CreatePageTableViewModel() {
            this.VariableContext = "VariableContext";
            this.VariableName = "VariableName";
            this.CharacterName = "CharacterName";
        }
    }
}
