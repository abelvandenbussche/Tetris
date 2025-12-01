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
                new Tuple<int, int>(-10, 10),
                new Tuple<int, int>(-20, 10)
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
            }, Color.Purple)
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
        }
    }
}
