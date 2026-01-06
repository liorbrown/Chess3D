using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class FixedMovingStrategy: IMovingStrategy
    {
        private void addMove(List<Move> moves, IPiece piece, Position newPos)
        {
            IPiece? destPiece = Board.getInstance().getPieceAt(newPos);
            
            if (destPiece == null || 
                destPiece.getColor() != piece.getColor() || 
                destPiece == piece)
            {
                moves.Add(new Move(piece, newPos, destPiece));
            }
        }

        public List<Move> getValidMoves(IPiece piece)
        {
            List<Move> moves = new List<Move>();

            List<(int, int)> directions = piece.getDirections();
            Position currentPos = piece.getPos();

            foreach((int, int) direction in directions)
            {
                Position newPos = new Position(
                    currentPos.getHight(), 
                    currentPos.getFile() + direction.Item1,
                    currentPos.getRank() + direction.Item2);

                if (newPos.getFile() < 0 || newPos.getFile() > 7 ||
                    newPos.getRank() < 0 || newPos.getRank() > 7)
                { continue;}

                addMove(moves, piece, newPos);

                if (currentPos.getHight() > 0)
                {
                    addMove(
                        moves, 
                        piece, 
                        new Position(
                            currentPos.getHight()  - 1,
                            newPos.getFile(),
                            newPos.getRank()));
                }

                if (currentPos.getHight() < Board.HIGHT - 1)
                {
                    addMove(
                        moves,
                        piece,
                        new Position(
                            currentPos.getHight() + 1,
                            newPos.getFile(),
                            newPos.getRank()));
                }
            }

            return moves;
        }
    }
}
