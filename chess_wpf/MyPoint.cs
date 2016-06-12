using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_wpf
{
    class MyPoint
    {
        public int X;
        public int Y;

        public MyPoint()
        {
        }

        public MyPoint(int posX, int posY)
        {
            X = posX;
            Y = posY;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", X, Y);
        }
    }
}
