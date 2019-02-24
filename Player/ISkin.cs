using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player
{
    public interface ISkin
    {
        void Clear();

        void Render(string text);
    }
}
