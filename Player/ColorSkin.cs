using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player
{
    public class ColorSkin : ISkin
    {
        private ConsoleColor _color;

        public ColorSkin()
        {
            var random = new Random();
            var color = random.Next(0, 15);

            _color = (ConsoleColor)color;
        }

        public ColorSkin(ConsoleColor color)
        {
            _color = color;
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Render(string text)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine(text);
        }
    }
}
