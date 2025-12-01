namespace Tetris
{
    public partial class Form1 : Form
    {
        //TODO: implement scale properly
        int scale = 10;
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
            //setting the components to the right size
            MainPictureBox.Size = new Size(10*10*scale, 10*20*scale);
        }
        //this draws everytime the picturebox clears
        private void PreviewPictureBox_Paint(object sender, PaintEventArgs e)
        {
            pieceTemplates[0].DrawSelf(e.Graphics, new Tuple<int, int>(20, 50));
            pieceTemplates[1].DrawSelf(e.Graphics, new Tuple<int, int>(20, 80));
            pieceTemplates[2].DrawSelf(e.Graphics, new Tuple<int, int>(20, 110));
            pieceTemplates[3].DrawSelf(e.Graphics, new Tuple<int, int>(20, 140));
            pieceTemplates[4].DrawSelf(e.Graphics, new Tuple<int, int>(20, 170));
            pieceTemplates[5].DrawSelf(e.Graphics, new Tuple<int, int>(20, 200));
            pieceTemplates[6].DrawSelf(e.Graphics, new Tuple<int, int>(20, 230));
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            //painting the grid
            Graphics g = e.Graphics;
            using(Pen p = new(Color.Black))
            {
                for (int y = 0; y < 20; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        g.DrawRectangle(p, new(x*scale, y*scale, 10 * scale, 10 * scale));
                    }
                }
            }
        }
    }
}
