using System.Drawing;


namespace Checkmate.ChessPieces
{
    public class Pawn : ChessPiece
    {
        
        
        public Pawn(PieceColor pieceColor) : base(pieceColor)
        {
            PieceImage = pieceColor == PieceColor.BLACK ? Properties.Resources.BPawn : Properties.Resources.WPawn;
            hasMoved = false;
        }

        private void DiagonalAttackWhite(ChessBoard board, Point location)
        {
                 
            // Highlights left diagonal for white pawn
            if (isSafe(location.X - 1, location.Y - 1) && board.board[location.X - 1, location.Y - 1].IsOccupied &&
                board.board[location.X - 1, location.Y - 1].GetChessPiece().GetPieceColor() == PieceColor.BLACK)
            {
                board.board[location.X - 1, location.Y - 1].IsLegal = true;
            }
            
            
            // Highlights right diagonal for white pawn
            if (isSafe(location.X - 1, location.Y + 1) && board.board[location.X - 1, location.Y + 1].IsOccupied &&
                board.board[location.X - 1, location.Y + 1].GetChessPiece().GetPieceColor() == PieceColor.BLACK)
            {
                board.board[location.X - 1, location.Y + 1].IsLegal = true;
            }

        }


        private void DiagonalAttackBlack(ChessBoard board, Point location)
        {
            
            // Highlights left diagonal for black pawn
            if (isSafe(location.X + 1, location.Y - 1) && board.board[location.X + 1, location.Y - 1].IsOccupied &&
                board.board[location.X + 1, location.Y - 1].GetChessPiece().GetPieceColor() == PieceColor.WHITE)
            {
                board.board[location.X + 1, location.Y - 1].IsLegal = true;
            }
            
            // Highlights right diagonal for black pawn
            if (isSafe(location.X + 1, location.Y + 1) && board.board[location.X + 1, location.Y + 1].IsOccupied &&
                board.board[location.X + 1, location.Y + 1].GetChessPiece().GetPieceColor() == PieceColor.WHITE)
            {
                board.board[location.X + 1, location.Y + 1].IsLegal = true;
            }
            
            
         
            
            
        }

        public override void ShowLegalMoves(ChessBoard board, Point location)
        {
            
             base.ShowLegalMoves(board,location);

             
            // Legal moves for white pawn
            if (pieceColor == PieceColor.WHITE)
            {
                
                // Pawn has the option to the move up two cells
                if (!hasMoved)
                {
                    
                    if (isSafe(location.X - 1, location.Y))
                        board.board[location.X - 1, location.Y].IsLegal = true;
                    
                    if (isSafe(location.X - 2, location.Y))
                        board.board[location.X - 2, location.Y].IsLegal = true;
                    
                    
                    DiagonalAttackWhite(board,location);
                    

                }
                // Once pawn has moved then the pawn can only move up one cells
                else
                {
                    
                    if (isSafe(location.X - 1, location.Y))
                        board.board[location.X - 1, location.Y].IsLegal = true;
                    
                    
                    DiagonalAttackWhite(board,location);
                    
                }
             
            }
            
            // Legal moves for black pawn 
            else
            {

                if (!hasMoved)
                {
                    if (isSafe(location.X + 1, location.Y))
                        board.board[location.X + 1, location.Y].IsLegal = true;
                
                    if (isSafe(location.X + 2, location.Y))
                        board.board[location.X + 2, location.Y].IsLegal = true;
                    
                    
                    DiagonalAttackBlack(board,location);
                    
                }
                else
                {
                    if (isSafe(location.X + 1, location.Y))
                        board.board[location.X + 1, location.Y].IsLegal = true;
                    
                    
                    DiagonalAttackBlack(board,location);
                    
                }
            
            
            }


          
        }
        


    
        
    }
}