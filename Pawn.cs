using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class Pawn: Piece
    {
        public Pawn(PieceColor color, Position pos, IMovingStrategy strategy) :
            base(color, pos, strategy)
        {
            this._type = PieceType.PAWN;
            this._cost = 1;
            
            int direction = this._color == PieceColor.WHITE ? 1 : -1;
            this._Directions = new List<(int, int)>(){(0,direction)};
        }
    }
}
