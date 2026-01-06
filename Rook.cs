using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class Rook : Piece
    {
        public Rook(PieceColor color, Position pos, IMovingStrategy strategy) :
            base(color, pos, strategy)
        {
            this._type = PieceType.ROOK;
            this._cost = 5;
            this._Directions = new List<(int, int)>()
            {
                (0,-1), (0,1), (-1,0), (-1,0)
            };
        }
    }
}
