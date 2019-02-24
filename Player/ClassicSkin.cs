using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player
{
    public class ClassicSkin : ISkin
    {
        public  void Clear()
        {
            Console.Clear();
        }

        public  void Render(string text)
        {
            Console.WriteLine(text);
        }
    }
}
