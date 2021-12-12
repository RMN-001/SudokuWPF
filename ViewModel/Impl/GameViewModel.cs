using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp2.Factories;
using WpfApp2.Model;

namespace WpfApp2.ViewModel.Impl
{
     public class GameViewModel : ViewModelBase, IGameViewModel
     {
          // declaring the variables
          private readonly IBuildSudokuFactory _factory;
          private int _nehezseg;
          private List<List<Cell>> _currentMatrix;
          private int myVar;
          private int _errors = 0;
          

          // settings the getters and setters
          public int MyProperty
          {
               get { return myVar; }
               set { myVar = value; }
          }

          public int Errors
          {
               get { return _errors; }
               set
               {
                    _errors = value;
                    RaisePropertyChanged();
               }
          }
          
          public int Difficulty
          {
               get { return _nehezseg; }
               set
               {
                    _nehezseg = value;
                    RaisePropertyChanged();
               }
          }

          public List<List<Cell>> CurrentMatrix
          {
               get { return _currentMatrix; }
               set
               {
                    _currentMatrix = value;
                    RaisePropertyChanged();
               }
          }


          public ICommand GetSolutionCommand
          {
               get { return new RelayCommand(ShowResult); }
          }

          public ICommand GetCluesCommand
          {
               get { return new RelayCommand(NewGame); }
          }

          public GameViewModel(IBuildSudokuFactory factory)
          {
               _factory = factory;
          }

          private void ShowResult()
          {
               List<List<Cell>> solution = _factory.GetSolution(); //storing the full solution matrix
               for(int i = 0; i < 9; i++) //loop through the 9 rows
            {
                for(int j = 0; j < 9; j++) //loop through the 9 columns
                {
                    if(solution[i][j].Value != CurrentMatrix[i][j].Value) //check if the current cell value is different from the value in the solution
                    {
                        Errors += 1; // increase the number of errors by one
                        solution[i][j].IsError = true; //setting the iserror boolean value to true
                    } else if(!CurrentMatrix[i][j].IsClue) //checking if the current cell is not a clue
                    {
                        solution[i][j].IsClue = false;  //set the isclue boolean value to false
                    }
                }
            }
               CurrentMatrix = solution; //setting the updated solution matrix to the current matrix
              
          }

          private void NewGame()
          {
               CurrentMatrix = _factory.CreateNewGame(Difficulty);
               Errors = 0; //reset the number of errors to zero
          }
     }
}
