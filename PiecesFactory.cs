using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class PiecesFactory
    {
        private static PiecesFactory? _instance;

        private PiecesFactory() {}

        public static PiecesFactory getInstance()
        {
            if (PiecesFactory._instance == null)
            {
                PiecesFactory._instance = new PiecesFactory();
            }

            return PiecesFactory._instance;
        }

        public IPiece CreatePiece(PieceType type, PieceColor color, Position bornPos)
        {
            IPiece newPiece = null;

            switch (type)
            {
                case PieceType.PAWN:
                    newPiece = new Pawn(color, bornPos, new PawnMoveStrategy());

                    break;

                case PieceType.ROOK:
                    
                    newPiece = new Rook(color, bornPos, new SlidingStrategy());

                    break;

                case PieceType.KNIGHT:
                    newPiece = new SarvanDecorator(new Knight(color, bornPos, new FixedMovingStrategy()));

                    break;

                case PieceType.BISHOP:
                    newPiece = new BenetDecorator(new Bishop(color, bornPos, new SlidingStrategy()));

                    break;

                case PieceType.QUEEN:
                    newPiece = new Queen(color, bornPos, new SlidingStrategy());

                    break;

                case PieceType.KING:
                    newPiece = new King(color, bornPos, new FixedMovingStrategy());

                    break;
            }

            return newPiece;
        }
    }
}
