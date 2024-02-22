using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppImagedopHW2102
{
    public partial class Form2 : Form
    {
        private List<string> imagePaths;
        private int currentIndex = 0;
        private Thread slideshowThread;
        public Form2(List<string> paths)
        {
            InitializeComponent();
            imagePaths = paths; 
            StartSlideshowThread(); 
        }

        private void StartSlideshowThread()
        {
            slideshowThread = new Thread(() =>
            {
                while (true)
                {
                    Form1.mre.WaitOne();
                    Invoke((MethodInvoker)(() =>
                    {
                        if (imagePaths.Count > 0)
                        {
                            currentIndex = (currentIndex + 1) % imagePaths.Count;
                            pictureBox1.Image = Image.FromFile(imagePaths[currentIndex]);
                        }
                    }));
                    Thread.Sleep(2000); 
                }
            })
            { IsBackground = true };
            slideshowThread.Start();
        }
    }
}

    

