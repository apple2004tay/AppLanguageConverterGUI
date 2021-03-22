namespace AppLanguageConverterGUI
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.csvPathText = new System.Windows.Forms.TextBox();
            this.searchFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.idColumnText = new System.Windows.Forms.TextBox();
            this.headerRowText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.headerText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.outputPathText = new System.Windows.Forms.TextBox();
            this.outputPathButton = new System.Windows.Forms.Button();
            this.outputButton = new System.Windows.Forms.Button();
            this.headerComboBox = new System.Windows.Forms.ComboBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.replaceLineBreakCheckBox = new System.Windows.Forms.CheckBox();
            this.createAllResxCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // csvPathText
            // 
            this.csvPathText.Enabled = false;
            this.csvPathText.Location = new System.Drawing.Point(24, 13);
            this.csvPathText.Name = "csvPathText";
            this.csvPathText.Size = new System.Drawing.Size(326, 22);
            this.csvPathText.TabIndex = 0;
            // 
            // searchFileButton
            // 
            this.searchFileButton.Location = new System.Drawing.Point(356, 13);
            this.searchFileButton.Name = "searchFileButton";
            this.searchFileButton.Size = new System.Drawing.Size(75, 23);
            this.searchFileButton.TabIndex = 1;
            this.searchFileButton.Text = "選擇CSV";
            this.searchFileButton.UseVisualStyleBackColor = true;
            this.searchFileButton.Click += new System.EventHandler(this.SearchFileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "LanguageID Column";
            // 
            // idColumnText
            // 
            this.idColumnText.Location = new System.Drawing.Point(132, 72);
            this.idColumnText.Name = "idColumnText";
            this.idColumnText.Size = new System.Drawing.Size(100, 22);
            this.idColumnText.TabIndex = 3;
            this.idColumnText.TextChanged += new System.EventHandler(this.LanguageIdColumnText_TextChanged);
            // 
            // headerRowText
            // 
            this.headerRowText.Location = new System.Drawing.Point(132, 100);
            this.headerRowText.Name = "headerRowText";
            this.headerRowText.Size = new System.Drawing.Size(100, 22);
            this.headerRowText.TabIndex = 5;
            this.headerRowText.TextChanged += new System.EventHandler(this.HeaderRowText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Header Row";
            // 
            // headerText
            // 
            this.headerText.AutoSize = true;
            this.headerText.Location = new System.Drawing.Point(60, 131);
            this.headerText.Name = "headerText";
            this.headerText.Size = new System.Drawing.Size(0, 12);
            this.headerText.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "語系:";
            // 
            // outputPathText
            // 
            this.outputPathText.Enabled = false;
            this.outputPathText.Location = new System.Drawing.Point(24, 42);
            this.outputPathText.Name = "outputPathText";
            this.outputPathText.Size = new System.Drawing.Size(326, 22);
            this.outputPathText.TabIndex = 8;
            // 
            // outputPathButton
            // 
            this.outputPathButton.Location = new System.Drawing.Point(357, 40);
            this.outputPathButton.Name = "outputPathButton";
            this.outputPathButton.Size = new System.Drawing.Size(75, 23);
            this.outputPathButton.TabIndex = 9;
            this.outputPathButton.Text = "輸入資料夾";
            this.outputPathButton.UseVisualStyleBackColor = true;
            this.outputPathButton.Click += new System.EventHandler(this.OutputPathButton_Click);
            // 
            // outputButton
            // 
            this.outputButton.Enabled = false;
            this.outputButton.Location = new System.Drawing.Point(24, 228);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(75, 23);
            this.outputButton.TabIndex = 10;
            this.outputButton.Text = "轉檔";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.OutputButton_Click);
            // 
            // headerComboBox
            // 
            this.headerComboBox.FormattingEnabled = true;
            this.headerComboBox.Location = new System.Drawing.Point(24, 157);
            this.headerComboBox.Name = "headerComboBox";
            this.headerComboBox.Size = new System.Drawing.Size(121, 20);
            this.headerComboBox.TabIndex = 11;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.resultLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.resultLabel.Location = new System.Drawing.Point(105, 227);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 20);
            this.resultLabel.TabIndex = 12;
            // 
            // replaceLineBreakCheckBox
            // 
            this.replaceLineBreakCheckBox.AutoSize = true;
            this.replaceLineBreakCheckBox.Location = new System.Drawing.Point(24, 183);
            this.replaceLineBreakCheckBox.Name = "replaceLineBreakCheckBox";
            this.replaceLineBreakCheckBox.Size = new System.Drawing.Size(153, 16);
            this.replaceLineBreakCheckBox.TabIndex = 13;
            this.replaceLineBreakCheckBox.Text = "換行符號取代字串中的\\n";
            this.replaceLineBreakCheckBox.UseVisualStyleBackColor = true;
            this.replaceLineBreakCheckBox.CheckedChanged += new System.EventHandler(this.ReplaceLineBreakCheckBox_CheckedChanged);
            // 
            // createAllResxCheckBox
            // 
            this.createAllResxCheckBox.AutoSize = true;
            this.createAllResxCheckBox.Location = new System.Drawing.Point(24, 206);
            this.createAllResxCheckBox.Name = "createAllResxCheckBox";
            this.createAllResxCheckBox.Size = new System.Drawing.Size(139, 16);
            this.createAllResxCheckBox.TabIndex = 14;
            this.createAllResxCheckBox.Text = "創建所有語系的resx檔";
            this.createAllResxCheckBox.UseVisualStyleBackColor = true;
            this.createAllResxCheckBox.CheckedChanged += new System.EventHandler(this.CreateAllResxCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 287);
            this.Controls.Add(this.createAllResxCheckBox);
            this.Controls.Add(this.replaceLineBreakCheckBox);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.headerComboBox);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.outputPathButton);
            this.Controls.Add(this.outputPathText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.headerText);
            this.Controls.Add(this.headerRowText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idColumnText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchFileButton);
            this.Controls.Add(this.csvPathText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox csvPathText;
        private System.Windows.Forms.Button searchFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idColumnText;
        private System.Windows.Forms.TextBox headerRowText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label headerText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox outputPathText;
        private System.Windows.Forms.Button outputPathButton;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.ComboBox headerComboBox;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.CheckBox replaceLineBreakCheckBox;
        private System.Windows.Forms.CheckBox createAllResxCheckBox;
    }
}

