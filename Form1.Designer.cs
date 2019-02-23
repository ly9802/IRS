namespace _647project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.indexdirectory = new System.Windows.Forms.Button();
            this.path = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.sourcedirectory = new System.Windows.Forms.Button();
            this.sourcepath = new System.Windows.Forms.Label();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.InfoNeed = new System.Windows.Forms.Label();
            this.ToQuery = new System.Windows.Forms.Button();
            this.QueryList = new System.Windows.Forms.Label();
            this.PreProcess = new System.Windows.Forms.CheckBox();
            this.SearchOutput = new System.Windows.Forms.TextBox();
            this.Resultlabel = new System.Windows.Forms.Label();
            this.Searchtime = new System.Windows.Forms.Label();
            this.Indextime = new System.Windows.Forms.Label();
            this.NextTen = new System.Windows.Forms.Button();
            this.LastTen = new System.Windows.Forms.Button();
            this.AbstractDetails = new System.Windows.Forms.Button();
            this.labelofid = new System.Windows.Forms.Label();
            this.comboBoxofid = new System.Windows.Forms.ComboBox();
            this.Field = new System.Windows.Forms.ComboBox();
            this.FieldName = new System.Windows.Forms.Label();
            this.Botton_InfoNeed = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.InfoNeedFilePath = new System.Windows.Forms.Label();
            this.Button_Import = new System.Windows.Forms.Button();
            this.comboBoxofqueryid = new System.Windows.Forms.ComboBox();
            this.label_queryid = new System.Windows.Forms.Label();
            this.Button_Save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.labelofresultfile = new System.Windows.Forms.Label();
            this.Button_Close = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labeloffinalquery = new System.Windows.Forms.Label();
            this.ButtonForCreate = new System.Windows.Forms.Button();
            this.LinguisticLevel = new System.Windows.Forms.ComboBox();
            this.textBoxforquery = new System.Windows.Forms.TextBox();
            this.buttonofExpandQuery = new System.Windows.Forms.Button();
            this.labelofprompt = new System.Windows.Forms.Label();
            this.Titleboostcheckbox = new System.Windows.Forms.CheckBox();
            this.Authorboostcheckbox = new System.Windows.Forms.CheckBox();
            this.comboBoxoftitleboost = new System.Windows.Forms.ComboBox();
            this.comboBoxofauthorboost = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // indexdirectory
            // 
            this.indexdirectory.Location = new System.Drawing.Point(23, 4);
            this.indexdirectory.Name = "indexdirectory";
            this.indexdirectory.Size = new System.Drawing.Size(105, 23);
            this.indexdirectory.TabIndex = 0;
            this.indexdirectory.Text = "IndexDirectory";
            this.indexdirectory.UseVisualStyleBackColor = true;
            this.indexdirectory.Click += new System.EventHandler(this.indexdirectory_Click);
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(136, 9);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(391, 23);
            this.path.TabIndex = 1;
            this.path.Text = "Index File Path";
            this.path.Click += new System.EventHandler(this.path_Click);
            // 
            // sourcedirectory
            // 
            this.sourcedirectory.Location = new System.Drawing.Point(25, 36);
            this.sourcedirectory.Name = "sourcedirectory";
            this.sourcedirectory.Size = new System.Drawing.Size(103, 23);
            this.sourcedirectory.TabIndex = 2;
            this.sourcedirectory.Text = "SourceDirectory";
            this.sourcedirectory.UseVisualStyleBackColor = true;
            this.sourcedirectory.Click += new System.EventHandler(this.sourcedirectory_Click);
            // 
            // sourcepath
            // 
            this.sourcepath.Location = new System.Drawing.Point(136, 41);
            this.sourcepath.Name = "sourcepath";
            this.sourcepath.Size = new System.Drawing.Size(387, 18);
            this.sourcepath.TabIndex = 3;
            this.sourcepath.Text = "SourceFilePath";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 101);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(600, 35);
            this.textBox1.TabIndex = 5;
            // 
            // InfoNeed
            // 
            this.InfoNeed.AutoSize = true;
            this.InfoNeed.Location = new System.Drawing.Point(30, 101);
            this.InfoNeed.Name = "InfoNeed";
            this.InfoNeed.Size = new System.Drawing.Size(65, 12);
            this.InfoNeed.TabIndex = 6;
            this.InfoNeed.Text = "Search Box";
            this.InfoNeed.Click += new System.EventHandler(this.InfoNeed_Click);
            // 
            // ToQuery
            // 
            this.ToQuery.Location = new System.Drawing.Point(707, 101);
            this.ToQuery.Name = "ToQuery";
            this.ToQuery.Size = new System.Drawing.Size(75, 23);
            this.ToQuery.TabIndex = 7;
            this.ToQuery.Text = "Search";
            this.ToQuery.UseVisualStyleBackColor = true;
            this.ToQuery.Click += new System.EventHandler(this.ToQuery_Click);
            // 
            // QueryList
            // 
            this.QueryList.Location = new System.Drawing.Point(136, 208);
            this.QueryList.Name = "QueryList";
            this.QueryList.Size = new System.Drawing.Size(97, 18);
            this.QueryList.TabIndex = 8;
            this.QueryList.Text = "LinguisticLevel";
            // 
            // PreProcess
            // 
            this.PreProcess.AutoSize = true;
            this.PreProcess.Location = new System.Drawing.Point(674, 144);
            this.PreProcess.Name = "PreProcess";
            this.PreProcess.Size = new System.Drawing.Size(114, 16);
            this.PreProcess.TabIndex = 10;
            this.PreProcess.Text = "NoPreProcessing";
            this.PreProcess.UseVisualStyleBackColor = true;
            this.PreProcess.CheckedChanged += new System.EventHandler(this.PreProcess_CheckedChanged);
            // 
            // SearchOutput
            // 
            this.SearchOutput.Location = new System.Drawing.Point(31, 230);
            this.SearchOutput.Multiline = true;
            this.SearchOutput.Name = "SearchOutput";
            this.SearchOutput.ReadOnly = true;
            this.SearchOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SearchOutput.Size = new System.Drawing.Size(757, 169);
            this.SearchOutput.TabIndex = 11;
            this.SearchOutput.Text = "SearchResults will be shown here";
            // 
            // Resultlabel
            // 
            this.Resultlabel.AutoSize = true;
            this.Resultlabel.Location = new System.Drawing.Point(30, 208);
            this.Resultlabel.Name = "Resultlabel";
            this.Resultlabel.Size = new System.Drawing.Size(83, 12);
            this.Resultlabel.TabIndex = 12;
            this.Resultlabel.Text = "Search Result";
            this.Resultlabel.Click += new System.EventHandler(this.Resultlabel_Click);
            // 
            // Searchtime
            // 
            this.Searchtime.Location = new System.Drawing.Point(543, 208);
            this.Searchtime.Name = "Searchtime";
            this.Searchtime.Size = new System.Drawing.Size(239, 20);
            this.Searchtime.TabIndex = 13;
            this.Searchtime.Text = "SearchTime";
            // 
            // Indextime
            // 
            this.Indextime.Location = new System.Drawing.Point(547, 9);
            this.Indextime.Name = "Indextime";
            this.Indextime.Size = new System.Drawing.Size(241, 23);
            this.Indextime.TabIndex = 14;
            this.Indextime.Text = "IndexTime";
            // 
            // NextTen
            // 
            this.NextTen.Location = new System.Drawing.Point(707, 407);
            this.NextTen.Name = "NextTen";
            this.NextTen.Size = new System.Drawing.Size(75, 23);
            this.NextTen.TabIndex = 15;
            this.NextTen.Text = "Next 10";
            this.NextTen.UseVisualStyleBackColor = true;
            this.NextTen.Click += new System.EventHandler(this.NextTen_Click);
            // 
            // LastTen
            // 
            this.LastTen.Location = new System.Drawing.Point(32, 405);
            this.LastTen.Name = "LastTen";
            this.LastTen.Size = new System.Drawing.Size(75, 23);
            this.LastTen.TabIndex = 16;
            this.LastTen.Text = "Last 10";
            this.LastTen.UseVisualStyleBackColor = true;
            this.LastTen.Click += new System.EventHandler(this.LastTen_Click);
            // 
            // AbstractDetails
            // 
            this.AbstractDetails.Location = new System.Drawing.Point(254, 404);
            this.AbstractDetails.Name = "AbstractDetails";
            this.AbstractDetails.Size = new System.Drawing.Size(75, 23);
            this.AbstractDetails.TabIndex = 19;
            this.AbstractDetails.Text = "Abstract";
            this.AbstractDetails.UseVisualStyleBackColor = true;
            this.AbstractDetails.Click += new System.EventHandler(this.AbstractDetails_Click);
            // 
            // labelofid
            // 
            this.labelofid.AutoSize = true;
            this.labelofid.Location = new System.Drawing.Point(113, 407);
            this.labelofid.Name = "labelofid";
            this.labelofid.Size = new System.Drawing.Size(65, 12);
            this.labelofid.TabIndex = 20;
            this.labelofid.Text = "DocumentID";
            // 
            // comboBoxofid
            // 
            this.comboBoxofid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxofid.FormattingEnabled = true;
            this.comboBoxofid.Location = new System.Drawing.Point(183, 406);
            this.comboBoxofid.Name = "comboBoxofid";
            this.comboBoxofid.Size = new System.Drawing.Size(65, 20);
            this.comboBoxofid.TabIndex = 21;
            this.comboBoxofid.SelectedIndexChanged += new System.EventHandler(this.comboBoxofid_SelectedIndexChanged);
            // 
            // Field
            // 
            this.Field.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Field.FormattingEnabled = true;
            this.Field.Location = new System.Drawing.Point(430, 140);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(93, 20);
            this.Field.TabIndex = 22;
            this.Field.SelectedIndexChanged += new System.EventHandler(this.Field_SelectedIndexChanged);
            // 
            // FieldName
            // 
            this.FieldName.Location = new System.Drawing.Point(388, 146);
            this.FieldName.Name = "FieldName";
            this.FieldName.Size = new System.Drawing.Size(36, 14);
            this.FieldName.TabIndex = 23;
            this.FieldName.Text = "Field";
            // 
            // Botton_InfoNeed
            // 
            this.Botton_InfoNeed.Location = new System.Drawing.Point(25, 67);
            this.Botton_InfoNeed.Name = "Botton_InfoNeed";
            this.Botton_InfoNeed.Size = new System.Drawing.Size(133, 23);
            this.Botton_InfoNeed.TabIndex = 24;
            this.Botton_InfoNeed.Text = "InformationNeedsFile";
            this.Botton_InfoNeed.UseVisualStyleBackColor = true;
            this.Botton_InfoNeed.Click += new System.EventHandler(this.Botton_InfoNeed_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // InfoNeedFilePath
            // 
            this.InfoNeedFilePath.Location = new System.Drawing.Point(164, 71);
            this.InfoNeedFilePath.Name = "InfoNeedFilePath";
            this.InfoNeedFilePath.Size = new System.Drawing.Size(318, 18);
            this.InfoNeedFilePath.TabIndex = 25;
            this.InfoNeedFilePath.Text = "Information Need File Path";
            // 
            // Button_Import
            // 
            this.Button_Import.Location = new System.Drawing.Point(499, 71);
            this.Button_Import.Name = "Button_Import";
            this.Button_Import.Size = new System.Drawing.Size(61, 23);
            this.Button_Import.TabIndex = 26;
            this.Button_Import.Text = "Import";
            this.Button_Import.UseVisualStyleBackColor = true;
            this.Button_Import.Click += new System.EventHandler(this.Button_Import_Click);
            // 
            // comboBoxofqueryid
            // 
            this.comboBoxofqueryid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxofqueryid.FormattingEnabled = true;
            this.comboBoxofqueryid.Location = new System.Drawing.Point(626, 74);
            this.comboBoxofqueryid.Name = "comboBoxofqueryid";
            this.comboBoxofqueryid.Size = new System.Drawing.Size(67, 20);
            this.comboBoxofqueryid.TabIndex = 27;
            this.comboBoxofqueryid.SelectedIndexChanged += new System.EventHandler(this.comboBoxofqueryid_SelectedIndexChanged);
            // 
            // label_queryid
            // 
            this.label_queryid.AutoSize = true;
            this.label_queryid.Location = new System.Drawing.Point(573, 78);
            this.label_queryid.Name = "label_queryid";
            this.label_queryid.Size = new System.Drawing.Size(47, 12);
            this.label_queryid.TabIndex = 28;
            this.label_queryid.Text = "TopicID";
            // 
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(335, 405);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(75, 23);
            this.Button_Save.TabIndex = 29;
            this.Button_Save.Text = "ResultFile";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // labelofresultfile
            // 
            this.labelofresultfile.AutoSize = true;
            this.labelofresultfile.Location = new System.Drawing.Point(416, 414);
            this.labelofresultfile.Name = "labelofresultfile";
            this.labelofresultfile.Size = new System.Drawing.Size(107, 12);
            this.labelofresultfile.TabIndex = 30;
            this.labelofresultfile.Text = "Results File Path";
            // 
            // Button_Close
            // 
            this.Button_Close.Location = new System.Drawing.Point(700, 36);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(88, 23);
            this.Button_Close.TabIndex = 31;
            this.Button_Close.Text = "CloseWindow";
            this.Button_Close.UseVisualStyleBackColor = true;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(626, 406);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 32;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labeloffinalquery
            // 
            this.labeloffinalquery.AutoSize = true;
            this.labeloffinalquery.Location = new System.Drawing.Point(29, 145);
            this.labeloffinalquery.Name = "labeloffinalquery";
            this.labeloffinalquery.Size = new System.Drawing.Size(71, 12);
            this.labeloffinalquery.TabIndex = 33;
            this.labeloffinalquery.Text = "Final Query";
            // 
            // ButtonForCreate
            // 
            this.ButtonForCreate.Location = new System.Drawing.Point(606, 36);
            this.ButtonForCreate.Name = "ButtonForCreate";
            this.ButtonForCreate.Size = new System.Drawing.Size(87, 23);
            this.ButtonForCreate.TabIndex = 34;
            this.ButtonForCreate.Text = "CreateIndex";
            this.ButtonForCreate.UseVisualStyleBackColor = true;
            this.ButtonForCreate.Click += new System.EventHandler(this.ButtonForCreate_Click);
            // 
            // LinguisticLevel
            // 
            this.LinguisticLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LinguisticLevel.FormattingEnabled = true;
            this.LinguisticLevel.Location = new System.Drawing.Point(239, 206);
            this.LinguisticLevel.Name = "LinguisticLevel";
            this.LinguisticLevel.Size = new System.Drawing.Size(164, 20);
            this.LinguisticLevel.TabIndex = 35;
            this.LinguisticLevel.SelectedIndexChanged += new System.EventHandler(this.LinguisticLevel_SelectedIndexChanged);
            // 
            // textBoxforquery
            // 
            this.textBoxforquery.Location = new System.Drawing.Point(31, 168);
            this.textBoxforquery.Multiline = true;
            this.textBoxforquery.Name = "textBoxforquery";
            this.textBoxforquery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxforquery.Size = new System.Drawing.Size(741, 37);
            this.textBoxforquery.TabIndex = 37;
            // 
            // buttonofExpandQuery
            // 
            this.buttonofExpandQuery.Location = new System.Drawing.Point(409, 205);
            this.buttonofExpandQuery.Name = "buttonofExpandQuery";
            this.buttonofExpandQuery.Size = new System.Drawing.Size(128, 23);
            this.buttonofExpandQuery.TabIndex = 38;
            this.buttonofExpandQuery.Text = "ExpandWeightQuery";
            this.buttonofExpandQuery.UseVisualStyleBackColor = true;
            this.buttonofExpandQuery.Click += new System.EventHandler(this.buttonofExpandQuery_Click);
            // 
            // labelofprompt
            // 
            this.labelofprompt.AutoSize = true;
            this.labelofprompt.Location = new System.Drawing.Point(106, 145);
            this.labelofprompt.Name = "labelofprompt";
            this.labelofprompt.Size = new System.Drawing.Size(251, 12);
            this.labelofprompt.TabIndex = 39;
            this.labelofprompt.Text = "The query has been expanded,please search";
            // 
            // Titleboostcheckbox
            // 
            this.Titleboostcheckbox.AutoSize = true;
            this.Titleboostcheckbox.Location = new System.Drawing.Point(404, 4);
            this.Titleboostcheckbox.Name = "Titleboostcheckbox";
            this.Titleboostcheckbox.Size = new System.Drawing.Size(84, 16);
            this.Titleboostcheckbox.TabIndex = 40;
            this.Titleboostcheckbox.Text = "TitleBoost";
            this.Titleboostcheckbox.UseVisualStyleBackColor = true;
            this.Titleboostcheckbox.CheckedChanged += new System.EventHandler(this.Titleboostcheckbox_CheckedChanged);
            // 
            // Authorboostcheckbox
            // 
            this.Authorboostcheckbox.AutoSize = true;
            this.Authorboostcheckbox.Location = new System.Drawing.Point(404, 26);
            this.Authorboostcheckbox.Name = "Authorboostcheckbox";
            this.Authorboostcheckbox.Size = new System.Drawing.Size(90, 16);
            this.Authorboostcheckbox.TabIndex = 41;
            this.Authorboostcheckbox.Text = "AuthorBoost";
            this.Authorboostcheckbox.UseVisualStyleBackColor = true;
            this.Authorboostcheckbox.CheckedChanged += new System.EventHandler(this.Authorboostcheckbox_CheckedChanged);
            // 
            // comboBoxoftitleboost
            // 
            this.comboBoxoftitleboost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxoftitleboost.FormattingEnabled = true;
            this.comboBoxoftitleboost.Location = new System.Drawing.Point(494, 2);
            this.comboBoxoftitleboost.Name = "comboBoxoftitleboost";
            this.comboBoxoftitleboost.Size = new System.Drawing.Size(33, 20);
            this.comboBoxoftitleboost.TabIndex = 42;
            // 
            // comboBoxofauthorboost
            // 
            this.comboBoxofauthorboost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxofauthorboost.FormattingEnabled = true;
            this.comboBoxofauthorboost.Location = new System.Drawing.Point(494, 24);
            this.comboBoxofauthorboost.Name = "comboBoxofauthorboost";
            this.comboBoxofauthorboost.Size = new System.Drawing.Size(33, 20);
            this.comboBoxofauthorboost.TabIndex = 43;
            // 
            // Form1
            // 
            this.AcceptButton = this.ToQuery;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 489);
            this.Controls.Add(this.comboBoxofauthorboost);
            this.Controls.Add(this.comboBoxoftitleboost);
            this.Controls.Add(this.Authorboostcheckbox);
            this.Controls.Add(this.Titleboostcheckbox);
            this.Controls.Add(this.labelofprompt);
            this.Controls.Add(this.buttonofExpandQuery);
            this.Controls.Add(this.textBoxforquery);
            this.Controls.Add(this.LinguisticLevel);
            this.Controls.Add(this.ButtonForCreate);
            this.Controls.Add(this.labeloffinalquery);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.Button_Close);
            this.Controls.Add(this.labelofresultfile);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.label_queryid);
            this.Controls.Add(this.comboBoxofqueryid);
            this.Controls.Add(this.Button_Import);
            this.Controls.Add(this.InfoNeedFilePath);
            this.Controls.Add(this.Botton_InfoNeed);
            this.Controls.Add(this.FieldName);
            this.Controls.Add(this.Field);
            this.Controls.Add(this.comboBoxofid);
            this.Controls.Add(this.labelofid);
            this.Controls.Add(this.AbstractDetails);
            this.Controls.Add(this.LastTen);
            this.Controls.Add(this.NextTen);
            this.Controls.Add(this.Indextime);
            this.Controls.Add(this.Searchtime);
            this.Controls.Add(this.Resultlabel);
            this.Controls.Add(this.SearchOutput);
            this.Controls.Add(this.PreProcess);
            this.Controls.Add(this.QueryList);
            this.Controls.Add(this.ToQuery);
            this.Controls.Add(this.InfoNeed);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.sourcepath);
            this.Controls.Add(this.sourcedirectory);
            this.Controls.Add(this.path);
            this.Controls.Add(this.indexdirectory);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button indexdirectory;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button sourcedirectory;
        private System.Windows.Forms.Label sourcepath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label InfoNeed;
        private System.Windows.Forms.Button ToQuery;
        private System.Windows.Forms.Label QueryList;
        private System.Windows.Forms.CheckBox PreProcess;
        private System.Windows.Forms.TextBox SearchOutput;
        private System.Windows.Forms.Label Resultlabel;
        private System.Windows.Forms.Label Searchtime;
        private System.Windows.Forms.Label Indextime;
        private System.Windows.Forms.Button NextTen;
        private System.Windows.Forms.Button LastTen;
        private System.Windows.Forms.Button AbstractDetails;
        private System.Windows.Forms.Label labelofid;
        public System.Windows.Forms.ComboBox comboBoxofid;
        private System.Windows.Forms.ComboBox Field;
        private System.Windows.Forms.Label FieldName;
        private System.Windows.Forms.Button Botton_InfoNeed;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label InfoNeedFilePath;
        private System.Windows.Forms.Button Button_Import;
        private System.Windows.Forms.ComboBox comboBoxofqueryid;
        private System.Windows.Forms.Label label_queryid;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label labelofresultfile;
        private System.Windows.Forms.Button Button_Close;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labeloffinalquery;
        private System.Windows.Forms.Button ButtonForCreate;
        private System.Windows.Forms.ComboBox LinguisticLevel;
        private System.Windows.Forms.TextBox textBoxforquery;
        private System.Windows.Forms.Button buttonofExpandQuery;
        private System.Windows.Forms.Label labelofprompt;
        private System.Windows.Forms.CheckBox Titleboostcheckbox;
        private System.Windows.Forms.CheckBox Authorboostcheckbox;
        private System.Windows.Forms.ComboBox comboBoxoftitleboost;
        private System.Windows.Forms.ComboBox comboBoxofauthorboost;
    }
}

