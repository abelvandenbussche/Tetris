using System.CodeDom.Compiler;

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
        public bool Fall(List<TetrisPiece> pieces)
        {
            bool landed = false;
            for(int index = 0; index < Components.Count; index++)
            {
                Tuple<int, int> pos = Components[index];
                pos = new(pos.Item1, pos.Item2 + 10);

                //checking if there is a piece under it now
                foreach(TetrisPiece piece in pieces)
                {
                    //checking if the piece is not the current piece
                    if (piece.Equals(this))
                    {
                        continue;
                    }

                    foreach(Tuple<int, int> otherPos in piece.Components)
                    {
                        if (otherPos.Item1 == pos.Item1 &&  otherPos.Item2 == pos.Item2 + 10)
                        {
                            landed = true;
                        }
                    }
                }
            }
            return landed;
        }
    }
}