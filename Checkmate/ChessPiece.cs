using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Checkmate
{
    public abstract class ChessPiece
    {

        protected PieceColor pieceColor;


        // pawn variable
        protected bool hasMoved;


        protected List<Cell> legalMoves = new List<Cell>();
        
     

        public ChessPiece(PieceColor pieceColor)
        {
            this.pieceColor = pieceColor;
        }
        
        public Image PieceImage { get; set; }
        public PieceColor GetPieceColor()
        {
            return pieceColor;
        }


        public virtual void ShowLegalMoves(ChessBoard board, Point location)
        {
            // Resets legal move from previous piece
            // board.ClearBoard();
            test(board);

        }




        public void test(ChessBoard b)
        {


            for (int i = 0; i < b.Size; i++)
            {
                for (int j = 0; j < b.Size; j++)
                {
                    b.board[i, j].IsLegal = false;
                }
            }
        }
        
        
        
        

        public void SetPawnMoved(bool moved)
        {
            hasMoved = moved;
        }
        
        

        protected bool isSafe(int rowNum, int colNum)
        {
            if(rowNum < 0 ||  rowNum > 7 || colNum < 0 || colNum > 7)
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