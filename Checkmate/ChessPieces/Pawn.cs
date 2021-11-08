using System.Drawing;

namespace Checkmate.ChessPieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(PieceColor pieceColor) : base(pieceColor)
        {
            PieceImage = pieceColor == PieceColor.BLACK ? Properties.Resources.BPawn : Properties.Resources.WPawn;
        }

        public override void ShowLegalMoves(ChessBoard board, Point location)
        {
            
            base.ShowLegalMoves(board,location);
            

            // Legal moves for white pawns and black pawns
            if (pieceColor == PieceColor.WHITE)
            {
                if (isSafe(location.X - 1, location.Y))
                    board.board[location.X - 1, location.Y].IsLegal = true;

                if (isSafe(location.X - 2, location.Y))
                    board.board[location.X - 2, location.Y].IsLegal = true;
            }
            // else
            // {
            //     if (isSafe(location.X + 1, location.Y))
            //         board.board[location.X + 1, location.Y].IsLegal = true;
            //     
            //     if (isSafe(location.X + 2, location.Y))
            //         board.board[location.X + 2, location.Y].IsLegal = true;
            //
            // }
        }
    }
}