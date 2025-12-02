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
        public void DrawSelf(Graphics graphics, int scale, Tuple<int, int> position=null!)
        {
            //if the position is null it is changed to the objects postion
            position ??= this.Position;
            using (Brush brush = new SolidBrush(PieceColor))
            {
                foreach(Tuple<int, int> component in Components)
                {
                    graphics.FillRectangle(brush, new Rectangle((position.Item1 + component.Item1) * scale, (position.Item2 + component.Item2) * scale, 10 * scale, 10 * scale));
                }
                graphics.FillRectangle(Brushes.Black, new Rectangle((position.Item1 + this.Center.Item1 - 2) * scale, (position.Item2 + this.Center.Item2 - 2) * scale, 4, 4));
            }
        }
        public bool Fall(List<TetrisPiece> pieces)
        {
            bool landed = false;
            this.Position = new(this.Position.Item1, this.Position.Item2 + 10);
            //checking if there is a piece under it now
            foreach(Tuple<int, int> pos in this.Components)
            {
                foreach(TetrisPiece piece in pieces)
                {
                    //checking if the piece is not the current piece
                    if (piece.Equals(this))
                    {
                        continue;
                    }
                    foreach(Tuple<int, int> otherPos in piece.Components)
                    {
                        //hit other pieces
                        if (otherPos.Item1 + piece.Position.Item1 == pos.Item1 + Position.Item1 && otherPos.Item2 + piece.Position.Item2 == pos.Item2 + Position.Item2 + 10)
                        {
                            landed = true;
                        }
                    }
                }
                //hit the floor
                System.Diagnostics.Debug.WriteLine(pos.Item2 + Position.Item2);
                if (pos.Item2 + Position.Item2 >= 190)
                {
                    landed = true;
                }
            }
            System.Diagnostics.Debug.WriteLine(landed);
            return landed;
        }
        public void Rotate()
        {
            List<Tuple<int, int>> newComponents = new();
            foreach(Tuple<int, int> component in Components)
            {
                int relativeX = component.Item1 - Center.Item1;
                int relativeY = component.Item2 - Center.Item2;
                int rotatedX = -relativeY + Center.Item1;
                int rotatedY = relativeX + Center.Item2;
                newComponents.Add(new Tuple<int, int>(rotatedX, rotatedY));
            }
            Components = newComponents;
        }
    }
}