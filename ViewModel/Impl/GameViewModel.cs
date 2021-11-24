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
          private readonly IBuildSudokuFactory _factory;
          private int _nehezseg;
          private List<List<Cell>> _currentMatrix;
          private int myVar;

          public int MyProperty
          {
               get { return myVar; }
               set { myVar = value; }
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
               CurrentMatrix = _factory.GetSolution();
          }

          private void NewGame()
          {
               CurrentMatrix = _factory.CreateNewGame(Difficulty);
          }
     }
}
