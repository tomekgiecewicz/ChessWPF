using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_wpf
{
    class Board
    {
        private MyPoint _upperLeftCorner;
        private chessPieces[,] piecesOnBoard = new chessPieces[8, 8];

        public Board(MyPoint upperLeftCorner)
        {
            _upperLeftCorner = upperLeftCorner;

            piecesOnBoard[0, 6] = chessPieces.WhitePawn;
            piecesOnBoard[1, 6] = chessPieces.WhitePawn;
            piecesOnBoard[2, 6] = chessPieces.WhitePawn;
            piecesOnBoard[3, 6] = chessPieces.WhitePawn;
            piecesOnBoard[4, 6] = chessPieces.WhitePawn;
            piecesOnBoard[5, 6] = chessPieces.WhitePawn;
            piecesOnBoard[6, 6] = chessPieces.WhitePawn;
            piecesOnBoard[7, 6] = chessPieces.WhitePawn;
        }

        public MyPoint getPositionXY (MyPoint posInPixels)
        {
            MyPoint position = new MyPoint();

            if ((posInPixels.X < _upperLeftCorner.X) || (posInPixels.X > (_upperLeftCorner.X + 640)) 
                || (posInPixels.Y < _upperLeftCorner.Y) || (posInPixels.Y > (_upperLeftCorner.Y + 640)))
            {
                return new MyPoint(-1, -1);
            }

            position.X = Convert.ToInt32((posInPixels.X - _upperLeftCorner.X) / 80);
            position.Y = Convert.ToInt32((posInPixels.Y - _upperLeftCorner.Y) / 80);

            return position;
        }

        public chessPieces whatPieceAtPos(MyPoint boardPos)
        {
            if ((boardPos.X < 0) || (boardPos.X > 7) || (boardPos.Y < 0) || (boardPos.Y > 7))
            {
                return chessPieces.None;
            }

            return piecesOnBoard[boardPos.X, boardPos.Y];
        }
    }
}
