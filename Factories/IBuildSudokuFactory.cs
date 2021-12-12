using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Model;

namespace WpfApp2.Factories
{
     public interface IBuildSudokuFactory
     {
          // calling the functions through the interface
          List<List<Cell>> CreateNewGame(int difficulty);
          List<List<Cell>> GetSolution();
     }
}
