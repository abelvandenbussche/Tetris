namespace Tetris
{
    public partial class Form1 : Form
    {
        //templates for the tetris pieces
        List<TetrisPiece> pieceTemplates = new List<TetrisPiece>()
        {
            new TetrisPiece(new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(20, 10),
                new Tuple<int, int>(10, 10),
                new Tuple<int, int>(-0, 10),
                new Tuple<int, int>(-10, 10)
            }, Color.Blue),
            new TetrisPiece(new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(15, 15),
                new Tuple<int, int>(15, 5),
                new Tuple<int, int>(5, 5),
                new Tuple<int, int>(-15, 5)
            }, Color.DarkBlue),
            new TetrisPiece(new List<Tuple<int, int>>
            {
                new Tuple<int, int>(-15, 15),
                new Tuple<int, int>(-15, 5),
                new Tuple<int, int>(-5, 5),
                new Tuple<int, int>(15, 5)
            }, Color.Orange),
            new TetrisPiece(new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(10, 10),
                new Tuple<int, int>(0, 10),
                new Tuple<int, int>(15, 0),
                new Tuple<int, int>(0, 0)
            }, Color.Yellow),
            new TetrisPiece(new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(15, 5),
                new Tuple<int, int>(5, 5),
                new Tuple<int, int>(5, 15),
                new Tuple<int, int>(-5, 15),
            }, Color.Green),
            new TetrisPiece(new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(15, 5),
                new Tuple<int, int>(5, 5),
                new Tuple<int, int>(5, 15),
                new Tuple<int, int>(-5, 5)
            }, Color.Purple),
            new TetrisPiece(new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(15, 15),
                new Tuple<int, int>(5, 15),
                new Tuple<int, int>(5, 5),
                new Tuple<int, int>(-5, 5)
            }, Color.Red)
        };
        public Form1()
        {
            InitializeComponent();
            //drawing some shit
        }
        private void PreviewPictureBox_Paint(object sender, PaintEventArgs e)
        {
            pieceTemplates[0].DrawSelf(e.Graphics, new Tuple<int, int>(50, 50));
            pieceTemplates[1].DrawSelf(e.Graphics, new Tuple<int, int>(50, 70));
            pieceTemplates[2].DrawSelf(e.Graphics, new Tuple<int, int>(50, 90));
            pieceTemplates[3].DrawSelf(e.Graphics, new Tuple<int, int>(50, 110));
            pieceTemplates[4].DrawSelf(e.Graphics, new Tuple<int, int>(50, 130));
            pieceTemplates[5].DrawSelf(e.Graphics, new Tuple<int, int>(50, 150));
        }
    }
}
