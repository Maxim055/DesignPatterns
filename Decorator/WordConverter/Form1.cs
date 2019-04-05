using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream originalFileStream = File.OpenRead(@"C:\Users\maxim.karapetyan\Desktop\eng.txt"))
            {
                using (FileStream Translated = File.OpenWrite(@"C:\Users\maxim.karapetyan\Desktop\result.txt"))
                {
                    using (En_Am_Stream compressionStream = new En_Am_Stream(Translated))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }
                }
            }
        }
    }
}
