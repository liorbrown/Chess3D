using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal abstract class Piece: IPiece
    {
        protected PieceType _type;
        protected PieceColor _color;
        private Position _pos;
        private IMovingStrategy _strategy;
        protected List<(int, int)> _Directions;
        protected uint _cost;

        protected Piece(PieceColor color, Position pos, IMovingStrategy strategy)
        {
            this._color = color;
            this._pos = pos;
            this._strategy = strategy;
        }

        public PieceType getPieceType() { return this._type; }
        public PieceColor getColor() { return this._color; }
        public Position getPos() { return this._pos; }
        public uint getCost() { return this._cost; }
        public IMovingStrategy getMovingStrategy() { return this._strategy; }
        public List<(int, int)> getDirections() { return this._Directions; }
        public void setPos(Position newPos) { this._pos = newPos; }

        public override string ToString()
        {
            return this._type + " in " + this._pos;
        }
    }
}
