using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class RuleEngine
    {
        public RuleEngine() { }

        private bool isKingWillBeAimed(Move move)
        {
            return false;
        }

        private void addPieceValidMoves(List<Move> moves, IPiece piece)
        {
            List<Move> pieceMoves = piece.getMovingStrategy().getValidMoves(piece);

            foreach (Move move in pieceMoves)
            {
                if (!isKingWillBeAimed(move)) { moves.Add(move); }
            }
        }

        public List<Move> getAllValidMoves(PieceColor color)
        {
            List<Move> moves = new List<Move>();
            List<IPiece> pieces = Board.getInstance().getPieces(color);

            foreach (IPiece piece in pieces) { this.addPieceValidMoves(moves, piece);}

            return moves;
        }
    }
}
