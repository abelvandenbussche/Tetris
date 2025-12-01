namespace Tetris
{
    public partial class Form1 : Form
    {
        //TODO: implement scale properly
        int scale = 2;
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
            //drawing some shit
        }
        private void PreviewPictureBox_Paint(object sender, PaintEventArgs e)
        {
            pieceTemplates[0].DrawSelf(e.Graphics, new Tuple<int, int>(50, 50));
            pieceTemplates[1].DrawSelf(e.Graphics, new Tuple<int, int>(50, 80));
            pieceTemplates[2].DrawSelf(e.Graphics, new Tuple<int, int>(50, 110));
            pieceTemplates[3].DrawSelf(e.Graphics, new Tuple<int, int>(50, 140));
            pieceTemplates[4].DrawSelf(e.Graphics, new Tuple<int, int>(50, 170));
            pieceTemplates[5].DrawSelf(e.Graphics, new Tuple<int, int>(50, 200));
            pieceTemplates[6].DrawSelf(e.Graphics, new Tuple<int, int>(50, 230));
        }
    }
}
