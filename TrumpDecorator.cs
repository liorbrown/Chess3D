using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class TrumpDecorator : IPiece
    {
        private IPiece _decorated;

        public TrumpDecorator(IPiece decorated)
        {
            this._decorated = decorated;
        }

        public PieceColor getColor()
        {
            return this._decorated.getColor();
        }

        public uint getCost()
        {
            return this._decorated.getCost() * 10;
        }

        public List<(int, int)> getDirections()
        {

            List<(int, int)> directions = new List<(int, int)>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    directions.Add((i,j));
                    directions.Add((i, -j));
                    directions.Add((-i, j));
                    directions.Add((-i, -j));
                }
            }

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
