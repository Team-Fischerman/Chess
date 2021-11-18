
using Checkmate.ChessPieces;

namespace Checkmate
{
    public class ChessBoard
    {
        public int Size{ get; private set; }
        public Cell[,] board { get; set;}
        
        

        public ChessBoard()
        {
            
            Size = 8;
            board = new Cell[Size, Size];
            
            InitializeBoard();
            
            
        }


        public void ClearBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j].IsLegal = false;
                   
                }
            }
        }
        
        
        public void SetCell(int x, int y,Cell cell)
        {
            board[x, y] = cell;
            
        }



        private void InitializeBoard()
        {
             // setting black pieces through memory
            board[0,0] =  new Cell(0, 0, new Rook  (ChessPiece.PieceColor.BLACK));
            board[0,1] =  new Cell(0, 1, new Knight(ChessPiece.PieceColor.BLACK));
            board[0,2] =  new Cell(0, 2, new Bishop(ChessPiece.PieceColor.BLACK));
            board[0,3] =  new Cell(0, 3, new Queen (ChessPiece.PieceColor.BLACK));
            board[0,4] =  new Cell(0, 4, new King  (ChessPiece.PieceColor.BLACK));
            board[0,5] =  new Cell(0, 5, new Bishop(ChessPiece.PieceColor.BLACK));
            board[0,6] =  new Cell(0, 6, new Knight(ChessPiece.PieceColor.BLACK));
            board[0,7] =  new Cell(0, 7, new Rook  (ChessPiece.PieceColor.BLACK));
            
            
            // setting white pieces through memory
            board[7,0] =  new Cell(7, 0, new Rook  (ChessPiece.PieceColor.WHITE));
            board[7,1] =  new Cell(7, 1, new Knight(ChessPiece.PieceColor.WHITE));
            board[7,2] =  new Cell(7, 2, new Bishop(ChessPiece.PieceColor.WHITE));
            board[7,3] =  new Cell(7, 3, new Queen (ChessPiece.PieceColor.WHITE));
            board[7,4] =  new Cell(7, 4, new King  (ChessPiece.PieceColor.WHITE));
            board[7,5] =  new Cell(7, 5, new Bishop(ChessPiece.PieceColor.WHITE));
            board[7,6] =  new Cell(7, 6, new Knight(ChessPiece.PieceColor.WHITE));
            board[7,7] =  new Cell(7, 7, new Rook  (ChessPiece.PieceColor.WHITE));
            
            
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
        
    }
}