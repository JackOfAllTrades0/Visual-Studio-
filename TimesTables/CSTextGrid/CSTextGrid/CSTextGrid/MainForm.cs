using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSTextGrid
{
    //
    // This class handles all the rendering of the text grid
    //
    public class TextGrid : Panel 
    {
        const int gridHeight = 8;
        const int gridWidth = 13;
        char[,] contents;
        Color[,] fgColours;
        Color[,] bgColours;
        Font font;

        public TextGrid()
        {
            BackColor = Color.Blue;
            InitialiseGrid(60, 60);
            font = new Font("Courier", 8);
            Console.WriteLine(font);
        }

        public void InitialiseGrid(int width, int height)
        {
            contents = new char[width, height];
            fgColours = new Color[width, height];
            bgColours = new Color[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    contents[x, y] = ' ';
                    fgColours[x, y] = Color.Black;
                    bgColours[x, y] = Color.White;
                }
            }
            this.MinimumSize = new Size(width * gridWidth, height * gridHeight);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

           // e.Graphics.FillRectangle(new SolidBrush(Color.Red), 10, 10, 15, 16);
            for (int y = 0; y < GetGridHeight(); y++)
            {
                for (int x = 0; x < GetGridWidth(); x++)
                {
                    Rectangle gridRect = GetGridRect(x, y); 
                    e.Graphics.FillRectangle(new SolidBrush(bgColours[x, y]), gridRect);
                    e.Graphics.DrawString(""+contents[x,y], font, new SolidBrush(fgColours[x, y]), gridRect);
                }
            }
        }

        public int GetGridWidth()
        {
            return contents.GetLength(0);
        }

        public int GetGridHeight()
        {
            return contents.GetLength(1);
        }

        public Rectangle GetGridRect(int x, int y)
        {
            return new Rectangle(x * gridWidth, y * gridHeight, gridWidth, gridHeight);
        }

        public void SetGridCell(int x, int y, char c)
        {
            SetGridCell(x, y, c, Color.Black, Color.White);
        }

        public void SetGridCell(int x, int y, char c, Color fg, Color bg)
        {
            contents[x, y] = c;
            fgColours[x, y] = fg;
            bgColours[x, y] = bg;
        }
    }

    //
    //  The Player class handles everything about the player
    //
    public class Player
    {
        private int x;
        private int y;
        private TextGrid textGrid;
        public static Color colour = Color.White;

        public Player(int _x, int _y, TextGrid _textGrid)
        {
            x = _x;
            y = _y;
            textGrid = _textGrid;

            textGrid.SetGridCell(x, y, '@', Color.Red, Color.Yellow);

        }

        public void MoveBy(int dx, int dy)
        {
            textGrid.SetGridCell(x, y, ' ', Color.Black, colour);
            x += dx;

            if (x < 0) x = 0;
            if (x >= textGrid.GetGridWidth()) x = textGrid.GetGridWidth() - 1;

            y += dy;

            if (y < 0) y = 0;
            if (y >= textGrid.GetGridHeight()) y = textGrid.GetGridHeight() - 1;

            textGrid.SetGridCell(x, y, '@', Color.Red, Color.Yellow);
        }

        public Rectangle GetRect()
        {
            return textGrid.GetGridRect(x, y);
        }
    }

    //
    //  The MainForm class handles everything about the application window
    //
    public class MainForm : Form
    {
        private TextGrid textGrid;
        private Player player;

        public MainForm()
        {
            textGrid = new TextGrid();
            textGrid.Dock = DockStyle.Fill;
            this.Controls.Add(textGrid);

            player = new Player(10, 10, textGrid);

            initialiseMap();
        }

        private void initialiseMap()
        {
            // write code in here using for loops to draw a map for the player to move around
            // SetGridCell(x, y, char, foreground, background)
            textGrid.SetGridCell(2, 4, '#', Color.Black, Color.Gray);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = textGrid.MinimumSize;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // tell textGrid control to redraw where player was
            textGrid.Invalidate(player.GetRect());

            switch(keyData)
            {
                case Keys.Up:
                    player.MoveBy(0, -1);
                    break;
                case Keys.Down:
                    player.MoveBy(0, 1);
                    break;
                case Keys.Left:
                    player.MoveBy(-1, 0);
                    break;
                case Keys.Right:
                    player.MoveBy(1, 0);
                    break;
                //case Keys.Space:
                   // if (Player.colour == Color.White)
                        //Player.colour = Color.Black;
                    //else 
                        //Player.colour = Color.White;
                    // break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

            // tell textGrid control to redraw where player now is
            textGrid.Invalidate(player.GetRect());
            return true;
        }

        public static void Main()
        {
            Application.Run(new MainForm());
        }
    }
}
