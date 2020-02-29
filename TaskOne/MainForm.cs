using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskOne
{
    public partial class MainForm : Form
    {
        UserFile currentFile = new UserFile(@"Y:\", @"Y:\test.exe");
        UserFile newFile = new UserFile(@"Y:\new", @"Y:\new\test.exe");
        public MainForm()
        {
            InitializeComponent();
            VersionValue.Text = currentFile.Version.ToString();
            UpdateButton.Click += UpdateButton_Click;

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (newFile.HasNewerVersionThen(currentFile))
            {
                currentFile.UpdateFileToVersion(newFile);
                MessageBox.Show("Обновление завершено");
            }

            Application.Restart();
        }
    }
}
