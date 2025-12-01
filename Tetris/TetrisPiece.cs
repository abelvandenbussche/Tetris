namespace Tetris
{
    public class TetrisPiece
    {
        public Tuple<int, int> Position = new Tuple<int, int>(0, 0);
        private Tuple<int, int> Center;
        public List<Tuple<int, int>> Components;
        public Color PieceColor;

        public TetrisPiece(List<Tuple<int, int>> components, Tuple<int, int> center, Color color)
        {
            Center = center;
            Components = components;
            PieceColor = color;
        }
        public TetrisPiece ShallowCopy()
        {
            return (TetrisPiece)this.MemberwiseClone();
        }
        public void DrawSelf(Graphics graphics, Tuple<int, int> position=null!)
        {
            //if the position is null it is changed to the objects postion
            position ??= this.Position;
            using (Brush brush = new SolidBrush(PieceColor))
            {
                foreach(Tuple<int, int> component in Components)
                {
                    graphics.FillRectangle(brush, new Rectangle(position.Item1 + component.Item1, position.Item2 + component.Item2, 10, 10));
                }
                graphics.FillRectangle(Brushes.Black, new Rectangle(position.Item1 + this.Center.Item1 - 2, position.Item2 + this.Center.Item2 - 2, 4, 4));
            }
        }
    }
}