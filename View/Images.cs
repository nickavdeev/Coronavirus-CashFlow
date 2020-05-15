using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CoronavirusCashFlow.View
{
    public static class Images
    {
        public static void SetProfile(int day) => Profile.Location = Positions[day];
        
        private static readonly List<Point> Positions = new List<Point>
        {
            new Point(425, 22), 
            new Point(425 + 1 * 88, 22), 
            new Point(425 + 2 * 88, 22), 
            new Point(425 + 3 * 88, 22), 
            new Point(425 + 4 * 88, 22), 
            new Point(425 + 5 * 88, 22),
            new Point(425 + 6 * 88, 22), 
            new Point(425 + 7 * 88, 22), 
            new Point(425 + 8 * 88, 22), 
            
            new Point(425 + 8 * 88, 22 + 1 * 84), 
            new Point(425 + 8 * 88, 22 + 2 * 84), 
            new Point(425 + 8 * 88, 22 + 3 * 84), 
            new Point(425 + 8 * 88, 22 + 4 * 84), 
            new Point(425 + 8 * 88, 22 + 5 * 84), 
            new Point(425 + 8 * 88, 22 + 6 * 84),
            new Point(425 + 8 * 88, 22 + 7 * 84),
            
            new Point(425 + 7 * 88, 22 + 7 * 84), 
            new Point(425 + 6 * 88, 22 + 7 * 84), 
            new Point(425 + 5 * 88, 22 + 7 * 84), 
            new Point(425 + 4 * 88, 22 + 7 * 84), 
            new Point(425 + 3 * 88, 22 + 7 * 84), 
            new Point(425 + 2 * 88, 22 + 7 * 84),
            new Point(425 + 1 * 88, 22 + 7 * 84), 
            
            new Point(425, 22 + 7 * 84),
            new Point(425, 22 + 6 * 84), 
            new Point(425, 22 + 5 * 84), 
            new Point(425, 22 + 4 * 84), 
            new Point(425, 22 + 3 * 84), 
            new Point(425, 22 + 2 * 84), 
            new Point(425, 22 + 1 * 84),
        };

        public static readonly PictureBox Profile = new PictureBox
        {
            ImageLocation = "https://image.flaticon.com/icons/png/512/2922/2922719.png", 
            Size = new Size(42, 42),
            Location = new Point(426, 22),
            BackColor = Color.Transparent,
            SizeMode = PictureBoxSizeMode.Zoom,
        };
    }
}