using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _647project
{
    
    public partial class Form1 : Form
    {
        LuceneApplication myLuceneApp;
        DirectoryInfo directoryInfo;
        System.IO.FileInfo[] files;
        bool preprocess;
        Formofabstract form2;
        string query_id;
        string resultfilename;
        string indexfilespath;
        string sourcefilespath;
        string originalquery;
        bool authorboost;
        bool titleboost;
        /// <summary>
        //Constructor for Form1 which can be seen as an object.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            myLuceneApp = new LuceneApplication();
            files = null;
            resultfilename = "";
            indexfilespath = "";
            sourcefilespath = "";
            preprocess = true;
            titleboost = false;
            authorboost = false;
            originalquery = "";
            Field.Items.Add("Abstract");
            Field.Items.Add("Title");
            Field.Items.Add("Author");
            Field.Items.Add("Bibliographic Information");
            Field.SelectedIndex = 0;//make the field "abstract" as a default field for retrival 
            LinguisticLevel.Items.Add("Synonym");
            LinguisticLevel.Items.Add("Hypernym");
            LinguisticLevel.Items.Add("Hyponym");
            LinguisticLevel.Items.Add("PartHolonym");
            LinguisticLevel.Items.Add("PartMeronym");
            LinguisticLevel.SelectedIndex = 0;
            comboBoxofauthorboost.Items.Add("1");
            comboBoxofauthorboost.Items.Add("2");
            comboBoxofauthorboost.Items.Add("3");
            comboBoxofauthorboost.Items.Add("4");
            comboBoxofauthorboost.Items.Add("5");
            comboBoxofauthorboost.Items.Add("6");
            comboBoxofauthorboost.Items.Add("7");
            comboBoxofauthorboost.Items.Add("8");
            comboBoxofauthorboost.Items.Add("9");
            comboBoxofauthorboost.SelectedIndex = 0;
            comboBoxofauthorboost.Visible = false;
            comboBoxoftitleboost.Items.Add("1");
            comboBoxoftitleboost.Items.Add("2");
            comboBoxoftitleboost.Items.Add("3");
            comboBoxoftitleboost.Items.Add("4");
            comboBoxoftitleboost.Items.Add("5");
            comboBoxoftitleboost.Items.Add("6");
            comboBoxoftitleboost.Items.Add("7");
            comboBoxoftitleboost.Items.Add("8");
            comboBoxoftitleboost.Items.Add("9");
            comboBoxoftitleboost.SelectedIndex = 0;
            comboBoxoftitleboost.Visible = false;
            Titleboostcheckbox.Visible = false;
            Authorboostcheckbox.Visible = false;
            comboBoxofauthorboost.Enabled = true;
            comboBoxoftitleboost.Enabled = true;
            Titleboostcheckbox.Enabled = true;
            Authorboostcheckbox.Enabled = true;
            LinguisticLevel.Visible = false;
            label_queryid.Visible = false;
            comboBoxofqueryid.Visible = false;
            query_id = "";
            buttonSave.Visible = false;
            Button_Import.Visible = false;
            ButtonForCreate.Visible = false;
            // next operations is to let a user see the controller after search 
            LastTen.Visible = false;
            labelofid.Visible = false;
            comboBoxofid.Visible = false;
            AbstractDetails.Visible = false;
            Button_Save.Visible = false;
            labelofresultfile.Visible = false;
            NextTen.Visible = false;
            //Next operations make a user see the controllers after identifying the source files.
            textBox1.ReadOnly = true;
            ToQuery.Visible = false;
            //only finish identiying the path of source files,they can be shown
            Botton_InfoNeed.Visible = false;
            InfoNeedFilePath.Visible = false;
            InfoNeed.Visible = false;
            textBox1.Visible = false;
            FieldName.Visible = false;
            Field.Visible = false;
            PreProcess.Visible = false;
            labeloffinalquery.Visible = false;
            QueryList.Visible = false;
            textBoxforquery.Visible = false;
            SearchOutput.Visible = false;
            Searchtime.Visible = false;
            Resultlabel.Visible = false;
            //when finsihing at least once search, it can be seen
            Button_Close.Visible = false;
            //when you specify the path of index, you can see the source file button
            sourcedirectory.Visible = false;
            sourcepath.Visible = false;
            //make the abstract button disable
            AbstractDetails.Enabled = false;
            buttonofExpandQuery.Visible = false;
            labelofprompt.Visible = false;
        }

        private void path_Click(object sender, EventArgs e)
        {

        }
        //choose where the index files are stored.
        private void indexdirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.path.Text = folderBrowserDialog1.SelectedPath;
                indexfilespath= folderBrowserDialog1.SelectedPath;
                
                sourcedirectory.Visible = true;
                sourcepath.Visible = true;
                
            }
        }
        //choose where the source files are
        private void sourcedirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                
                this.sourcepath.Text = folderBrowserDialog2.SelectedPath;//display the path of source files
                sourcefilespath = folderBrowserDialog2.SelectedPath;
                ButtonForCreate.Visible = true;
                Titleboostcheckbox.Visible = true;
                Authorboostcheckbox.Visible = true;
            }
        }

        private void ButtonForCreate_Click(object sender, EventArgs e)
        {
            DateTime start = System.DateTime.Now;
            myLuceneApp.CreateIndex(indexfilespath);
            directoryInfo = new DirectoryInfo(sourcefilespath);
            files = directoryInfo.GetFiles("*.txt");
            foreach (FileInfo fi in files)
            {
                //fi.FULLNAME is path name +filename, not content
                myLuceneApp.IndexText(fi.FullName,titleboost,authorboost,comboBoxoftitleboost.Text,comboBoxofauthorboost.Text);
            }
            myLuceneApp.CleanUpIndexer();
            DateTime end = System.DateTime.Now;
            Indextime.Text = "IndexTime:" + (end - start).TotalMilliseconds.ToString() + " Milliseconds";
            textBox1.ReadOnly = false;
            ToQuery.Visible = true;
            Botton_InfoNeed.Visible = true;
            InfoNeedFilePath.Visible = true;
            InfoNeed.Visible = true;
            textBox1.Visible = true;
            FieldName.Visible = true;
            Field.Visible = true;
            PreProcess.Visible = true;
            labeloffinalquery.Visible = true;
            
            textBoxforquery.Visible = true;
            SearchOutput.Visible = true;
            Searchtime.Visible = true;
            Resultlabel.Visible = true;
            comboBoxofauthorboost.Enabled = true;
            comboBoxoftitleboost.Enabled = true;
            Titleboostcheckbox.Enabled = true;
            Authorboostcheckbox.Enabled = true;
            textBoxforquery.Text = " ";


        }
        //The operation is to Search source files for the query or information need 
        private void ToQuery_Click(object sender, EventArgs e)
        {
            DateTime start = System.DateTime.Now;
            myLuceneApp.CreateSearcher();//eachtime, I need to create a searcher
            myLuceneApp.CreateParter(Field.Text);//accordign to the field, create Parter
            if (preprocess == true) {
                //originalquery is just used to store the original information need.
                if(string.IsNullOrEmpty(myLuceneApp.NLP(textBox1.Text))){
                    originalquery = " ";
                }
                else{
                    originalquery = myLuceneApp.NLP(textBox1.Text);
                }
                 
                    
                if (PreProcess.Enabled ==false ) {
                    //if preprocess is disable== queried has been expended, expanded query should be displayed, it can't be replaced by the NLP result
                    textBoxforquery.Text = textBoxforquery.Text;//need to expand
                }
                else {
                    //preprocess is enable, it means after a searcher,or a new beigin. because when click search, 
                    // Preprocess is disabled,or enable(continuous double click search).
                    textBoxforquery.Text = originalquery;
                    //The NLP(processing information needs) is included in search time. 
                    //it means query has been expanded,we don't need to do NLP
                 } 
                //if show emthy or result of NLP is empty, do not search
                if ((string.IsNullOrEmpty(textBoxforquery.Text)==false)&&(string.IsNullOrWhiteSpace(textBoxforquery.Text)==false)) {
                    SearchOutput.Text = myLuceneApp.SearchIndex(textBoxforquery.Text); }
               //if preprocess is ture, it means the application needs to do Natural language process 
            }
            else {
                if(PreProcess.Enabled == true) {
                    //when the user don't use the function of expanding query, the orignialquery is never changed. 
                    textBoxforquery.Text = textBox1.Text;
                    originalquery = textBoxforquery.Text;
                }
                SearchOutput.Text=myLuceneApp.SearchIndex(textBoxforquery.Text);
                //if preprocess is fasle, it means the application does not do Natural language process
                //if a user wants to input a phrase as a query, he or she needs to use escape symbol'\'
                //if a user doesn't use '\' but directly use double quotation marks, it will make error.
            }

            DateTime end = System.DateTime.Now;
            Searchtime.Text = "SearchTime:" + (end - start).TotalMilliseconds.ToString()+" Milliseconds";
            
            if (myLuceneApp.infneed.ContainsKey(comboBoxofqueryid.Text)) {
                query_id = comboBoxofqueryid.Text;
            } ;
            comboBoxofid.Items.Clear();
            foreach (string optionitem in myLuceneApp.option) {
                comboBoxofid.Items.Add(optionitem);
            }
            PreProcess.Enabled = true;//when click search again, it can be used again
            LastTen.Visible = true;
            labelofid.Visible = true;
            comboBoxofid.Visible = true;
            AbstractDetails.Visible = true;
            Button_Save.Visible = true;//it is used to find an appropriate location for result files
            labelofresultfile.Visible =true;
            NextTen.Visible = true;
            buttonSave.Visible = true;//when clicking search button again, the new result will be displayed, it allows you to save it.
            Button_Close.Visible = true;
            LinguisticLevel.Visible = true;//allow a user can expand the query
            QueryList.Visible = true;
            buttonofExpandQuery.Visible = true;
            labelofprompt.Visible = false;
        }

        private void InfoNeed_Click(object sender, EventArgs e)
        {

        }

        private void PreProcess_CheckedChanged(object sender, EventArgs e)
        {
            if (PreProcess.Checked == true) { preprocess = false; }
            else { preprocess = true; }
        }
        //this operation allows a user can browse results forwards
        private void NextTen_Click(object sender, EventArgs e)
        {
            string tempstr = myLuceneApp.Nextten();
            if (tempstr != "can't be forwards"){
                SearchOutput.Text = tempstr;
                comboBoxofid.Items.Clear();
                foreach (string optionitem in myLuceneApp.option)
                {
                    comboBoxofid.Items.Add(optionitem);
                }
                
            }
            
        }
        //this operation allows a user can browse results backwards
        private void LastTen_Click(object sender, EventArgs e)
        {
            string tempstr = myLuceneApp.Lastten();
            if (tempstr!= "can't be backwards")
            {
                SearchOutput.Text = tempstr;
                comboBoxofid.Items.Clear();
                foreach (string optionitem in myLuceneApp.option)
                {
                    comboBoxofid.Items.Add(optionitem);
                }
                
            }
            
        }
        //Task 4 the user can see the entire detals about abstracts for a specific DocID
        private void AbstractDetails_Click(object sender, EventArgs e)
        {
            form2 = new Formofabstract();
            form2.Show();
            form2.labelofabstract.Text ="Document ID:" +comboBoxofid.Text + " Abstract Details";
            form2.AbtractBox.Text = myLuceneApp.AbstractWatch(comboBoxofid.Text);
        }

        private void comboBoxofid_SelectedIndexChanged(object sender, EventArgs e)
        {
            AbstractDetails.Enabled = true;
        }
        //This operation is to choose where the information needs files are.
        private void Botton_InfoNeed_Click(object sender, EventArgs e)
        {
            string infofilename = "";
            openFileDialog1.FileName = "*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                infofilename = openFileDialog1.FileName;
                InfoNeedFilePath.Text = infofilename;
                Button_Import.Visible = true;
                myLuceneApp.InformationNeedProcess(infofilename);
            }
        }

        private void Resultlabel_Click(object sender, EventArgs e)
        {

        }
        //Once the user specify where the information need files are, it is normal that he or she needs to transfer the data into system.
        private void Button_Import_Click(object sender, EventArgs e)
        {
            foreach (string key in myLuceneApp.infneed.Keys) {
                comboBoxofqueryid.Items.Add(key);
            }
            label_queryid.Visible = true;
            comboBoxofqueryid.Visible = true;
            comboBoxofqueryid.SelectedIndex = 0;
            Field.Items.Clear();
            Field.Items.Add("Abstract");
            Field.Text = "Abstract";
            
        }
        //Once the user want to use information need file for search, he or she can't input information need again. 
        //This operation make sure there will not be a error in the future.
        private void comboBoxofqueryid_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = myLuceneApp.infneed[comboBoxofqueryid.Text];     
            textBox1.ReadOnly = true;
        }
        //this button is used to choose where the result can be saved.
        private void Button_Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "Resultfile.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                
                labelofresultfile.Text = saveFileDialog1.FileName;
                resultfilename = saveFileDialog1.FileName;
            }
            if (resultfilename!="") { buttonSave.Visible = true; }
            
        }
        //Close the window and clear the searcher. Because it has been used for entire process,you can't clear it before finishing retrival. 
        private void Button_Close_Click(object sender, EventArgs e)
        {
            myLuceneApp.CleanSearcher();
            this.Close();
        }
        //Next method is used for task 5
        private void buttonSave_Click(object sender, EventArgs e)
        {  if (resultfilename != "") {
                myLuceneApp.SaveResults(query_id, resultfilename);
                MessageBox.Show("The Result File has been stored successfully!");
                buttonSave.Visible = false;
            }
        }

        private void buttonofExpandQuery_Click(object sender, EventArgs e)
        {
            labelofprompt.Visible = true;
            string expandedquery = myLuceneApp.ExpandWeightedQuery(LinguisticLevel.Text,originalquery );
            textBoxforquery.Text = expandedquery;
            Searchtime.Text = "";
            SearchOutput.Text = "You need to click \"Search\" button again to show the results";
            preprocess = false;//don't do NLP
            PreProcess.Enabled = false;

        }

        private void Field_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Titleboostcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Titleboostcheckbox.Checked == true)
            {
                titleboost = true;
                comboBoxoftitleboost.Visible = true;
            }
            else {
                titleboost = false;
                comboBoxoftitleboost.Visible = false;
            }
        }

        private void Authorboostcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Authorboostcheckbox.Checked==true) { authorboost = true;
                comboBoxofauthorboost.Visible = true;
            }
            else { authorboost = false;
                comboBoxofauthorboost.Visible = false;
            }
        }

        private void LinguisticLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
