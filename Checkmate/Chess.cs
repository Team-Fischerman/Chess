﻿using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Checkmate.ChessPieces;

namespace Checkmate
{
    public partial class Chess : Form
    {
        private ChessBoard board = new ChessBoard();
        private Panel[,] chessBoard = new Panel[8, 8];

        private ChessPiece currentPiece;
        private Panel tempPanel;
        private Cell clickedCell;
        private Thread workerThread;
        
        private bool whiteTurn;
        private bool legal;


        public Chess()
        {
            InitializeComponent();
            CreateVisualBoard();

            whiteTurn = true;
        }

        private void CreateVisualBoard()
        {
            int panelSize = panel1.Width / 8;
            panel1.Height = panel1.Width;

            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    // create panel for each row, column
                    chessBoard[i, j] = new Panel();


                    // set the size for each panel
                    chessBoard[i, j].Size = new Size(panelSize, panelSize);
                    chessBoard[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    chessBoard[i, j].BorderStyle = BorderStyle.FixedSingle;


                    // setting a location for each panel
                    chessBoard[i, j].Location = new Point(j * panelSize, i * panelSize);
                    chessBoard[i, j].Click += pieceClick;
                    chessBoard[i, j].Tag = new Point(i, j);


                    // adding each panel to a main panel
                    panel1.Controls.Add(chessBoard[i, j]);


                    // Colors each square 
                    SettingUpEachSquare(i, j, Color.White, Color.SandyBrown);
                }
            }

            SetUpPieces();
        }


        /// <summary>
        /// Initializing all chess pieces on the board (visually)
        /// </summary>
        private void SetUpPieces()
        {
            for (int i = 0; i < board.Size; i++)
            {
                // Setting up black and white piece pawn images on the board
                chessBoard[1, i].BackgroundImage = new Pawn(ChessPiece.PieceColor.BLACK).PieceImage;
                chessBoard[6, i].BackgroundImage = new Pawn(ChessPiece.PieceColor.WHITE).PieceImage;
            }

            BlackPieces(0);
            WhitePieces(7);
        }


        /// <summary>
        /// Setting the black chess pieces on the board
        /// </summary>
        void BlackPieces(int row)
        {
            chessBoard[row, 0].BackgroundImage = new Rook(ChessPiece.PieceColor.BLACK).PieceImage;
            chessBoard[row, 1].BackgroundImage = new Knight(ChessPiece.PieceColor.BLACK).PieceImage;
            chessBoard[row, 2].BackgroundImage = new Bishop(ChessPiece.PieceColor.BLACK).PieceImage;
            chessBoard[row, 3].BackgroundImage = new Queen(ChessPiece.PieceColor.BLACK).PieceImage;
            chessBoard[row, 4].BackgroundImage = new King(ChessPiece.PieceColor.BLACK).PieceImage;
            chessBoard[row, 5].BackgroundImage = new Bishop(ChessPiece.PieceColor.BLACK).PieceImage;
            chessBoard[row, 6].BackgroundImage = new Knight(ChessPiece.PieceColor.BLACK).PieceImage;
            chessBoard[row, 7].BackgroundImage = new Rook(ChessPiece.PieceColor.BLACK).PieceImage;
        }


        /// <summary>
        /// Setting the white chess pieces on the board
        /// </summary>
        void WhitePieces(int row)
        {
            chessBoard[row, 0].BackgroundImage = new Rook(ChessPiece.PieceColor.WHITE).PieceImage;
            chessBoard[row, 1].BackgroundImage = new Knight(ChessPiece.PieceColor.WHITE).PieceImage;
            chessBoard[row, 2].BackgroundImage = new Bishop(ChessPiece.PieceColor.WHITE).PieceImage;
            chessBoard[row, 3].BackgroundImage = new Queen(ChessPiece.PieceColor.WHITE).PieceImage;
            chessBoard[row, 4].BackgroundImage = new King(ChessPiece.PieceColor.WHITE).PieceImage;
            chessBoard[row, 5].BackgroundImage = new Bishop(ChessPiece.PieceColor.WHITE).PieceImage;
            chessBoard[row, 6].BackgroundImage = new Knight(ChessPiece.PieceColor.WHITE).PieceImage;
            chessBoard[row, 7].BackgroundImage = new Rook(ChessPiece.PieceColor.WHITE).PieceImage;
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


        /// <summary>
        /// Highlights legal moves red for a chess piece
        /// </summary>
        private void HighlightLegalMove(ChessPiece piece)
        {
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    // Highlight all moves for chess piece
                    if (board.board[i, j].IsLegal && !board.board[i, j].IsOccupied)
                    { 
                        
                        chessBoard[i, j].BackColor = Color.Red;
                        
                    }

                    else if (board.board[i, j].IsLegal && board.board[i, j].IsOccupied)
                    {
                        if (board.board[i, j].GetChessPiece().GetPieceColor() != piece.GetPieceColor())
                        {
                            chessBoard[i, j].BackColor = Color.Red;
                            
                        }
                    }
                }
            }
        }

        private void ResettingBoardColors()
        {
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if (chessBoard[i, j].BackColor == Color.Red)
                    {
                        SettingUpEachSquare(i, j, Color.White, Color.SandyBrown);
                    }
                }
            }
        }

        /// <summary>
        /// Turn based system. 
        /// </summary>
        /// <param name="currentCell"></param>
        /// <param name="piece"></param>
        /// <param name="location"></param>
        private void SwapTurn(Cell currentCell,ChessPiece piece, Point location)
        {
            // Show legal moves for respective turn
            ShowMoves(currentCell, piece, whiteTurn ? ChessPiece.PieceColor.WHITE : ChessPiece.PieceColor.BLACK, location);
        }

        
        private void ShowMoves(Cell currentCell,ChessPiece piece,ChessPiece.PieceColor pieceColor,Point location)
        {
            if (currentCell.IsOccupied)
            {
                    
                if (piece.GetPieceColor() == pieceColor)
                {
                    ResettingBoardColors();
                    piece.ShowLegalMoves(board,location);
                    HighlightLegalMove(piece);
                }
                else
                {
                   
                    /**
                     * disables red square when player clicks on another colors chess piece
                     * e.g if user clicks on a white piece, then the legal moves for white piece will show
                     * but when user clicks on a black piece it will reset white piece red squares
                     */
                    // ResettingBoardColors();
                }
                  
            }
        }


        /// <summary>
        /// Handles all piece movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pieceClick(object sender, EventArgs e)
        {
            Panel clickedPanel = (Panel) sender;
            Point location = (Point) clickedPanel.Tag;
            Cell currentCell = board.board[location.X, location.Y];
            
            label1.Text = @"You clicked a square at location " + location.X + "," + location.Y;
            
            
            ChessPiece piece = currentCell.GetChessPiece();
            
            SwapTurn(currentCell,piece,location);
            
            #region Start of being able to move piece

            bool movePiece = currentPiece == null;
            if (movePiece || !PlayerHasMoved(clickedPanel))
            {
                tempPanel = clickedPanel;
                currentPiece = piece;
                clickedCell = currentCell;
            }
            else
            {
                // Player is moving chess piece
                if (PlayerHasMoved(clickedPanel))
                {
                    clickedPanel.BackgroundImage = currentPiece.PieceImage;
                    tempPanel.BackgroundImage = null;

                    // resetting red squares when chess piece has moved
                    ResettingBoardColors();


                    board.SetCell(location.X, location.Y, new Cell(location.X, location.Y, currentPiece));

                    // Pawn can move up one square after initial turn
                    if (currentPiece is Pawn)
                    {
                        currentPiece.SetPawnMoved(true);

                        if (currentPiece.GetPieceColor() == ChessPiece.PieceColor.WHITE)
                        {
                            // check location
                            if (location == new Point(0, 5))
                            {
                                MessageBox.Show("[TEST] PAWN TO QUEEN");
                            }
                        }
                        
                    }

                    board.SetCell(clickedCell.RowNum, clickedCell.ColNum, new Cell(clickedCell.RowNum, clickedCell.ColNum, null));

                    // swapping turns
                    whiteTurn = !whiteTurn;
                    
                }

                currentPiece = null;
            }

            #endregion END OF MOVING PIECE
        }


        private bool PlayerHasMoved(Panel clickedPanel)
        {
            return clickedPanel.BackColor == Color.Red;
        }


        private void btn_back_Click(object sender, EventArgs e)
        {
            
            
            // creates new homepage instance
            HomePage home = new HomePage();

            // hides chess game
            Hide();

            // shows homepage
            home.ShowDialog();

            // closes chess game
            Close();
            
        }
        
        
        private void DoTimeConsumingWork()
        {
            Thread.Sleep(1000);
        }

        private void btn_resign_Click(object sender, EventArgs e)
        {
            label_winner.Text = "The Winner Is...";

            // makes rest of code wait for workerThread
            workerThread = new Thread(DoTimeConsumingWork);

            // workerThread starting
            workerThread.Start();

            // workerThread completing execution (forcing main thread to wait)
            workerThread.Join();

            // stops background music
            // backgroundMusic.Stop();

            // creates new homepage instance
            HomePage home = new HomePage();

            // hides chess game
            Hide();

            // shows homepage
            home.ShowDialog();

            // closes chess game
            Close();
            
            
        }
    }
}