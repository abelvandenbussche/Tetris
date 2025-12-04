using System.Drawing.Text;

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
        public void DrawSelf(Graphics graphics, int scale, Tuple<int, int> position = null!)
        {
            //if the position is null it is changed to the objects postion
            position ??= this.Position;
            using (Brush brush = new SolidBrush(PieceColor))
            {
                foreach (Tuple<int, int> component in Components)
                {
                    graphics.FillRectangle(brush, new Rectangle((position.Item1 + component.Item1) * scale, (position.Item2 + component.Item2) * scale, 10 * scale, 10 * scale));
                }
            }
        }
       //checks if the piece has landed
        public bool CheckLanded(List<TetrisPiece> pieces)
        {
            bool landed = false;
            foreach (Tuple<int, int> pos in this.Components)
            {
                foreach (TetrisPiece piece in pieces)
                {
                    //checking if the piece is not the current piece
                    if (piece.Equals(this))
                    {
                        continue;
                    }
                    foreach (Tuple<int, int> otherPos in piece.Components)
                    {
                        //hit other pieces
                        if (otherPos.Item1 + piece.Position.Item1 == pos.Item1 + Position.Item1 && otherPos.Item2 + piece.Position.Item2 == pos.Item2 + Position.Item2 + 10)
                        {
                            landed = true;
                        }
                    }
                }
                //hit the floor
                if (pos.Item2 + Position.Item2 >= 190)
                {
                    landed = true;
                }
            }
            return landed;
        }

        public bool Fall(List<TetrisPiece> pieces)
        {
            //checking if something went wrong with the previous code
            // - ChatGPT
            if (CheckLanded(pieces) )
            {
                return true;
            }
            this.Position = new(this.Position.Item1, this.Position.Item2 + 10);
            //checking if there is a piece under it now
            
            return CheckLanded(pieces);
        }
        public void Rotate(List<TetrisPiece> pieces)
        {
            List<Tuple<int, int>> oldComponents = Components;
            List<Tuple<int, int>> newComponents = new();
            foreach (Tuple<int, int> component in Components)
            {
                int rotatedX = Center.Item1 - (component.Item2 - Center.Item2) - 10;
                int rotatedY = Center.Item2 + (component.Item1 - Center.Item1);
                newComponents.Add(new Tuple<int, int>(rotatedX, rotatedY));
            }
            foreach (Tuple<int, int> component in newComponents)
            {
                //checking if the pieces are not overlapping the borders
                if (component.Item1 + Position.Item1 < 0)
                {
                    Position = new(Position.Item1 + 10, Position.Item2);
                }
                else if (component.Item1 + Position.Item1 > 90)
                {
                    Position = new(Position.Item1 - 10, Position.Item2);
                }
                //checking if we are overlapping other pieces
                foreach(TetrisPiece otherPiece in pieces)
                {
                    if (otherPiece.Equals(this))
                    {
                        continue;
                    }
                    foreach (Tuple<int, int> otherComponent in otherPiece.Components)
                    {
                        if (otherComponent.Item1 + otherPiece.Position.Item1 == component.Item1 + Position.Item1 && otherComponent.Item2 + otherPiece.Position.Item2 == component.Item2 + Position.Item2)
                        {
                            //restoring old components
                            newComponents = oldComponents;
                        }
                    }
                }

            }
            Components = newComponents;
        }
    }
}