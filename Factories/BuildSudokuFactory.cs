using System;
using System.Collections.Generic;
using System.Linq;
using WpfApp2.Model;

namespace WpfApp2.Factories
{
     public class BuildSudokuFactory : IBuildSudokuFactory
     {    
          // declaration of variations
          private List<int>[] _row;
          private List<int>[] _collumn;
          private List<int>[] _threeSquare ;
          private readonly Random _random = new Random();
          
          // declaring the solution and clues lists
          private List<List<Cell>> _solution;
          private List<List<Cell>> _clues;
        
          // creating the new game based on the difficulty level
          public List<List<Cell>> CreateNewGame(int difficulty)
          {
               CreateSolutions();
               _clues = initializeResultMatrix();
               for (int y = 0; y <= 8; y++)
               {    
                    List<int> cells = new List<int>(new int[] { 1, 2, 3 , 4, 5 , 6, 7, 8, 9 }); // create and list the solutions
                    for (int c = 1; c <= 9 - (5 - difficulty); c++) // based on the difficulty, reduce the created number's cells...
                    {
                         int randomNumber = cells[_random.Next(0, cells.Count())]; // ...with a random number generator...
                         cells.Remove(randomNumber); // ...then remove the randomed number
                    }

                    // if the cell isn't removed, we place value on it, else, we insert an empty string
                    for (int x = 0; x <= 8; x++)
                    {
                         if (cells.Contains(x + 1))
                         {
                              _clues[y][x] = new Cell(_solution[y][x].Value.ToString(), true, false);
                         }
                         else
                         {
                              _clues[y][x] = new Cell("", false, false);
                         }
                    }
               }
               return _clues;
          }

          public List<List<Cell>> GetSolution()
          {
               return _solution;
          }
            
          // this is a mathematical method, that we use to create solutions
          private int CurrentMatrix(int x, int y)
          {
               return (y / 3) * 3 + (x / 3);
          }

          private void InitializeLists()
          {
               // declaring the row, "collumn", threeSquare, and the solution numbers
               _row = new List<int>[9];
               _collumn = new List<int>[9];
               _threeSquare = new List<int>[9];
               _solution = new List<List<Cell>>();
               
               // adding numbers to the row's list, collumn's list, threesquare's list, and also in the solution's list
               for (int x = 0; x <= 8; x++)
               {
                    _row[x] = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                    _collumn[x] = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                    _threeSquare[x] = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                    _solution.Add(new List<Cell>());
               }
          }

          // create and print blank fields
          private List<List<Cell>> initializeResultMatrix()
          {
               _clues = new List<List<Cell>>(); // create the blank fields list
               for (int i = 0; i < 9; i++)
               {
                    _clues.Add(new List<Cell>()); // add the index to the list
                    for (int j = 0; j < 9; j++)
                    {
                         _clues[i].Add(new Cell("",false,false)); // based on the index, add an empty value string
                    }
               }
               Kiiratas(_clues);
               return _clues;
          }
          
          // filling up the 9x9 matrix with values between 1-9
          // if a column or row got the value, it'
          private void CreateSolutions()
          {
               while (true)
               {
               break1:
                    InitializeLists(); // fill list with values
                    for (int y = 0; y <= 8; y++)
                    {
                         for (int x = 0; x <= 8; x++)
                         {
                              int si = CurrentMatrix(x, y); // the mathematical matirx is used here
                              int[] useful = _row[y].Intersect(_collumn[x]).Intersect(_threeSquare[si]).ToArray(); // the "useful" array contains the numbers which are corresponds to the mathematical matrix 
                              if (useful.Count() == 0) // if the useful numbers are reached 0 index, a new filling circle will start
                              { 
                                   goto break1;
                              }
                              int randomNumber = useful[_random.Next(0, useful.Count())]; // a random number generator make the values
                              _row[y].Remove(randomNumber); // if the order is incorrect, remove from row
                              _collumn[x].Remove(randomNumber); // if the order is incorrect, remove from column
                              _threeSquare[si].Remove(randomNumber); // if the order is incorrect, remove from the threesquare
                              _solution[y].Add(new Cell(randomNumber.ToString())); // adding the generated random number, to the next cell
                              if (y == 8 & x == 8) // after the maximum "y" and "x" indexes are reached, the values will be written out
                              {
                                   goto break2;
                              }
                         }
                    }
               }
          break2: Console.WriteLine();
          }

          // print out the numbers in the matrix
          private void Kiiratas(List<List<Cell>> matrix)
          {
               for (int i = 0; i < matrix.Count(); i++)
               {
                    for (int j = 0; j < matrix[i].Count(); j++)
                    {
                         Console.Write(matrix[i][j].Value);
                    }
                    Console.WriteLine();
               }
          }


     }
}
