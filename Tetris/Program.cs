namespace Tetris
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
    public class TetrisPiece
    {
        public Tuple<int, int> Position = new Tuple<int, int>(0, 0);
        public List<Tuple<int, int>> Components;
        public Color PieceColor;

        public TetrisPiece(List<Tuple<int, int>> components, Color color)
        {
            Components = components;
            PieceColor = color;
        }
        public TetrisPiece ShallowCopy()
        {
            return (TetrisPiece)this.MemberwiseClone();
        }
        public void DrawSelf(Graphics graphics, Tuple<int, int> position = null)
        {
            if (position == null)
            {
                position = this.Position;
            }
            using (Pen pen = new Pen(PieceColor))
            {
                foreach(Tuple<int, int> component in Components)
                {
                    graphics.DrawRectangle(pen, new Rectangle(position.Item1 + component.Item1, position.Item2 + component.Item2, 10, 10));
                }
            }
        }
    }
}