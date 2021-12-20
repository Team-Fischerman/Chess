using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Checkmate.ChessPieces;

namespace Checkmate
{
    public partial class Chess : Form
    {
        public enum State
        {
            Normal,
            Check,
            Checkmate
        }

        public static State kingState;


        // board var
        private ChessBoard board = new ChessBoard(true);
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
        private int pieceCounter;


        public Chess()
        {
            
            Console.WriteLine("Starting a chess game.");
            InitializeComponent();
            CreateVisualBoard();

            label_debug.Text = "" + State.Normal;
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
        public void HighlightLegalMove(ChessPiece piece)
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

        // Reset visual board (colors)
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
                    piece.EnablingLegalMoves(board, location);

                    // enabling legal moves 
                    if (Settings.Highlight)
                    {
                        HighlightLegalMove(piece);
                    }
                }
                else
                {
                    ResettingBoardColors();
                    canMove = currentCell.IsLegal;
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
        ///
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
                        PawnIntoQueen(location);
                    }

                    // if (currentPiece is King)
                    // {
                    //     currentPiece.SetPawnMoved(true);
                    //     Castle(location);
                    // }
                    //
                    // if (currentPiece is Rook)
                    // {
                    //     currentPiece.SetPawnMoved(true);
                    // }


                    board.SetCell(clickedCell.RowNum, clickedCell.ColNum,
                        new Cell(clickedCell.RowNum, clickedCell.ColNum, null));

                    SetTurnText();
                    canMove = false;


                    // Check for check
                    // change state to check

                    // get the current piece legal moves
                    currentPiece.EnablingLegalMoves(board, location);
                    if (board.KingIsInCheck(currentPiece, currentPiece.GetPieceColor()))
                    {
                        kingState = State.Check;
                        Console.WriteLine(@"Check!");
                    }
                    else
                    {
                        kingState = State.Normal;
                    }


                    // When a piece has moved and it's check
                    if (kingState == State.Check || kingState == State.Normal)
                    {
                        // check to see if the king is in legal move checker of opposing color pieces
                        // 1. loop through the board
                        // 2. check opposing pieces and enable their moves
                        // 3. add all opposing pieces legal moves to a list
                        // 4. compare legal moves to kings moves
                        // 5. if they dont match then enable the ones that do not match

                        // board.AttackingMoves();
                        
                        // add attacking piece moves past the kings move
                        
                        board.KingsLegalMove(this, currentPiece.GetPieceColor());
                    }



                    for (int i = 0; i < board.Size; i++)
                    {
                        for (int j = 0; j < board.Size; j++)
                        {
                            if (board.board[i, j].GetChessPiece() != null)
                            {
                                if (!(board.board[i, j].GetChessPiece() is King))
                                {
                                    pieceCounter++;
                                }
                            }
                          
                        }
                    }

                    Console.WriteLine(pieceCounter);

                    if (pieceCounter == 0)
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
                    
                    pieceCounter = 0;
                    
                    
                    
                    
                    

                    label_debug.Text = "" + kingState;

                    // board.PrintList(board.GetDefendingList());
                    // board.PrintList(board.GetAttackingList()); 
                    // getting check when a piece attacks the king
                    // after king has moved from check then state = normal
                }


                currentPiece = null;
            }


            // board.PrintList(board.GetDefendingList());
            // Testing legal move list

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

        private void Castle(Point location)
        {
            Console.WriteLine("location: " + location);
            if (location.X == 7 && location.Y == 2)
            {
                chessBoard[7, 3].BackgroundImage = new Rook(ChessPiece.PieceColor.WHITE).PieceImage;
                board.board[7, 3] = new Cell(7, 3, new Rook(ChessPiece.PieceColor.WHITE));
                chessBoard[7, 0].BackgroundImage = null;
                board.board[7, 0] = new Cell(7, 0, null);
            }
            else if (location.X == 7 && location.Y == 6)
            {
                chessBoard[7, 5].BackgroundImage = new Rook(ChessPiece.PieceColor.WHITE).PieceImage;
                board.board[7, 5] = new Cell(7, 5, new Rook(ChessPiece.PieceColor.WHITE));
                chessBoard[7, 7].BackgroundImage = null;
                board.board[7, 7] = new Cell(7, 7, null);
            }
            else if (location.X == 0 && location.Y == 2)
            {
                chessBoard[0, 3].BackgroundImage = new Rook(ChessPiece.PieceColor.BLACK).PieceImage;
                board.board[0, 3] = new Cell(0, 3, new Rook(ChessPiece.PieceColor.BLACK));
                chessBoard[0, 0].BackgroundImage = null;
                board.board[0, 0] = new Cell(0, 0, null);
            }
            else if (location.X == 0 && location.Y == 6)
            {
                chessBoard[0, 5].BackgroundImage = new Rook(ChessPiece.PieceColor.BLACK).PieceImage;
                board.board[0, 5] = new Cell(7, 3, new Rook(ChessPiece.PieceColor.BLACK));
                chessBoard[0, 7].BackgroundImage = null;
                board.board[0, 7] = new Cell(7, 0, null);
            }
        }


        private void SetTurnText()
        {
            // swapping turns
            whiteTurn = !whiteTurn;
            label_turn.Text = whiteTurn ? @"White Turn" : @"Black Turn";
        }


        private void btn_back_Click(object sender, EventArgs e)
        {
            
            Console.WriteLine("Back to homepage.");
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