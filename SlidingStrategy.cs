using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class SlidingStrategy : IMovingStrategy
    {
        public List<Move> getValidMoves(IPiece piece)
        {
            return new List<Move>();
        }
    }
}
