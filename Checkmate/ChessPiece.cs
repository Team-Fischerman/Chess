using System.Drawing;

namespace Checkmate
{
    public abstract class ChessPiece
    {

        protected PieceColor pieceColor;


        // pawn variable
        protected bool hasMoved;
       

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
            ResetLegalMoves(board);
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


        private void ResetLegalMoves(ChessBoard board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board.board[i, j].IsLegal = false;
                }
            }
        }

      
        
        public enum PieceColor
        {
            BLACK,
            WHITE
        }


    }
    
}