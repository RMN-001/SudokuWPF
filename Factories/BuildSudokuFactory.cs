using System;
using System.Collections.Generic;
using System.Linq;
using WpfApp2.Model;

namespace WpfApp2.Factories
{
     public class BuildSudokuFactory : IBuildSudokuFactory
     {
          private List<int>[] _row;
          private List<int>[] _collumn;
          private List<int>[] _threeSquare ;
          private readonly Random _random = new Random();

          private List<List<Cell>> _solution;
          private List<List<Cell>> _clues;

          public List<List<Cell>> CreateNewGame(int difficulty)
          {
               CreateSolutions();
               _clues = initializeResultMatrix();
               for (int y = 0; y <= 8; y++)
               {
                    List<int> cells = new List<int>(new int[] { 1, 2, 3 , 4, 5 , 6, 7, 8, 9 });
                    for (int c = 1; c <= 9 - (5 - difficulty); c++)
                    {
                         int randomNumber = cells[_random.Next(0, cells.Count())];
                         cells.Remove(randomNumber);
                    }
                    for (int x = 0; x <= 8; x++)
                    {
                         if (cells.Contains(x + 1))
                         {
                              _clues[y][x] = new Cell(_solution[y][x].Value.ToString(), true);
                         }
                         else
                         {
                              _clues[y][x] = new Cell("", false);
                         }
                    }
               }
               return _clues;
          }

          public List<List<Cell>> GetSolution()
          {
               return _solution;
          }

          private int CurrentMatrix(int x, int y)
          {
               return (y / 3) * 3 + (x / 3);
          }
          private void InitializeLists()
          {
               _row = new List<int>[9];
               _collumn = new List<int>[9];
               _threeSquare = new List<int>[9];
               _solution = new List<List<Cell>>();

               for (int x = 0; x <= 8; x++)
               {
                    _row[x] = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                    _collumn[x] = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                    _threeSquare[x] = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                    _solution.Add(new List<Cell>());
               }
          }
          private List<List<Cell>> initializeResultMatrix()
          {
               _clues = new List<List<Cell>>();
               for (int i = 0; i < 9; i++)
               {
                    _clues.Add(new List<Cell>());
                    for (int j = 0; j < 9; j++)
                    {
                         _clues[i].Add(new Cell("",false));
                    }
               }
               Kiiratas(_clues);
               return _clues;
          }
          private void CreateSolutions()
          {
               while (true)
               {
               break1:
                    InitializeLists();
                    for (int y = 0; y <= 8; y++)
                    {
                         for (int x = 0; x <= 8; x++)
                         {
                              int si = CurrentMatrix(x, y);
                              int[] useful = _row[y].Intersect(_collumn[x]).Intersect(_threeSquare[si]).ToArray();
                              if (useful.Count() == 0)
                              {
                                   //kiiratas();
                                   goto break1;
                              }
                              int randomNumber = useful[_random.Next(0, useful.Count())];
                              _row[y].Remove(randomNumber);
                              _collumn[x].Remove(randomNumber);
                              _threeSquare[si].Remove(randomNumber);
                              _solution[y].Add(new Cell(randomNumber.ToString()));
                              if (y == 8 & x == 8)
                              {
                                   goto break2;
                              }
                         }
                    }
               }
          break2: Console.WriteLine();
          }
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
