using System.Diagnostics;
using System.Drawing;

namespace Checkmate.ChessPieces
{
    public class Queen : ChessPiece
    {
        public Queen(PieceColor pieceColor) : base(pieceColor)
        {
            PieceImage = pieceColor == PieceColor.BLACK ? Properties.Resources.BQueen : Properties.Resources.WQueen;
        }


        

        protected override void ShowLegalMoves(ChessBoard board, Point location)
        {
            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X - i, location.Y))
                {
                    board.board[location.X - i, location.Y].IsLegal = true;
                    if (board.board[location.X - i, location.Y].IsOccupied)
                    {
                        break;
                    }
                }
            }


            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X + i, location.Y))
                {
                    board.board[location.X + i, location.Y].IsLegal = true;
                    if (board.board[location.X + i, location.Y].IsOccupied)
                    {
                        break;
                    }
                }
            }

            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X, location.Y + i))
                {
                    board.board[location.X, location.Y + i].IsLegal = true;
                    if (board.board[location.X, location.Y + i].IsOccupied)
                    {
                        break;
                    }
                }
            }

            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X, location.Y - i))
                {
                    board.board[location.X, location.Y - i].IsLegal = true;
                    if (board.board[location.X, location.Y - i].IsOccupied)
                    {
                        break;
                    }
                }
            }

            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X - i, location.Y - i))
                {
                    board.board[location.X - i, location.Y - i].IsLegal = true;
                    if (board.board[location.X - i, location.Y - i].IsOccupied)
                    {
                        break;
                    }
                }
            }

            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X + i, location.Y + i))
                {
                    board.board[location.X + i, location.Y + i].IsLegal = true;
                    if (board.board[location.X + i, location.Y + i].IsOccupied)
                    {
                        break;
                    }
                }
            }

            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X + i, location.Y - i))
                {
                    board.board[location.X + i, location.Y - i].IsLegal = true;
                    if (board.board[location.X + i, location.Y - i].IsOccupied)
                    {
                        break;
                    }
                }
            }

            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X - i, location.Y + i))
                {
                    board.board[location.X - i, location.Y + i].IsLegal = true;
                    if (board.board[location.X - i, location.Y + i].IsOccupied)
                    {
                        break;
                    }
                }
            }
        }


        // NOT USED
        protected override void AddPotentialMoves(ChessBoard board, Point location)
        {
            // base.AddPotentialMoves(board, location);
            // ShowCheckLegalMoves(board, location);
            // LegalMove(board, protectingMoves);
            // board.ClearBoard();
        }
    }
}