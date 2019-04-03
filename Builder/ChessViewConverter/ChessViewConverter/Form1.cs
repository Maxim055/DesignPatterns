using ChessViewConverter.Writers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace ChessViewConverter
{
    public partial class Form1 : Form
    {
        private ReadersFactory rf { get; set; }
        private WritersFactory wf { get; set; }
        private string path;
        private IReader reader;
        private IWriter writer;

        public Form1()
        {
            InitializeComponent();
        }

        private void upload_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Office files | *.txt;*.doc;*.docx";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printFileInTB(openFileDialog1.FileName, textBox1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            uploadTypes.Items.Add("1");
            uploadTypes.Items.Add("2");
            uploadTypes.Items.Add("3");
            uploadTypes.SelectedIndex = 0;
            ResultType.Items.Add("1");
            ResultType.Items.Add("2");
            ResultType.Items.Add("3");
            ResultType.SelectedIndex = 0;
        }

        private void show_Click(object sender, EventArgs e)
        {
            this.path = openFileDialog1.FileName;
            this.rf = new ReadersFactory(openFileDialog1.FileName);

            this.wf = new WritersFactory(@"C:\Users\maxim\Desktop\result.txt");

            this.reader = this.rf.CreateReader("Reader" + uploadTypes.Text);
            this.writer = this.wf.CreateWriter("Writer" + ResultType.Text);
            var ReadResult = new List<ChessFigureCoords>();

            while (reader.Next())
            {
                ReadResult = reader.Read();
                this.writer.write(ReadResult);
            }
            this.writer.finalize();
            printFileInTB(@"C:\Users\maxim\Desktop\result.txt", textBox2);
        }

        /// <summary>
        /// printes file content in textbox
        /// </summary>
        /// <param name="path">file path</param>
        private void printFileInTB(string path, TextBox tb)
        {
            if (tb != null)
            {
                try
                {
                    using (var sr = new StreamReader(path))
                    {
                        tb.Text = sr.ReadToEnd();
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
}
