using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class Board
    {
        public const int HIGHT = 3;
        private static Board _instance;
        private List<IPiece?[,]> _3Dgrid;
        private List<IPiece> _pieces;
        private Dictionary<PieceColor, IPiece> _kings;

        private Board() 
        {
            this._3Dgrid = new List<IPiece?[,]>();

            for (int i = 0; i < Board.HIGHT; i++)
            {
                this._3Dgrid.Add(new IPiece?[8,8]);
            }

            this._pieces = new List<IPiece>();
            this._kings = new Dictionary<PieceColor, IPiece>();

            placePieces(PieceColor.WHITE);
            placePieces(PieceColor.BLACK);
        }

        private IPiece placePiece(PieceType type, PieceColor color, Position pos)
        {
            IPiece newPiece = PiecesFactory.getInstance().CreatePiece(type, color, pos);

            this._3Dgrid.ElementAt(pos.getHight())[pos.getFile(), pos.getRank()] =
                newPiece;

            this._pieces.Add(newPiece);

            return newPiece;
        }

        private void placePieces(PieceColor color)
        {           
            int hight;
            int PiecesRank;
            int PawnsRank;

            if (color == PieceColor.WHITE)
            {
                hight = 0;
                PiecesRank = 0;
                PawnsRank = 1;
            }
            else
            {
                hight = Board.HIGHT - 1;
                PiecesRank = 7;
                PawnsRank = 6;
            }

            placePiece(PieceType.ROOK, color, new Position(hight, 0, PiecesRank));
            placePiece(PieceType.ROOK, color, new Position(hight, 7, PiecesRank));

            placePiece(PieceType.KNIGHT, color, new Position(hight, 1, PiecesRank));
            placePiece(PieceType.KNIGHT, color, new Position(hight, 6, PiecesRank));

            placePiece(PieceType.BISHOP, color, new Position(hight, 2, PiecesRank));
            placePiece(PieceType.BISHOP, color, new Position(hight, 5, PiecesRank));

            placePiece(PieceType.QUEEN, color, new Position(hight, 3, PiecesRank));
            this._kings[color] =
                placePiece(PieceType.KING, color, new Position(hight, 4, PiecesRank));

            for (int i = 0; i < 8; i++)
            {
                placePiece(PieceType.PAWN, color, new Position(hight, i, PawnsRank));               
            }
        }

        public static Board getInstance()
        {
            if (Board._instance == null)
                Board._instance = new Board();

            return Board._instance;
        }

        public IPiece? getPieceAt(Position position)
        {
            return (this._3Dgrid.ElementAt(
                position.getHight())[position.getFile(), position.getRank()]);
        }

        public List<IPiece> getPieces(PieceColor color)
        {
            return this._pieces.FindAll(p => p.getColor() == color);
        }

        private void eliminatePiece(IPiece eliminatedPiece)
        {
            Position eliminatedPos = eliminatedPiece.getPos();

            this._3Dgrid.ElementAt(eliminatedPos.getHight())
                [eliminatedPos.getFile(), eliminatedPos.getRank()] = null;

            this._pieces.Remove(eliminatedPiece);
        }

        public void applyMove(Move move)
        {
            IPiece movedPiece = move.getMovedPiece();
            IPiece? eliminatedPiece = move.getEliminated();
            Position currentPos = movedPiece.getPos();
            
            Position newPos = move.getNewPos();

            this._3Dgrid.ElementAt(currentPos.getHight())
                [currentPos.getFile(), currentPos.getRank()] = null;

            if (eliminatedPiece != null) { this.eliminatePiece(eliminatedPiece); }

            this._3Dgrid.ElementAt(newPos.getHight())
                [newPos.getFile(), newPos.getRank()] = movedPiece;

            movedPiece.setPos(newPos);
        }

        public Position getKingPos(PieceColor color)
        {
            return this._kings[color].getPos();
        }

        public void Promote(IPiece piece, PieceType type)
        {
            this.eliminatePiece(piece);

            this.placePiece(type, piece.getColor(), piece.getPos());
        }
    }
}
