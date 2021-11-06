using System;
using System.Drawing;
using System.Windows.Forms;
using Checkmate.ChessPieces;

namespace Checkmate
{
    public partial class Chess : Form
    {
        private ChessBoard board = new ChessBoard();
        private Panel[,] chessBoard = new Panel[8, 8];
        public Chess()
        {
            InitializeComponent();
            CreateVisualBoard();
            
        }


        private void CreateVisualBoard()
        {
            int panelSize = panel1.Width / 8;
            panel1.Height = panel1.Width;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // create panel for each row, column
                    chessBoard[i, j] = new Panel();
  
                   
                    // set the size for each panel
                    chessBoard[i, j].Size = new Size(panelSize, panelSize);
                    chessBoard[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                  

                    // setting a location for each panel
                    chessBoard[i, j].Location = new Point(j * panelSize, i * panelSize);
                    chessBoard[i, j].Click += pieceClick;
                    chessBoard[i, j].Tag = new Point(i, j);
                    

                    // adding each panel to a main panel
                    panel1.Controls.Add(chessBoard[i, j]);
                    
                    

                    // Colors each square 
                    SettingUpEachSquare(i, j, Color.White, Color.DarkGreen);
                    
                
                    
                }
            }
            
            SetUpPieces();

        }
        
        
        /// <summary>
        /// Initializing all chess pieces on the board (visually)
        /// </summary>
           private void SetUpPieces()
        {
            for (int i = 0; i < 8; i++)
            {
                
                // Setting up black and white piece pawn images on the board
                chessBoard[1,i].BackgroundImage = new Pawn(ChessPiece.PieceColor.BLACK).PieceImage;
                chessBoard[6,i].BackgroundImage = new Pawn(ChessPiece.PieceColor.WHITE).PieceImage;

            }
            
          
            BlackPieces(0);
            WhitePieces(7);

            
        }


           /// <summary>
           /// Setting the black chess pieces on the board
           /// </summary>
        void BlackPieces(int row)
        {

              chessBoard[row,0].BackgroundImage = new Rook(ChessPiece.PieceColor.BLACK).PieceImage;
              chessBoard[row,1].BackgroundImage = new Knight(ChessPiece.PieceColor.BLACK).PieceImage;
              chessBoard[row,2].BackgroundImage = new Bishop(ChessPiece.PieceColor.BLACK).PieceImage;
              chessBoard[row,3].BackgroundImage = new Queen(ChessPiece.PieceColor.BLACK).PieceImage;
              chessBoard[row,4].BackgroundImage = new King(ChessPiece.PieceColor.BLACK).PieceImage;
              chessBoard[row,5].BackgroundImage = new Bishop(ChessPiece.PieceColor.BLACK).PieceImage;
              chessBoard[row,6].BackgroundImage = new Knight(ChessPiece.PieceColor.BLACK).PieceImage;
              chessBoard[row,7].BackgroundImage = new Rook(ChessPiece.PieceColor.BLACK).PieceImage;
              
            
        }


        /// <summary>
        /// Setting the white chess pieces on the board
        /// </summary>
        void WhitePieces(int row)
        {
            
            chessBoard[row,0].BackgroundImage = new Rook(ChessPiece.PieceColor.WHITE).PieceImage;
            chessBoard[row,1].BackgroundImage = new Knight(ChessPiece.PieceColor.WHITE).PieceImage;
            chessBoard[row,2].BackgroundImage = new Bishop(ChessPiece.PieceColor.WHITE).PieceImage;
            chessBoard[row,3].BackgroundImage = new Queen(ChessPiece.PieceColor.WHITE).PieceImage;
            chessBoard[row,4].BackgroundImage = new King(ChessPiece.PieceColor.WHITE).PieceImage;
            chessBoard[row,5].BackgroundImage = new Bishop(ChessPiece.PieceColor.WHITE).PieceImage;
            chessBoard[row,6].BackgroundImage = new Knight(ChessPiece.PieceColor.WHITE).PieceImage;
            chessBoard[row,7].BackgroundImage = new Rook(ChessPiece.PieceColor.WHITE).PieceImage;

        }
        
        /// <summary>
        /// When a cell is even or odd then set the color to white, otherwise set it to green
        /// </summary>
        private void SettingUpEachSquare(int i, int j, Color c1, Color c2)
        {
            chessBoard[i, j].BackColor = EvenOrOdd(i, j) ? c1 : c2;
        }

        
        /// <summary>
        /// Returns true if a cell coordinate is even or odd
        /// e.g (0,0) or (1,1)
        /// </summary>
        private bool EvenOrOdd(int i, int j)
        {
            return (i % 2 == 0 && j % 2 == 0 || i % 2 != 0 && j % 2 != 0);
        }



        private void pieceClick(object sender, EventArgs e)
        {
            Panel clickedPiece = (Panel) sender;
            Point location = (Point) clickedPiece.Tag;

        
            Cell currentLocation = board.board[location.X,location.Y];



            ChessPiece chessPiece = null;

            // if square is occupied then there is a piece there
            if (currentLocation.IsOccupied)
            {

                chessPiece = currentLocation.GetChessPiece();
                // if piece is white
                if (chessPiece.GetPieceColor() == ChessPiece.PieceColor.WHITE)
                {
                  
                    // Show legal moves
                    if (chessPiece is Pawn)
                    {
                        board.board[location.X - 1, location.Y].IsLegal = true;
                        board.board[location.X - 2, location.Y].IsLegal = true;
                    
                    }
                    
                    
                }


                
                // Showing legal moves for piece (IN TESTING)
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {

                        if (board.board[i, j].IsLegal)
                        {
                            chessBoard[i, j].BackColor = Color.Red;
                        }
                        
                    }
                }
                
            }

        }


       
    }
}