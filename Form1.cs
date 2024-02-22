using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppImagedopHW2102
{
    public partial class Form1 : Form
    {
        private List<string> imagePaths = new List<string>();
        private int currentIndex = 0;
        public static ManualResetEvent mre = new ManualResetEvent(false);
        private Form2 form2;
        public Form1()
        {
            InitializeComponent();
            InitializeImagePaths();
            form2 = new Form2(imagePaths);
            form2.Show();
        }
        private void InitializeImagePaths()
        {
            imagePaths.Add(@"Image\1aecc87120284f958f66e12c475d79e4.jpg");
            imagePaths.Add(@"Image\21a5b50f6bfc4f3fa37392b5e1e72471.jpg");
            imagePaths.Add(@"Image\9fbf59454a644176897a721e0593e1da.jpg");
            imagePaths.Add(@"Image\cd28906a2f3a431abc3ac6a0065bacc8.jpg");
        }
        private void startButton_Click_1(object sender, EventArgs e)
        {
            mre.Set(); // Сигнал для начала показа картинок
            
        }
        private void stopButton_Click_1(object sender, EventArgs e)
        {
            mre.Reset(); // Остановка показа картинок
           
        }
        private void nextButton_Click(object sender, EventArgs e)
        {
            ShowNextImage();
        }
        private void ShowNextImage()
        {
            if (imagePaths.Count == 0) return;
            currentIndex = (currentIndex + 1) % imagePaths.Count;
            pictureBox1.Image = Image.FromFile(imagePaths[currentIndex]);
        }
        private void previousButton_Click(object sender, EventArgs e)
        {
            ShowPreviousImage();
        }
        private void ShowPreviousImage()
        {
            if (imagePaths.Count == 0) return;
            currentIndex = (currentIndex - 1 + imagePaths.Count) % imagePaths.Count;
            pictureBox1.Image = Image.FromFile(imagePaths[currentIndex]);
        }
    }
}

