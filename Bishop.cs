using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class Bishop : Piece
    {
        public Bishop(PieceColor color, Position pos, IMovingStrategy strategy) : 
            base(color, pos, strategy)
        {
            this._type = PieceType.BISHOP;
            this._cost = 3;
            this._Directions = new List<(int, int)>()
            {
                (1,-1), (1,1), (-1,-1), (-1,1)
            };
        }
    }
}
