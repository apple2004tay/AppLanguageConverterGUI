using AppLanguageConverter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AppLanguageConverterGUI
{
    public partial class Form1 : Form
    {
        private string csvPath;
        private string outputPath;

        private int idColumn;
        private int headerRow;

        private bool replaceLineBreak;
        private bool createAllResx;

        private List<string> headerList = new List<string>();

        private LanguageConverter languageConverter = new LanguageConverter();

        public Form1()
        {
            InitializeComponent();
            LoadSetting();
        }

        private void LoadSetting()
        {
            csvPath = Properties.Settings.Default.CsvPath;
            csvPathText.Text = csvPath;

            outputPath = Properties.Settings.Default.OuputPath;
            outputPathText.Text = outputPath;

            idColumn = Properties.Settings.Default.IdColumn;
            idColumnText.Text = idColumn.ToString();

            headerRow = Properties.Settings.Default.HeaderRow;
            headerRowText.Text = headerRow.ToString();

            headerComboBox.SelectedIndex = Properties.Settings.Default.HeaderIndex;

            replaceLineBreak = Properties.Settings.Default.ReplaceLineBreak;
            replaceLineBreakCheckBox.Checked = replaceLineBreak;

            createAllResx = Properties.Settings.Default.CreateAllResx;
            createAllResxCheckBox.Checked = createAllResx;

            CheckAndSetOutputButton();
        }

        private void SaveSetting()
        {
            Properties.Settings.Default.CsvPath = csvPath;
            Properties.Settings.Default.OuputPath = outputPath;
            Properties.Settings.Default.IdColumn = idColumn;
            Properties.Settings.Default.HeaderRow = headerRow;
            Properties.Settings.Default.HeaderIndex = headerComboBox.SelectedIndex;
            Properties.Settings.Default.ReplaceLineBreak = replaceLineBreak;
            Properties.Settings.Default.CreateAllResx = createAllResx;
            Properties.Settings.Default.Save();
        }

        private void SearchFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "請選擇CSV檔",
                Filter = "所有檔案(*csv*)|*.csv*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                csvPath = openFileDialog.FileName;
                csvPathText.Text = csvPath;
                OpenCSV(csvPath);
            }
        }

        private void OutputPathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                Description = "請選擇輸出資料夾",
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
                {
                    outputPath = folderBrowserDialog.SelectedPath;
                    outputPathText.Text = outputPath;
                    CheckAndSetOutputButton();
                }
            }
        }

        private void LanguageIdColumnText_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(idColumnText.Text, out int column))
            {
                idColumn = column;
                OpenCSV(csvPath);
            }
        }

        private void HeaderRowText_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(headerRowText.Text, out int row))
            {
                headerRow = row;
                OpenCSV(csvPath);
            }
        }

        private void ReplaceLineBreakCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            replaceLineBreak = replaceLineBreakCheckBox.Checked;
        }

        private void CreateAllResxCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            createAllResx = createAllResxCheckBox.Checked;
        }

        private void SetHeaderText()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var header in headerList)
            {
                stringBuilder.Append(header);
                stringBuilder.Append(",");
            }

            if (stringBuilder.Length > 0)
            {
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }

            headerText.Text = stringBuilder.ToString();
        }

        private void SetHeaderComboBox()
        {
            headerComboBox.Items.Clear();
            foreach (var header in headerList)
            {
                headerComboBox.Items.Add(header);
            }

            if (headerComboBox.Items.Count > 0)
            {
                headerComboBox.SelectedIndex = 0;
            }
        }

        private void CheckAndSetOutputButton()
        {
            outputButton.Enabled = !string.IsNullOrEmpty(csvPath) && !string.IsNullOrEmpty(outputPath);
        }

        private void OutputButton_Click(object sender, EventArgs e)
        {
            if (createAllResx)
            {
                CreateAllLanguageResxFile(outputPath);
            }
            else
            {
                CreateMainLanguageResxFile(outputPath);
            }

            CreateXlfFile(outputPath);
            resultLabel.Text = "轉檔結束!";
            SaveSetting();
        }

        private void OpenCSV(string csvPath)
        {
            if (languageConverter.OpenLangaugeCsv(csvPath, headerRow, idColumn))
            {
                headerList = languageConverter.HeaderList;

                SetHeaderText();
                SetHeaderComboBox();
                CheckAndSetOutputButton();
            }
        }

        private void CreateMainLanguageResxFile(string path)
        {
            languageConverter.CreateMainLanguageResx(path, headerComboBox.SelectedIndex, replaceLineBreak);
        }

        private void CreateAllLanguageResxFile(string path)
        {
            languageConverter.CreateAllLanguageResx(path, headerComboBox.SelectedIndex, replaceLineBreak);
        }

        private void CreateXlfFile(string path)
        {
            languageConverter.CreateLanguageXlf(path, headerComboBox.SelectedIndex, replaceLineBreak);
        }
    }
}
