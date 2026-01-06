using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class SarvanDecorator : IPiece
    {
        private IPiece _decorated;

        public SarvanDecorator(IPiece decorated)
        {
            this._decorated = decorated;
        }

        public PieceColor getColor()
        {
            return this._decorated.getColor();
        }

        public uint getCost()
        {
            return 0;
        }

        public List<(int, int)> getDirections()
        {
            List<(int, int)> directions = this._decorated.getDirections();
            directions.Add((0, 0));

            return directions;
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
