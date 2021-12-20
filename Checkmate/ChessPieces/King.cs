using System;
using System.Collections.Generic;
using System.Drawing;


namespace Checkmate.ChessPieces
{
    // TODO When King is checked, get attacking tile and check to see if Checked King color pieces can protect the King
    // TODO fix bug where King legal move wont show next to it to attack when checked
    // TODO when king is checked and it moves then state == normal 

    public class King : ChessPiece
    {
        private readonly Point[] _kingMoves = new Point[8];


        public King(PieceColor pieceColor) : base(pieceColor)
        {
            PieceImage = pieceColor == PieceColor.BLACK ? Properties.Resources.BKing : Properties.Resources.WKing;
        }


    

        protected override void ShowLegalMoves(ChessBoard board, Point location)
        {
            // base.ShowLegalMoves(board, location);

            // board.ClearBoard();
            _kingMoves[0] = new Point(location.X + 1, location.Y);
            _kingMoves[1] = new Point(location.X - 1, location.Y);
            _kingMoves[2] = new Point(location.X, location.Y + 1);
            _kingMoves[3] = new Point(location.X, location.Y - 1);
            _kingMoves[4] = new Point(location.X - 1, location.Y - 1);
            _kingMoves[5] = new Point(location.X + 1, location.Y + 1);
            _kingMoves[6] = new Point(location.X + 1, location.Y - 1);
            _kingMoves[7] = new Point(location.X - 1, location.Y + 1);
            
            
            if (Chess.kingState == Chess.State.Check || Chess.kingState == Chess.State.Normal)
            {
                CheckedLegalMoves(board,board.GetKingList());
            }


            // Check to see how many available legal moves does he have
            // if (Chess.kingState == Chess.State.Check)
            // {
            //     
            // }

            

            // if (Chess.kingState == Chess.State.Normal)
            // {
            //    // CheckedLegalMoves(board,board.GetKingList());
            //     
            //     if (isSafe(location.X + 1, location.Y))
            //     {
            //         board.board[location.X + 1, location.Y].IsLegal = true;
            //     }
            //     
            //     if (isSafe(location.X - 1, location.Y))
            //     {
            //         board.board[location.X - 1, location.Y].IsLegal = true;
            //     }
            //     
            //     if (isSafe(location.X, location.Y + 1))
            //     {
            //         board.board[location.X, location.Y + 1].IsLegal = true;
            //     }
            //     
            //     if (isSafe(location.X, location.Y - 1))
            //     {
            //         board.board[location.X, location.Y - 1].IsLegal = true;
            //     }
            //     
            //     if (isSafe(location.X - 1, location.Y - 1))
            //     {
            //         board.board[location.X - 1, location.Y - 1].IsLegal = true;
            //     }
            //     
            //     if (isSafe(location.X + 1, location.Y + 1))
            //     {
            //         board.board[location.X + 1, location.Y + 1].IsLegal = true;
            //     }
            //     
            //     if (isSafe(location.X + 1, location.Y - 1))
            //     {
            //         board.board[location.X + 1, location.Y - 1].IsLegal = true;
            //     }
            //     
            //     
            //     if (isSafe(location.X - 1, location.Y + 1))
            //     {
            //         board.board[location.X - 1, location.Y + 1].IsLegal = true;
            //     }
            // }
            // else if (Chess.kingState == Chess.State.Check)
            // {
            //     CheckedLegalMoves(board, board.GetKingList());
            // }
            
        }


        private void CheckedLegalMoves(ChessBoard board, List<Point> list)
        {
            
            // Console.WriteLine("List Moves of piece");
            // PrintLegalMoves(list);
            for (int i = 0; i < _kingMoves.Length; i++)
            {
                if (!list.Contains(_kingMoves[i]))
                {
                    if (isSafe(_kingMoves[i].X, _kingMoves[i].Y))
                    {
                        board.board[_kingMoves[i].X, _kingMoves[i].Y].IsLegal = true;
                    }
                }
            }
            
            PrintLegalMoves(list);
            
        }
    }
}