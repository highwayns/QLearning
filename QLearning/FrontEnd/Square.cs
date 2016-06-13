using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLearning.FrontEnd
{
    public class Square
    {
        #region Constructor

        public Square(Point position, int number, Brush color)
        {
            this.Position = position;
            this.Number = number;
            this.Color = color;
        }

        #endregion

        #region Constants

        public const int SIZE = 60;

        #endregion

        #region Attributes and Properties

        public Point Position;
        public int Number;
        public Brush Color;

        #endregion

        #region Public Methods

        public void Draw(Graphics g)
        {
            var font = new Font(FontFamily.GenericSansSerif, 20f, FontStyle.Bold);

            g.FillRectangle(this.Color, new Rectangle(this.Position, new Size(SIZE, SIZE)));
            g.DrawRectangle(new Pen(Brushes.Black, 5f), new Rectangle(this.Position, new Size(SIZE, SIZE)));
            g.DrawString(this.Number.ToString(), font, Brushes.Black, new PointF(Position.X + SIZE / 2 - font.Size, Position.Y));
        }

        #endregion
    }
}
