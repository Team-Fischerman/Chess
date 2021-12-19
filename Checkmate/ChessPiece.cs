using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;



// TODO Fix blocking king when checked

namespace Checkmate
{
    public abstract class ChessPiece
    {
        protected PieceColor pieceColor;
        protected bool hasMoved;
        
        protected List<Point> protectingMoves = new List<Point>();
        
        
        public ChessPiece(PieceColor pieceColor)
        {
            this.pieceColor = pieceColor;
        }

        public Image PieceImage { get; set; }

        public PieceColor GetPieceColor()
        {
            return pieceColor;
        }


        public bool IsWhite()
        {
            return pieceColor == PieceColor.WHITE;
        }

        public bool IsBlack()
        {
            return pieceColor == PieceColor.BLACK;
        }


        protected abstract void ShowLegalMoves(ChessBoard board, Point location);

        protected abstract void ShowCheckLegalMoves(ChessBoard board, Point location);


        public  void EnablingLegalMoves(ChessBoard board, Point location)
        {
            
            board.ClearBoard();
            ShowLegalMoves(board,location);
            // switch (Chess.kingState)
            // {
            //     case Chess.State.Normal:
            //         ShowNormalLegalMoves(board, location);
            //         break;
            //     case Chess.State.Check:
            //         ShowCheckLegalMoves(board, location);
            //         break;
            // }

        }
        
        
        protected virtual void AddPotentialMoves(ChessBoard board, Point location)
        {
            ClearProtectingMoves();
        }
        
        private void ClearProtectingMoves()
        {
            if (protectingMoves.Count != 0)
            {
                protectingMoves.Clear(); 
            }
            
        }
        


        // TODO Save elements from legalMove list so that I can compare the elements to kings moves.
        // TODO Issue # Legal moves are getting reset

        public void LegalMove(ChessBoard board, List<Point> list)
        {
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if (board.board[i, j].IsLegal && !board.board[i, j].IsOccupied)
                    {
                        if (!list.Contains(new Point(i, j)))
                        {
                            list.Add(new Point(i, j));
                        }
                    }
                }
            }
        }


        protected void PrintLegalMoves(List<Point> list)
        {
            
            Console.WriteLine();
            foreach (var x in list.OrderBy(p => p.X))
            {
                Console.WriteLine(x);
            }
        }


        // NOT USED
        protected void EnableProtectedMoves(ChessBoard board, List<Point> list1, List<Point> list2)
        {
            // now compare attacking moves with bishop moves * TESTING a single case
            for(int i = 0; i < list1.Count; i++)
            {
                if (list2.Contains(list1[i]))
                {
                    board.board[list1[i].X, list1[i].Y].IsLegal = true;
                }
            }
            
        }


        public void SetPawnMoved(bool moved)
        {
            hasMoved = moved;
        }


        protected bool isSafe(int rowNum, int colNum)
        {
            if (rowNum < 0 || rowNum > 7 || colNum < 0 || colNum > 7)
            {
                return false;
            }

            return true;
        }


        public enum PieceColor
        {
            BLACK,
            WHITE
        }
    }
}