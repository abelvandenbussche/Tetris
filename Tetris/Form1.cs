using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Tetris
{
    public partial class Form1 : Form
    {
        const int scale = 2;
        TetrisPiece currentPiece;
        List<TetrisPiece> pieces = new List<TetrisPiece>();
        TetrisPiece[] nextPieces = new TetrisPiece[3];
        TetrisPiece? holdPiece = null;
        int score = 0;
        int level = 1;
        int totalLinesCleared = 0;

        //lock delay to prevent instant locking
        bool grounded = false;
        DateTime lockStartTime;
        const int lockDelayTime = 500; //in milliseconds

        System.Windows.Forms.Timer frameTimer = new System.Windows.Forms.Timer();

        Random random = new Random();

        //templates for the tetris pieces
        List<TetrisPiece> pieceTemplates = new List<TetrisPiece>()

        {
            //straight piece
            new TetrisPiece(new List<Tuple<int, int>>()
            {
                new(0, 0),
                new(10, 0),
                new(20, 0),
                new(30, 0)
            }, new Tuple<int, int>(20, 10), Color.LightBlue),
            //L piece
            new TetrisPiece(new List<Tuple<int, int>>()
            {
                new(0, 0),
                new(0, 10),
                new(10, 10),
                new(20, 10)
            }, new Tuple<int, int>(15, 15), Color.Blue),
            //reverse L piece
            new TetrisPiece(new List<Tuple<int, int>>
            {
                new(20, 0),
                new(0, 10),
                new(10, 10),
                new(20, 10)
            }, new Tuple<int, int>(15, 15), Color.Orange),
            //square piece
            new TetrisPiece(new List<Tuple<int, int>>()
            {
                new(0, 0),
                new(0, 10),
                new(10, 0),
                new(10, 10)
            }, new Tuple<int, int>(10, 10), Color.Yellow),
            //S piece
            new TetrisPiece(new List<Tuple<int, int>>()
            {
                new(10, 0),
                new(0, 10),
                new(10, 10),
                new(20, 0),
            }, new Tuple<int, int>(15, 15), Color.Green),
            //T piece
            new TetrisPiece(new List<Tuple<int, int>>()
            {
                new(10, 0),
                new(0, 10),
                new(10, 10),
                new(20, 10)
            }, new Tuple<int, int>(15, 15), Color.Purple),
            //Z piece
            new TetrisPiece(new List<Tuple<int, int>>()
            {
                new(0, 0),
                new(10, 0),
                new(10, 10),
                new(20, 10)
            }, new Tuple<int, int>(15, 15), Color.Red)
        };

        private void setupGameLoop()
        {
            const int updateInterval = 256;
            frameTimer.Interval = updateInterval;
            frameTimer.Tick += GameLoop;
            frameTimer.Start();
        }


        public Form1()
        {
            InitializeComponent();
            setupGameLoop();
            this.Size = new(Math.Max(10 * 10 * scale, this.Size.Width), Math.Max(10 * 20 * scale + 75, this.Size.Height));
            //setting the components to the right size
            MainPictureBox.Size = new Size(10 * 10 * scale + 1, 10 * 20 * scale + 1);
            PreviewPictureBox.Size = new Size((40 + 10 + 10) * scale, (120 + 30 + 20) * scale);
            HoldPictureBox.Size = new Size(60 * scale, 60 * scale);

            //moving the components
            HoldPictureBox.Location = new(12, 12);
            MainPictureBox.Location = new(12 + HoldPictureBox.Size.Width, 12);
            PreviewPictureBox.Location = new(24 + HoldPictureBox.Size.Width + MainPictureBox.Size.Width, 12);

            //making the screen fit a minimum size

            this.KeyDown += Form1_KeyDown;


            nextPieces[0] = SpawnPiece(random.Next(0, pieceTemplates.Count));
            nextPieces[1] = SpawnPiece(random.Next(0, pieceTemplates.Count));
            nextPieces[2] = SpawnPiece(random.Next(0, pieceTemplates.Count));
            currentPiece = SpawnPiece(random.Next(0, pieceTemplates.Count));
        }

        //this draws everytime the picturebox clears
        private void PreviewPictureBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (TetrisPiece piece in nextPieces)
            {
                piece.DrawSelf(e.Graphics, scale, new Tuple<int, int>(10, nextPieces.ToList().IndexOf(piece) * 40 + 10));
            }
        }

        private void HoldPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (holdPiece != null)
            {
                holdPiece.DrawSelf(e.Graphics, scale, new Tuple<int, int>(10, 10));
            }
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            //painting the grid
            Graphics g = e.Graphics;
            using (Pen p = new(Color.Black))
            {
                for (int y = 0; y < 20; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        g.DrawRectangle(p, new(x * 10 * scale, y * 10 * scale, 10 * scale, 10 * scale));
                    }
                }
            }
            paintScene(e.Graphics);
        }

        private TetrisPiece SpawnPiece(int piece)
        {
            //adding it to the list
            TetrisPiece newPiece = pieceTemplates[piece].ShallowCopy();
            newPiece.Position = new(50, -10);
            return newPiece;
        }

        private void GameLoop(object sender, EventArgs e)
        {
            //updating the score label
            Scorelabel.Text = score.ToString();
            //redrawing the main picturebox
            MainPictureBox.Invalidate();
            //moving the current piece
            if (!grounded)
            {
                if (currentPiece.Fall(pieces))
                {
                    grounded = true;
                    lockStartTime = DateTime.Now;
                }
            }
            else
            {
                if ((DateTime.Now - lockStartTime).TotalMilliseconds >= lockDelayTime)
                {
                    //the piece has landed and is not locked
                    grounded = false;
                    pieces.Add(currentPiece);
                    currentPiece = GetNextPiece();
                }
            }

            //checking for a loss
            if (CheckFail())
            {
                //for debugging purposes
                Thread.Sleep(5000);
                this.Close();
            }

            //checking for full lines
            CheckLines();
        }
        private void paintScene(Graphics g)
        {
            foreach (TetrisPiece piece in pieces)
            {
                piece.DrawSelf(g, scale);
            }
            currentPiece.DrawSelf(g, scale);

            //drawing the ghost piece
            TetrisPiece ghost = GetGhost();
            ghost.DrawSelf(g, scale, ghost.Position);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            void ResetDelay()
            {
                lockStartTime = DateTime.Now;
            }
            //movement
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                //checking if there is place to move the piece
                bool stillGrounded = false;
                foreach (Tuple<int, int> pos in currentPiece.Components)
                {
                    //checking the wall
                    if (pos.Item1 + currentPiece.Position.Item1 >= 90)
                    {
                        return;
                    }
                    //checking other pieces
                    foreach(TetrisPiece piece in pieces)
                    {
                        foreach (Tuple<int, int> otherPos in piece.Components)
                        {
                            //checking if we are still touching the ground
                            if (otherPos.Item1 + piece.Position.Item1 == pos.Item1 + currentPiece.Position.Item1 + 10 &&
                                otherPos.Item2 + piece.Position.Item2 == pos.Item2 + currentPiece.Position.Item2 + 10)
                            {
                                stillGrounded = true;
                            }
                            if (otherPos.Item1 + piece.Position.Item1 == pos.Item1 + currentPiece.Position.Item1 + 10 &&
                                otherPos.Item2 + piece.Position.Item2 == pos.Item2 + currentPiece.Position.Item2)
                            {
                                return;
                            }
                        }
                    }
                }
                currentPiece.Position = new(currentPiece.Position.Item1 + 10, currentPiece.Position.Item2);
                if (grounded && !stillGrounded)
                {
                    while (!currentPiece.Fall(pieces)) { }
                }
                ResetDelay();
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Q)
            {
                //checking if there is place to move the piece
                bool stillGrounded = false;
                foreach (Tuple<int, int> pos in currentPiece.Components)
                {
                    //checking the wall
                    if (pos.Item1 + currentPiece.Position.Item1 <= 0)
                    {
                        return;
                    }
                    //checking other pieces
                    foreach(TetrisPiece otherPiece in pieces)
                    {
                        foreach(Tuple<int, int> otherPos in otherPiece.Components)
                        {
                            //checking if we are still touching the ground
                            if (otherPos.Item1 + otherPiece.Position.Item1 == pos.Item1 + currentPiece.Position.Item1 - 10 &&
                                otherPos.Item2 + otherPiece.Position.Item2 == pos.Item2 + currentPiece.Position.Item2 + 10)
                            {
                                stillGrounded = true;
                            }
                            if (otherPos.Item1 + otherPiece.Position.Item1 == pos.Item1 + currentPiece.Position.Item1 - 10 &&
                                otherPos.Item2 + otherPiece.Position.Item2 == pos.Item2 + currentPiece.Position.Item2)
                            {
                                return;
                            }
                        }
                    }
                }
                currentPiece.Position = new(currentPiece.Position.Item1 - 10, currentPiece.Position.Item2);
                if (grounded && !stillGrounded)
                {
                    while (!currentPiece.Fall(pieces)) { }
                }
                ResetDelay();
            }
            //soft drop
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (currentPiece.Fall(pieces))
                {
                    pieces.Add(currentPiece);
                    currentPiece = GetNextPiece();
                }
                score++;
            }
            //hard drop
            else if (e.KeyCode == Keys.Space)
            {
                do { score += 2; } while (!currentPiece.Fall(pieces));
                pieces.Add(currentPiece);
                currentPiece = GetNextPiece();
            }
            //rotation
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Z)
            {
                currentPiece.Rotate(pieces);
                ResetDelay();
            }
            //hold piece
            else if (e.KeyCode == Keys.C)
            {
                if (holdPiece == null)
                {
                    holdPiece = currentPiece;
                    currentPiece = GetNextPiece();
                }
                else
                {
                    TetrisPiece temp = currentPiece;
                    currentPiece = holdPiece;
                    holdPiece = temp;
                    holdPiece.Position = new(50, -10);
                }
                //refresh hold picturebox
                HoldPictureBox.Invalidate();
            }

        }
        private TetrisPiece GetNextPiece()
        {
            TetrisPiece nextPiece = nextPieces[0];
            //shifting the next pieces
            nextPieces[0] = nextPieces[1];
            nextPieces[1] = nextPieces[2];
            nextPieces[2] = SpawnPiece(random.Next(0, pieceTemplates.Count));
            PreviewPictureBox.Invalidate();
            return nextPiece;
        }
        private void CheckLines()
        {
            int LinesCleared = 0;
            for (int i = 0; i < 20; i++)
            {
                int onLine = 0;
                foreach (TetrisPiece piece in pieces)
                {
                    foreach (Tuple<int, int> pos in piece.Components)
                    {
                        if (pos.Item2 + piece.Position.Item2 == i * 10)
                        {
                            onLine++;
                        }
                    }
                }
                if (onLine >= 10)
                {
                    LinesCleared++;
                    //line is full
                    //removing the line
                    foreach (TetrisPiece piece in pieces)
                    {
                        List<Tuple<int, int>> newComponents = new List<Tuple<int, int>>();
                        foreach (Tuple<int, int> pos in piece.Components)
                        {
                            if (pos.Item2 + piece.Position.Item2 == i * 10)
                            {
                                //skipping this component to remove it
                                continue;
                            }
                            newComponents.Add(pos);
                        }
                        piece.Components = newComponents;
                    }
                    //moving down pieces above the line
                    foreach (TetrisPiece piece in pieces)
                    {
                        for (int j = 0; j < piece.Components.Count; j++)
                        {
                            Tuple<int, int> pos = piece.Components[j];
                            if (pos.Item2 + piece.Position.Item2 < i * 10)
                            {
                                piece.Components[j] = new(pos.Item1, pos.Item2 + 10);
                            }
                        }
                    }
                }
            }
            //scoring
            if (LinesCleared == 1) { score += 100 * level; } //Single
            if (LinesCleared == 2) { score += 300 * level; } //Double
            if (LinesCleared == 3) { score += 500 * level; } //Triple
            if (LinesCleared == 4) { score += 800 * level; } //Tetris

            totalLinesCleared += LinesCleared;

            //updating the level if needed
            if (totalLinesCleared == (level * 10))
            {
                level++;
                //changing the speed of the game
                frameTimer.Interval = (int)(frameTimer.Interval * 0.9f);
            }
            LinesClearedLabel.Text = "Lines cleared: " + totalLinesCleared;
        }
        private TetrisPiece GetGhost()
        {
            TetrisPiece ghostPiece = currentPiece.ShallowCopy();
            while (!ghostPiece.Fall(pieces)) { }
            ghostPiece.PieceColor = Color.FromArgb(100, ghostPiece.PieceColor.R, ghostPiece.PieceColor.G, ghostPiece.PieceColor.B);
            return ghostPiece;
        }
        private bool CheckFail()
        {
            foreach (TetrisPiece piece in pieces)
            {
                foreach (Tuple<int, int> comp in piece.Components)
                {
                    if (comp.Item2 + piece.Position.Item2 == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}