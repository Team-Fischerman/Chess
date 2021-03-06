using System;

namespace Checkmate
{
    public class Cell
    {

        public int RowNum { get; set; }
        public int ColNum { get; set; }

        private ChessPiece chessPiece;

        public Cell(int x, int y, ChessPiece chessPiece)
        {
            RowNum = x;
            ColNum = y;
            this.chessPiece = chessPiece;


            if (chessPiece != null)
            {
                IsOccupied = true;
            }
            
            

        }


        public Cell(int x, int y)
        {
            RowNum = x;
            ColNum = y;
        }
        
        
        public bool IsOccupied {get; set;}
        public bool IsLegal    {get; set;}

        public ChessPiece GetChessPiece()
        {
            return chessPiece;
        }

        public String PrintLocation()
        {

            return "(" + RowNum + "," + ColNum + ")";

        }

    }
}