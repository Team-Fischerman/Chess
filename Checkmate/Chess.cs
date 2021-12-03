﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Checkmate.ChessPieces;

namespace Checkmate
{
    public partial class Chess : Form
    {
        // board var
        private ChessBoard board = new ChessBoard();
        private Panel[,] chessBoard = new Panel[8, 8];

        
        
        private readonly Color _color1 = Color.DarkGreen;


        // thread var
        private Thread workerThread;

        // logic var
        private List<Point> endPoints = new List<Point>();
        private ChessPiece currentPiece;
        private Cell clickedCell;
        private Panel tempPanel;
        private bool whiteTurn;


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
                    chessBoard[i, j].Click += PieceClick;
                    chessBoard[i, j].Tag = new Point(i, j);


                    // adding each panel to a main panel
                    panel1.Controls.Add(chessBoard[i, j]);


                    // Colors each square 
                    SettingUpEachSquare(i, j, Color.White, _color1);
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
                endPoints.Add(new Point(0, i));
                endPoints.Add(new Point(7, i));
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
                        // MessageBox.Show("Hello");
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
                        SettingUpEachSquare(i, j, Color.White, _color1);
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
        private void SwapTurn(Cell currentCell, ChessPiece piece, Point location)
        {
            // Show legal moves for respective turn
            ShowMoves(currentCell, piece, whiteTurn ? ChessPiece.PieceColor.WHITE : ChessPiece.PieceColor.BLACK,
                location);
        }


        private void ShowMoves(Cell currentCell, ChessPiece piece, ChessPiece.PieceColor pieceColor, Point location)
        {
            if (currentCell.IsOccupied)
            {
                if (piece.GetPieceColor() == pieceColor)
                {
                    ResettingBoardColors();
                    piece.ShowLegalMoves(board, location);

                    if (Settings.Highlight)
                    {
                        HighlightLegalMove(piece);
                    }
                }
                else
                {
                    ResettingBoardColors();
                    board.ClearBoard();
                }
            }
        }


        /// <summary>
        /// Handles all piece movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        private void PieceClick(object sender, EventArgs e)
        {
            Panel clickedPanel = (Panel) sender;
            Point location = (Point) clickedPanel.Tag;
            Cell currentCell = board.board[location.X, location.Y];


            label1.Text = @"You clicked a square at location " + location.X + "," + location.Y;

            ChessPiece piece = currentCell.GetChessPiece();
            SwapTurn(currentCell, piece, location);

            // TODO Fix taking piece
            // STATE = Normal, Check, Checkmate


            #region Start of being able to move piece

            bool movePiece = currentPiece == null;
            if (movePiece || !currentCell.IsLegal)
            {
                tempPanel = clickedPanel;
                currentPiece = piece;
                clickedCell = currentCell;
            }
            else
            {
                // Player can move if currentCell is legal
                if (currentCell.IsLegal)
                {
                    clickedPanel.BackgroundImage = currentPiece.PieceImage;
                    tempPanel.BackgroundImage = null;

                    // resetting red squares when chess piece has moved
                    ResettingBoardColors();
                    board.SetCell(location.X, location.Y, new Cell(location.X, location.Y, currentPiece));

                    if (currentPiece is Pawn)
                    {
                        currentPiece.SetPawnMoved(true);

                        // change pawn into queen 
                        PawnIntoQueen(location);
                    }

                    board.SetCell(clickedCell.RowNum, clickedCell.ColNum,
                        new Cell(clickedCell.RowNum, clickedCell.ColNum, null));
                    SetTurnText();
                }


                currentPiece = null;
            }

            #endregion END OF MOVING PIECE
        }


        private void PawnIntoQueen(Point location)
        {
            foreach (var endPoint in endPoints)
            {
                if (location == endPoint)
                {
                    SettingPawnToQueen(location,
                        location.X == 0 ? ChessPiece.PieceColor.WHITE : ChessPiece.PieceColor.BLACK);
                }
            }
        }


        private bool TurnIs(bool turn)
        {
            return turn;
        }

        private void SettingPawnToQueen(Point location, ChessPiece.PieceColor pieceColor)
        {
            chessBoard[location.X, location.Y].BackgroundImage = new Queen(pieceColor).PieceImage;
            board.board[location.X, location.Y] = new Cell(location.X, location.Y, new Queen(pieceColor));
        }


        private void SetTurnText()
        {
            // swapping turns
            whiteTurn = !whiteTurn;
            label_turn.Text = whiteTurn ? @"White Turn" : @"Black Turn";
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