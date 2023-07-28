using System.Runtime.InteropServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace ScanPicture
{
    public partial class Backup : Form1
    {
        int x;
        int y;
        int l;
        int w;
        int z;

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);


        private void btnScan_Click(object sender, EventArgs e)
        {
            l = 0;
            CaptureScreen();

        }
        private void CaptureScreen()
        {
            Bitmap myPic;
            Bitmap myPic2;
            myPic2 = new Bitmap("C:\\Users\\Winch\\Desktop\\Nox4.png");


            // Bild vom Bildschirm machen
            myPic = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics graphics = Graphics.FromImage(myPic as Image);

            graphics.CopyFromScreen(0, 0, 0, 0, myPic.Size);


            SearchForPicture(myPic2, myPic);

        }
        private bool SearchForPicture(Bitmap searchFor, Bitmap searchIn)
        {
            w = 0;
            z = 0;
            Color FarbeMyPic2 = searchFor.GetPixel(0, 0);

            for (x = 0; x < searchIn.Width; x++)
            {

                for (y = 0; y < searchIn.Height; y++)
                {

                    Color FarbeMyPic = searchIn.GetPixel(x, y);

                    FarbeMyPic2 = searchFor.GetPixel(w, z);

                    if (FarbeMyPic == FarbeMyPic2)
                    {
                        l++;

                        if (z + 1 < searchFor.Height)
                            z++;

                        if (searchFor.Height == z + 1)
                        {
                            if (w < searchFor.Width)
                                w++;

                            if (searchFor.Width == w || searchFor.Width < w)
                            {
                                MessageBox.Show("Gefunden bei x: " + x + " und " + " y: " + y + "\n" + "So oft hat es gepasst:" + l);
                                SetCursorPos(x, y);
                                return true;

                            }
                        }


                    }
                }
            }

            MessageBox.Show("Nicht gefunden!");
            return false;
        }

    }
}

