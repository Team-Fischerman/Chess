using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Checkmate.ChessPieces;

namespace Checkmate
{
    public class ChessBoard
    {
        public int Size { get; private set; }
        public Cell[,] board { get; set; }
        public ChessPiece _piece { get; set; }

        private List<Point> kingsAvailableMoves = new List<Point>();

        private List<Point> attackingMoves = new List<Point>();


        public ChessBoard(bool normal)
        {
            Size = 8;
            board = new Cell[Size, Size];
            
            
            if (normal)
            {
                InitializeBoard();
            }
            else
            {
                TutorialInitializeBoard();
            }
        }


        public void ClearBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    board[i, j].IsLegal = false;
                }
            }
        }


        public void PrintList(List<Point> list)
        {
            Console.WriteLine();
            foreach (var x in list.OrderBy(p => p.X))
            {
                Console.WriteLine(x);
            }
        }


        public List<Point> GetKingList()
        {
            return kingsAvailableMoves;
        }


        public List<Point> GetAttackingList()
        {
            return attackingMoves;
        }


        public void AttackingMoves()
        {
            // adding attacking moves to list (attackingMoves)
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    // Check to see if a cell is legal?
                    Cell cell = board[i, j];

                    if (cell.IsLegal)
                    {
                        attackingMoves.Add(new Point(i, j));
                    }
                }
            }


            // loop through board
            // enable black pieces (testing)
            // check to see if the moves of black pieces are equal to each other

            // for (int i = 0; i < Size; i++)
            // {
            //     for (int j = 0; j < Size; j++)
            //     {
            //         Cell cell = board[i, j];
            //
            //         if (cell.GetChessPiece() != null)
            //         {
            //             if (cell.GetChessPiece().IsBlack())
            //             {
            //                 cell.GetChessPiece().EnablingLegalMoves(this, new Point(i, j));
            //                 cell.GetChessPiece().LegalMove(this, defendingMoves);
            //             }
            //         }
            //     }
            // }


            // for(int i = 0; i < defendingMoves.Count; i++)
            // {
            //     if (attackingMoves.Contains(defendingMoves[i]))
            //     {
            //         board[defendingMoves[i].X, defendingMoves[i].Y].IsLegal = true;
            //     }
            // }
        }

        public void KingsLegalMove(Chess chess, ChessPiece.PieceColor pieceColor)
        {
            bool flag = true;
            Console.WriteLine(@"Entering KingsLegalMove()");

            if (kingsAvailableMoves.Count != 0)
            {
                Console.WriteLine(@"List is not empty!");
                kingsAvailableMoves.Clear();
            }
            else
            {
                Console.Write("Kings available moves is empty.");
            }


            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cell cell = board[i, j];
                    _piece = cell.GetChessPiece();


                    if (_piece != null)
                    {
                        if (pieceColor == _piece.GetPieceColor())
                        {
                            if (!(_piece is Pawn))
                            {
                                GeneratingKingLegalMove(_piece, i, j);
                            }
                            else
                            {
                                _piece.PawnLegalMove(this, new Point(i, j));
                                _piece.LegalMove(this, kingsAvailableMoves);
                            }
                        }
                    }
                }
            }
        }


        private void GeneratingKingLegalMove(ChessPiece piece, int i, int j)
        {
            piece.EnablingLegalMoves(this, new Point(i, j));
            piece.LegalMove(this, kingsAvailableMoves);
            ClearBoard();
        }

        public bool KingIsInCheck(ChessPiece currentPiece, ChessPiece.PieceColor pieceColor)
        {
            // now check if king is legal moves 
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cell cell = board[i, j];


                    if (currentPiece.GetPieceColor() == pieceColor)
                    {
                        if (cell.IsLegal && cell.IsOccupied)
                        {
                            if (cell.GetChessPiece() is King)

                                if (cell.GetChessPiece().GetPieceColor() != pieceColor)
                                {
                                    // Console.WriteLine("Check!");
                                    // Console.WriteLine("King Location " + cell.PrintLocation());
                                    return true;
                                }
                        }
                    }
                }
            }


            return false;
        }


        public void SetCell(int x, int y, Cell cell)
        {
            board[x, y] = cell;
        }


        private void InitializeBoard()
        {
            // setting black pieces through memory
            board[0, 0] = new Cell(0, 0, new Rook(ChessPiece.PieceColor.BLACK));
            board[0, 1] = new Cell(0, 1, new Knight(ChessPiece.PieceColor.BLACK));
            board[0, 2] = new Cell(0, 2, new Bishop(ChessPiece.PieceColor.BLACK));
            board[0, 3] = new Cell(0, 3, new Queen(ChessPiece.PieceColor.BLACK));
            board[0, 4] = new Cell(0, 4, new King(ChessPiece.PieceColor.BLACK));
            board[0, 5] = new Cell(0, 5, new Bishop(ChessPiece.PieceColor.BLACK));
            board[0, 6] = new Cell(0, 6, new Knight(ChessPiece.PieceColor.BLACK));
            board[0, 7] = new Cell(0, 7, new Rook(ChessPiece.PieceColor.BLACK));


            // setting white pieces through memory
            board[7, 0] = new Cell(7, 0, new Rook(ChessPiece.PieceColor.WHITE));
            board[7, 1] = new Cell(7, 1, new Knight(ChessPiece.PieceColor.WHITE));
            board[7, 2] = new Cell(7, 2, new Bishop(ChessPiece.PieceColor.WHITE));
            board[7, 3] = new Cell(7, 3, new Queen(ChessPiece.PieceColor.WHITE));
            board[7, 4] = new Cell(7, 4, new King(ChessPiece.PieceColor.WHITE));
            board[7, 5] = new Cell(7, 5, new Bishop(ChessPiece.PieceColor.WHITE));
            board[7, 6] = new Cell(7, 6, new Knight(ChessPiece.PieceColor.WHITE));
            board[7, 7] = new Cell(7, 7, new Rook(ChessPiece.PieceColor.WHITE));


            // setting free squares to null and not busy
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    board[i, j] = new Cell(i, j, null);
                }
            }

            // setting black and white pawns through memory
            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new Cell(1, i, new Pawn(ChessPiece.PieceColor.BLACK));
                board[6, i] = new Cell(6, i, new Pawn(ChessPiece.PieceColor.WHITE));
            }
        }


        private void TutorialInitializeBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    board[i, j] = new Cell(i, j, null);
                }
            }


            board[0, 3] = new Cell(0, 3, new Queen(ChessPiece.PieceColor.BLACK));
            board[0, 4] = new Cell(0, 4, new King(ChessPiece.PieceColor.BLACK));
            board[0, 5] = new Cell(0, 5, new Bishop(ChessPiece.PieceColor.BLACK));
            board[0, 6] = new Cell(0, 6, new Knight(ChessPiece.PieceColor.BLACK));
            board[0, 7] = new Cell(0, 7, new Rook(ChessPiece.PieceColor.BLACK));
            board[1, 5] = new Cell(1, 5, new Pawn(ChessPiece.PieceColor.BLACK));


            board[7, 3] = new Cell(7, 3, new Queen(ChessPiece.PieceColor.WHITE));
            board[7, 4] = new Cell(7, 4, new King(ChessPiece.PieceColor.WHITE));
            board[7, 5] = new Cell(7, 5, new Bishop(ChessPiece.PieceColor.WHITE));
            board[7, 6] = new Cell(7, 6, new Knight(ChessPiece.PieceColor.WHITE));
            board[7, 7] = new Cell(7, 7, new Rook(ChessPiece.PieceColor.WHITE));
            board[6, 5] = new Cell(6, 5, new Pawn(ChessPiece.PieceColor.WHITE));
        }
    }
}