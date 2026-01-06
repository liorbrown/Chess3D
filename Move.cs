using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class Move
    {
        private IPiece _movedPiece;
        private Position _newPos;
        private IPiece? _eliminated;

        public Move(IPiece movedPiece, Position newPos, IPiece? eliminated)
        {
            this._movedPiece = movedPiece;
            this._newPos = newPos;
            this._eliminated = eliminated;
        }

        public IPiece getMovedPiece() { return this._movedPiece; }
        public Position getNewPos() { return this._newPos; }
        public IPiece? getEliminated() { return this._eliminated; }
        public override string ToString()
        {
            return this._movedPiece + " to " + this._newPos ;
        }
    }
}
