using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class Knight: Piece
    {
        public Knight(PieceColor color, Position pos, IMovingStrategy strategy) :
            base(color, pos, strategy)
        {
            this._type = PieceType.KNIGHT;
            this._cost = 3;
            this._Directions = new List<(int, int)>()
            {
                (2,-1), (2,1), (-2, -1), (-2,1), (1,-2), (1,2), (-1,-2), (-1,2)
            };
        }
    }
}
