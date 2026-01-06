using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class GameManager
    {
        private RuleEngine _engine;
        private static GameManager _instance;
        private PieceColor _currentTurn;

        private GameManager()
        {
            this._engine = new RuleEngine();
            this._currentTurn = PieceColor.WHITE;
        }

        public static GameManager getInstance()
        {
            if (GameManager._instance == null)
            {
                GameManager._instance = new GameManager();
            }

            return GameManager._instance;
        }

        private void handlePromotion(Move move)
        {
            IPiece movedPiece = move.getMovedPiece();
            Position newPos = move.getNewPos();

            if (movedPiece.getPieceType() == PieceType.PAWN &&
                (newPos.getRank() == 0) || (newPos.getRank() == 7))
            {
                PieceType type = getPromotionFromUser();
                Board.getInstance().Promote(movedPiece, type);
            }
        }

        public GameResult Play()
        {
            Console.WriteLine("========== Welcome to 3D chess ===========");
            while (true)
            {
                Console.WriteLine("*** " + this._currentTurn + " Turn ***");

                if (this.isKingAimed(this._currentTurn))
                {
                    Console.WriteLine("You are under check!");
                }

                List<Move> moves = this._engine.getAllValidMoves(this._currentTurn);

                if (moves.Count == 0)
                {
                    if (isKingAimed(this._currentTurn))
                        return (this._currentTurn == PieceColor.WHITE ?
                            GameResult.BLACK_WINS : GameResult.WHITE_WINS);

                    return (GameResult.DRAW);
                }

                Move selectedMove = getMoveFromUser(moves);

                Board.getInstance().applyMove(selectedMove);
                
                this.handlePromotion(selectedMove);

                this._currentTurn = getOpponent();

                calcTotalCost();
            }
        }

        private void calcTotalCost()
        {          
            List<IPiece> whitePieces = Board.getInstance().getPieces(PieceColor.WHITE);
            List<IPiece> BlackPieces = Board.getInstance().getPieces(PieceColor.BLACK);

            long whiteCost = whitePieces.Sum(p => p.getCost());
            long blackCost = BlackPieces.Sum(p => p.getCost());

            Console.WriteLine("White total cost is: " + whiteCost);
            Console.WriteLine("Black total cost is: " + blackCost);
        }

        private PieceType getPromotionFromUser()
        {
            Console.WriteLine("What you want to propmote to:");
            int counter = 1;

            foreach (String type in Enum.GetNames<PieceType>() )
            {
                Console.WriteLine(counter++ + ") " + type);
            }

            int choose = int.Parse(Console.ReadLine());

            return ((PieceType)choose - 1);
        }

        private PieceColor getOpponent()
        {
            return (1 - this._currentTurn);
        }

        private Move getMoveFromUser(List<Move> moves)
        {
            int counter = 1;
            Console.WriteLine("Please choose move:");

            foreach (Move move in moves)
            {
                Console.WriteLine(counter++ + ") " + move);
            }

            int choose = int.Parse(Console.ReadLine());

            return (moves.ElementAt(choose - 1));
        }

        private bool isKingAimed(PieceColor currentTurn)
        {
            List<Move> opponentMoves = this._engine.getAllValidMoves(this.getOpponent());
            Position kingPos = Board.getInstance().getKingPos(this._currentTurn);

            return opponentMoves.Exists(m => m.getNewPos().Equals(kingPos));
        }
    }
}
