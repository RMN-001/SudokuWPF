
namespace WpfApp2.Model
{
     public class Cell
     {
          public string Value { get; set; }
          public bool IsClue { get; set; }

          public Cell(string value, bool isClue)
          {
               Value = value;
               IsClue = isClue;
          }
          public Cell(string value)
          {
               Value = value;
               IsClue = true;
          }
     }
}
