using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal interface IMovingStrategy
    {
        List<Move> getValidMoves(IPiece piece);
    }
}
