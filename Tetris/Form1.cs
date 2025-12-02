using System.Diagnostics;

namespace Tetris
{
    public partial class Form1 : Form
    {
        const int scale = 2;
        TetrisPiece currentPiece;
        List<TetrisPiece> pieces = new List<TetrisPiece>();
        TetrisPiece[] nextPieces = new TetrisPiece[3];
        TetrisPiece? holdPiece = null;

        Random random = new Random();

        private void setupGameLoop()
        {

            System.Windows.Forms.Timer frameTimer = new System.Windows.Forms.Timer();
            const int updateInterval = 256;
            frameTimer.Interval = updateInterval;
            frameTimer.Tick += GameLoop;
            frameTimer.Start();
        }


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
        public Form1()
        {
            InitializeComponent();
            setupGameLoop();
            //setting the components to the right size
            MainPictureBox.Size = new Size(10 * 10 * scale + 1, 10 * 20 * scale + 1);
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
                piece.DrawSelf(e.Graphics, scale, new Tuple<int, int>(50, nextPieces.ToList().IndexOf(piece) * 60 + 20));
            }
        }

        private void HoldPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (holdPiece != null)
            {
                holdPiece.DrawSelf(e.Graphics, scale, new Tuple<int, int>(0, 0));
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
            MainPictureBox.Invalidate();
            //moving the current piece
            MainPictureBox.Invalidate();
            if (currentPiece.Fall(pieces))
            {
                //the piece has landed
                pieces.Add(currentPiece);
                currentPiece = GetNextPiece();
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
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //movement
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                //checking if there is place to move the piece
                foreach (Tuple<int, int> pos in currentPiece.Components)
                {
                    if (pos.Item1 + currentPiece.Position.Item1 >= 90)
                    {
                        return;
                    }
                }
                currentPiece.Position = new(currentPiece.Position.Item1 + 10, currentPiece.Position.Item2);
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                //checking if there is place to move the piece
                foreach (Tuple<int, int> pos in currentPiece.Components)
                {
                    if (pos.Item1 + currentPiece.Position.Item1 <= 0)
                    {
                        return;
                    }
                }
                currentPiece.Position = new(currentPiece.Position.Item1 - 10, currentPiece.Position.Item2);
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (currentPiece.Fall(pieces))
                {
                    pieces.Add(currentPiece);
                    currentPiece = GetNextPiece();
                }
            }
            //hold piece
            else if (e.KeyCode == Keys.C) {
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
            else if (e.KeyCode == Keys.Space)
            {
                //hard drop
                while (!currentPiece.Fall(pieces)) { }
                pieces.Add(currentPiece);
                currentPiece = GetNextPiece();
            }

            //rotation
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Z)
            {
                currentPiece.Rotate();
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
                Debug.WriteLine(onLine);
                if (onLine >= 10)
                {
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
                        foreach (Tuple<int, int> pos in piece.Components)
                        {
                            if (pos.Item2 + piece.Position.Item2 < i * 10)
                            {
                                piece.Position = new(piece.Position.Item1, piece.Position.Item2 + 10);
                            }
                        }
                    }
                }
            }
        }
    }
}
