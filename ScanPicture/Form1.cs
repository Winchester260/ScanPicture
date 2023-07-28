using System.Runtime.InteropServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace ScanPicture
{
    public partial class Form1 : Form
    {
        Bitmap myPic;
        Bitmap myPic2;
        Color FarbeMyPic2;
        bool invalid;
        int x;
        int koordinatex;
        int y;
        int koordinatey;
        int w;
        int z;
        int l;
        string hexcode = "";
        int count;
        int bot = 0;
        string hex = "#E36B0C";


        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        public static void LeftMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void lLabelOpenPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CaptureScreenFromPath();
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            l = 0;

            
            CaptureScreen();

            
            SearchForPicture(myPic2, myPic);

        }
        Bitmap CaptureScreen() //Bild vom Desktop machen und speichern
        {
            // Take an image from the screen
            myPic = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); // Create an empty bitmap with the size of the current screen 

            Graphics graphics = Graphics.FromImage(myPic as Image); // Create a new graphics objects that can capture the screen

            graphics.CopyFromScreen(0, 0, 0, 0, myPic.Size); // Screenshot moment → screen content to graphics object
            
            
            return myPic;
        }
        Bitmap CaptureScreenFromPath()
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Select file to be upload";
            fDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            //  fDialog.Filter = "";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                myPic2 = new Bitmap(fDialog.FileName);
            }
            return myPic2;
        }
        private bool SearchForPictureThroughHexCode(Bitmap searchIn, string hexcode)
        {
            count = 0;
            for (x = 0; x < 1920; x++)
            {

                for (y = 0; y < 1080; y++)
                {

                    Color FarbeMyPic = searchIn.GetPixel(x, y);

                    Color desiredPixelColor = ColorTranslator.FromHtml(hexcode);

                    if (desiredPixelColor == FarbeMyPic)
                    {   count++;
                        if (count > 3)
                        {
                            
                            //MessageBox.Show("Found Pixel at x: " + x + ", y: " + y + " - Now set mouse cursor" + "\n" + "Pixel found: " + count);
                            //txtScanErg.Text = "Gefunden";


                            //SetCursorPos(x, y);
                            // System.Threading.Thread.Sleep(500);
                           // LeftMouseClick(x, y);
                            

                            // desiredPixelColor = ColorTranslator.FromHtml(Convert.ToString(0x1B1A1E)); //Damit Mehrere gleiche Farbcodes nicht anvisiert werden
                        }
                    }
                }
            }
            MessageBox.Show("So oft hat es gepasst:" + count);
            return false;
        }

        private bool SearchForPicture(Bitmap searchFor, Bitmap searchIn)
        {
                if (searchFor == null)
                {
                    MessageBox.Show("Bitte laden sie vorher ein Bild hoch!");
                    return false;
                }
                w = 0;
                z = 0;
                invalid = false;


                FarbeMyPic2 = searchFor.GetPixel(0, 0);


                for (x = 0; x < 1920; x++)
                {

                    for (y = 0; y < 1080; y++)
                    {

                        Color FarbeMyPic = searchIn.GetPixel(x, y);
                        try
                        {
                            FarbeMyPic2 = searchFor.GetPixel(w, z);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            w = searchFor.Width - 1;
                        }

                        if (FarbeMyPic == FarbeMyPic2)
                        {
                            l++;
                            koordinatex = x;
                            koordinatey = y;

                            if (invalid)
                            {
                                z++;
                                w = searchFor.Width - 1;
                            }
                            else
                            {

                                if (z + 1 < searchFor.Height)
                                    z++;


                                if (searchFor.Height == z + 1)
                                {
                                    if (w - 2 < searchFor.Width)
                                    {
                                        z = 0;
                                        w++;
                                        if (w + 1 == searchFor.Width)
                                        {
                                            invalid = true;
                                        }
                                    }


                                }
                            }

                            if (searchFor.Width == w + 1 && searchFor.Height == z + 1)
                            {
                                MessageBox.Show("Gefunden bei x: " + koordinatex + " und " + " y: " + koordinatey + "\n" + "So oft hat es gepasst:" + l);
                                //SetCursorPos(koordinatex, koordinatey);
                                //LeftMouseClick(koordinatex, koordinatey);
                                return true;
                               

                            }


                        }
                    }
                }
                if (w == 0 && z == 0)
                {
                    MessageBox.Show("Nicht gefunden!");
                    return false;
                }
                else
                {
                    MessageBox.Show("Gefunden bei x: " + koordinatex + " und " + " y: " + koordinatey + "\n" + "So oft hat es gepasst:" + l);
                    SetCursorPos(koordinatex, koordinatey);
                   // LeftMouseClick(koordinatex, koordinatey);

                        return true;
                }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            int lenght = 0;
            lenght = txtScanErg.Text.Length;
            if (lenght == 7)
            {
                hexcode = txtScanErg.Text;
                CaptureScreen();
                SearchForPictureThroughHexCode(myPic, hexcode);
            }
            else
            {
                MessageBox.Show("Bitte geben Sie die gesuchte Farbe richtig in Hexcode Format ein!");

            }
        }

        private bool Bot(Bitmap searchFor, Bitmap searchIn)
        {

            while (bot < 2)
            {
                if (bot == 1)
                {
                  searchFor = new Bitmap(@"C:\Users\Winch\Desktop\Kampffinden.png");
                }
                if (searchFor == null)
                {
                    MessageBox.Show("Bitte laden sie vorher ein Bild hoch!");
                    return false;
                }
                w = 0;
                z = 0;
                invalid = false;


                FarbeMyPic2 = searchFor.GetPixel(0, 0);


                for (x = 0; x < 1920; x++)
                {

                    for (y = 0; y < 1080; y++)
                    {

                        Color FarbeMyPic = searchIn.GetPixel(x, y);
                        try
                        {
                            FarbeMyPic2 = searchFor.GetPixel(w, z);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            w = searchFor.Width - 1;
                        }

                        if (FarbeMyPic == FarbeMyPic2)
                        {
                            l++;
                            koordinatex = x;
                            koordinatey = y;

                            if (invalid)
                            {
                                z++;
                                w = searchFor.Width - 1;
                            }
                            else
                            {

                                if (z + 1 < searchFor.Height)
                                    z++;


                                if (searchFor.Height == z + 1)
                                {
                                    if (w - 2 < searchFor.Width)
                                    {
                                        z = 0;
                                        w++;
                                        if (w + 1 == searchFor.Width)
                                        {
                                            invalid = true;
                                        }
                                    }


                                }
                            }

                            if (searchFor.Width == w + 1 && searchFor.Height == z + 1)
                            {
                                MessageBox.Show("Gefunden bei x: " + koordinatex + " und " + " y: " + koordinatey + "\n" + "So oft hat es gepasst:" + l);
                                SetCursorPos(koordinatex, koordinatey);
                                LeftMouseClick(koordinatex, koordinatey);

                                bot++;
                                if (bot == 2)
                                    return true;


                            }


                        }
                    }
                }
                if (w == 0 && z == 0)
                {
                    MessageBox.Show("Nicht gefunden!");
                    return false;
                }
                else
                {
                    MessageBox.Show("Gefunden bei x: " + koordinatex + " und " + " y: " + koordinatey + "\n" + "So oft hat es gepasst:" + l);
                    SetCursorPos(koordinatex, koordinatey);
                    LeftMouseClick(koordinatex, koordinatey);
                    bot++;
                    if (bot == 2)
                        return true;
                }
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
    }



