using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal interface IPiece
    {
        public uint getCost();
        public List<(int, int)> getDirections();
        public PieceColor getColor();
        public Position getPos();
        public void setPos(Position pos);
        public PieceType getPieceType();
        public IMovingStrategy getMovingStrategy();
    }
}
