using System.Drawing;

namespace Checkmate
{
    public abstract class ChessPiece
    {

        protected PieceColor pieceColor;

        public ChessPiece(PieceColor pieceColor)
        {
            this.pieceColor = pieceColor;
        }

        public Image PieceImage { get; set; }

        public PieceColor GetPieceColor()
        {
            return pieceColor;
        }

        
        public enum PieceColor
        {
            BLACK,
            WHITE
        }


    }
    
}