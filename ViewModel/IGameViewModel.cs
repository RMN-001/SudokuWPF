using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp2.Model;

namespace WpfApp2.ViewModel
{
     // settings the getters and setters in the interface
     public interface IGameViewModel
     {
          ICommand GetSolutionCommand { get; }
          ICommand GetCluesCommand { get; }
          List<List<Cell>> CurrentMatrix { get; set; }
          int Difficulty { get; set; }
     }
}
