using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class BenetDecorator : IPiece
    {
        private IPiece _decorated;
        private PieceColor _color;

        public BenetDecorator(IPiece decorated)
        {
            this._decorated = decorated;
            this._color = decorated.getColor();
        }

        public PieceColor getColor()
        {
            this._color = 1 - this._color;

            return this._color;
        }

        public uint getCost()
        {
            return this._decorated.getCost();
        }

        public List<(int, int)> getDirections()
        {            
            return this._decorated.getDirections();
        }

        public IMovingStrategy getMovingStrategy()
        {
            return this._decorated.getMovingStrategy();
        }

        public PieceType getPieceType()
        {
            return this._decorated.getPieceType();
        }

        public Position getPos()
        {
            return this._decorated.getPos();
        }

        public void setPos(Position pos)
        {
            this._decorated.setPos(pos);
        }

        public override string ToString()
        {
            return this._decorated.ToString();
        }
    }
}
