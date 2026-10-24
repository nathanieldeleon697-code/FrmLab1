using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLab1
{
    public partial class FrmFileName : Form
    {
        private string _textToSave;

        public FrmFileName(string textToSave)
        {
            InitializeComponent();
            _textToSave = textToSave;
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            string fileNameInput = txtFileName.Text.Trim();

            if (string.IsNullOrWhiteSpace(fileNameInput))
            {
                MessageBox.Show("Please enter a valid file name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!Regex.IsMatch(fileNameInput, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Letters and spaces only are allowed in the file name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!fileNameInput.Equals(_textToSave, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"File name must strictly match the text you entered earlier: \"{_textToSave}\"", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string fileName = fileNameInput;
                if (!fileName.EndsWith(".txt"))
                {
                    fileName += ".txt";
                }

                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(docPath, fileName);

                using (StreamWriter outputFile = new StreamWriter(filePath))
                {
                    outputFile.WriteLine(_textToSave);
                }

                MessageBox.Show($"File successfully created at:\n{filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}