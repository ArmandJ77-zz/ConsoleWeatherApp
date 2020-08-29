using System.Drawing;
using System.Linq;
using Colorful;

namespace Domain.Utilities
{
    public static class TextUtilities
    {
        public static void DisplayMenuText(string headLine, string[] options)
        {
            Console.WriteLine(headLine, Console.ForegroundColor = Color.Chartreuse);

            var styleSheet = new StyleSheet(Color.White);
            styleSheet.AddStyle("[0-9]*", Color.Red);

            for (var i = 0; i < options.Count(); i++)
            {
                Console.WriteLineStyled($"{i + 1}.  {options[i]}", styleSheet);
            }
        }
    }
}
