using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Checkmate.ChessPieces;

namespace Checkmate
{
    public partial class Tutorial : Form
    {
        private ChessBoard board = new ChessBoard(false);
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
        private bool canMove;


        public Tutorial()
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
                endPoints.Add(new Point(0, i));
                endPoints.Add(new Point(7, i));
            }


            chessBoard[0, 3].BackgroundImage = board.board[0, 3].GetChessPiece().PieceImage;
            chessBoard[0, 4].BackgroundImage = board.board[0, 4].GetChessPiece().PieceImage;
            chessBoard[0, 5].BackgroundImage = board.board[0, 5].GetChessPiece().PieceImage;
            chessBoard[0, 6].BackgroundImage = board.board[0, 6].GetChessPiece().PieceImage;
            chessBoard[0, 7].BackgroundImage = board.board[0, 7].GetChessPiece().PieceImage;
            chessBoard[1, 5].BackgroundImage = board.board[1, 5].GetChessPiece().PieceImage;


            chessBoard[7, 3].BackgroundImage = board.board[7, 3].GetChessPiece().PieceImage;
            chessBoard[7, 4].BackgroundImage = board.board[7, 4].GetChessPiece().PieceImage;
            chessBoard[7, 5].BackgroundImage = board.board[7, 5].GetChessPiece().PieceImage;
            chessBoard[7, 6].BackgroundImage = board.board[7, 6].GetChessPiece().PieceImage;
            chessBoard[7, 7].BackgroundImage = board.board[7, 7].GetChessPiece().PieceImage;
            chessBoard[6, 5].BackgroundImage = board.board[6, 5].GetChessPiece().PieceImage;
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
                    canMove = true;
                    ResettingBoardColors();
                    piece.ShowLegalMoves(board, location);

                    // enabling legal moves 
                    if (Settings.Highlight)
                    {
                        HighlightLegalMove(piece);
                    }
                }
                else
                {
                    ResettingBoardColors();


                    // For taking pieces
                    if (currentCell.IsLegal)
                    {
                        canMove = true;
                    }
                    else
                    {
                        canMove = false;
                    }
                }
            }
            else
            {
                // when player deselects piece and selects and unoccupied square that isn't legal then reset board colors
                if (!currentCell.IsLegal)
                {
                    ResettingBoardColors();
                }
            }
        }

        /// <summary>
        /// Handles all piece movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PieceClick(object sender, EventArgs e)
        {
            Panel clickedPanel = (Panel) sender;
            Point location = (Point) clickedPanel.Tag;
            Cell currentCell = board.board[location.X, location.Y];

            label1.Text = @"You clicked a square at location " + location.X + "," + location.Y;


            ChessPiece piece = currentCell.GetChessPiece();
            SwapTurn(currentCell, piece, location);


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
                // Player can ONLY move when a cell is == legal and if canMove == true;
                if (currentCell.IsLegal && canMove)
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


                    canMove = false;
                    
                }

                currentPiece = null;
            }

            #endregion END OF MOVING PIECE
        }


        /// <summary>
        /// Changes pawn into queen when ever respective piece reaches other side of the board
        /// </summary>
        /// <param name="location"></param>
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


        private void btn_back_Click_1(object sender, EventArgs e)
        {
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