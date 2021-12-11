
namespace WpfApp2.Model
{
     public class Cell
     {
          public string Value { get; set; }
          public bool IsClue { get; set; }
          public bool IsError { get; set; } // stores if the cell contains a wrong solution

          public Cell(string value, bool isClue, bool isError)
          {
               Value = value;
               IsClue = isClue;
               IsError = isError;
          }
          public Cell(string value)
          {
               Value = value;
               IsClue = true;
               IsError = false;
          }
     }
}
