using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lucene.Net.Analysis; // for Analyser
using Lucene.Net.Documents; // for Document and Field
using Lucene.Net.Index; //for Index Writer
using Lucene.Net.Store; //for Directory
using Lucene.Net.Search; // for IndexSearcher
using Lucene.Net.QueryParsers;  // for QueryParser
using Syn.WordNet;

namespace _647project
{
    class LuceneApplication
    {
        Lucene.Net.Store.Directory luceneIndexDirectory;
        Lucene.Net.Analysis.Analyzer analyzerstandard;
        Lucene.Net.Analysis.Analyzer analyzerkeyword;
        Lucene.Net.Index.IndexWriter writer;
        Lucene.Net.Analysis.PerFieldAnalyzerWrapper analysor;
        Lucene.Net.Search.IndexSearcher searcher;
        Lucene.Net.QueryParsers.QueryParser parser;
        Similarity customSimilarity;//for task 6
        Dictionary<string, int> tokenCount;
        TopDocs docs;//it is used to collect the relevant documents
        int numofdoc;
        int numofrelevant;
        public List<string> option;
        public Dictionary<string, string> infneed;
        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;
        const string DocID = "DocID";
        const string TITLE = "Title";//give the field name you can see in Luke
        const string AUTHOR = "Author";
        const string BIBLiINFO = "Bibliographic Information";
        const string ABSTRACT = "Abstract";

        

        public LuceneApplication()
        {
            luceneIndexDirectory = null;
            analyzerstandard = null;
            analyzerkeyword = null;
            writer = null;
            analysor = null;
            searcher = null;
            parser = null;
            customSimilarity = new CustomSimilarity();//for task 6
            tokenCount = new Dictionary<string, int>();
            numofdoc = 0;
            numofrelevant = 0;
            option = new List<string>();
            infneed = new Dictionary<string, string>();


        }//contructor which is used to initialize the objects

        //create index
        public void CreateIndex(string indexPath)
        {
            luceneIndexDirectory = Lucene.Net.Store.FSDirectory.Open(indexPath);
            analyzerstandard = new Lucene.Net.Analysis.Standard.StandardAnalyzer(VERSION);
            analyzerkeyword = new Lucene.Net.Analysis.KeywordAnalyzer();
            IndexWriter.MaxFieldLength mfl = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);
            analysor = new PerFieldAnalyzerWrapper(analyzerstandard);
            writer = new Lucene.Net.Index.IndexWriter(luceneIndexDirectory, analysor, true, mfl);
            writer.SetSimilarity(customSimilarity);//for task 6

        }
        //create an index system, you need to indicate where the source files are
        public void IndexText(string filepath,bool titleboost,bool authorboost,string titlevalue,string authorvalue)
        {   StreamReader file= new StreamReader(filepath);
            string content = file.ReadToEnd();
            string[] delimiter = {".I",".T",".A",".B",".W"};
            string[] words = content.Split(delimiter,StringSplitOptions.RemoveEmptyEntries);
            string length="";
            int countfordoc = 0;
            countfordoc++;
            //because there are five parts in sourcefile, they need to be seperated.
            if (words.Length>5) {
                length = words.Length.ToString();
            }
            string[] wordprocessed=new string[words.Length];
            int i = 0;
            //get rid of some symbols because string contain some unwanted symbols
            //delete the title in abstract because it can be seen as an error
            if (words[4].Contains(words[1]))
            {
                words[4] = words[4].Replace(words[1], string.Empty);
            }
            // get rid of the symbol which is in charge of changing for a new line
            foreach (string w in words) {
                wordprocessed[i] = w.Replace("\n", string.Empty);
                i++;
            }

            //define 5 fields for index
            Lucene.Net.Documents.Field docid = new Field(DocID, wordprocessed[0], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);
            Lucene.Net.Documents.Field title = new Field(TITLE,wordprocessed[1], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);
            Lucene.Net.Documents.Field author = new Field(AUTHOR, wordprocessed[2], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);
            Lucene.Net.Documents.Field bibliinformation = new Field(BIBLiINFO, wordprocessed[3], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);
            Lucene.Net.Documents.Field abstracts = new Field(ABSTRACT,wordprocessed[4] , Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);
            if (titleboost == true)
            {
                title.Boost = int.Parse(titlevalue);
            }
            else { title.Boost = 1; }//for task 7
            if (authorboost == true) {
                author.Boost = int.Parse(authorvalue);
            }
            else { author.Boost = 1; }
            //for task 7
            analysor.AddAnalyzer(DocID, analyzerkeyword);//set  ID using keyword analyzor
            analysor.AddAnalyzer(AUTHOR, analyzerkeyword);//set author using keyword analyzor, in my opinion, it cann't be separated.
            analysor.AddAnalyzer(BIBLiINFO, analyzerkeyword);//set bibliography using keyword analyzor
            Lucene.Net.Documents.Document doc = new Document();
            doc.Add(docid);
            doc.Add(title);
            doc.Add(abstracts);
            doc.Add(author);
            doc.Add(bibliinformation);
            writer.AddDocument(doc);//writer is bond with analysor. here, my analysor is a mixture of 2 types of analyzor
            file.Close();
        }
        //clear writer in case it occupy cpu all the time.
        public void CleanUpIndexer()
        {
            writer.Optimize();
            writer.Flush(true, true, true);
            writer.Dispose();
        }
        //Natural Language Process
        public string NLP(string text) {
            
            //double quotation issue
            char[] doubelquotation = { '\"' };
            string[] sections = text.Split(doubelquotation, StringSplitOptions.RemoveEmptyEntries);
            string phrase = "";
            string reducedcontent = "";
            List <string> phrases= new List<string>();
            // deal with double quatation marks.
            phrases.Clear();
            if (text.IndexOf('\"') == 0)
            {
                //when the beginning is double quation
                int i = 0;
                foreach (string ele in sections)
                {
                    if (i % 2 == 0) {
                        if (phrases.Contains(ele)==false) { phrases.Add(ele); }
                        
                    }
                    else { reducedcontent = reducedcontent + " " + ele; }
                    i++;
                }
            }
            else
            {
                //when the beginning is not double quation
                int i = 0;
                foreach (string ele in sections)
                {
                    if (i % 2 == 0) { reducedcontent = reducedcontent + " " + ele; }
                    else {  
                        if (phrases.Contains(ele)==false) { phrases.Add(ele); }
                    }
                    i++;
                }
            }
            foreach (string element in phrases) {
                phrase = phrase + " " + '\"' + element + '\"'; 
            }
            //finishing dealing with double quotation marks
            string query = "";
            char[] delimiters = { ',', '.', '-', '\n', ' ', '!', '\0', ':', ';', '?', ' ' };
            string[] tokens = reducedcontent.ToLower().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] stopWordList = new string[] {"a","an","and","are","as","at","be","but","by","for","if","in","into",
                             "is","it","no","not","of","on","or","such","that","the","their","then",
                              "there","these","they","this","to","was","will","with"
                             };
            string[] temp = new string[tokens.Length];
            int j = 0;
            //get rid of stopwords
            for (int i = 0; i < tokens.Length; i++) {
                if (stopWordList.Contains(tokens[i]) || tokens[i].Length <= 2)
                {

                }
                else
                {
                    temp[j] = tokens[i];
                    j = j + 1;

                }
            }
            //change for a new array for saving becasue the length of new and old array is different
            string[] tokensWithoutSW = new string[j];
            for (int i = 0; i < j; i++) {
                tokensWithoutSW[i] = temp[i];
            }
            //face the same token, need to integrate them together 
            tokenCount.Clear();
            foreach (string token in tokensWithoutSW) {
                if (tokenCount.ContainsKey(token))
                {
                    tokenCount[token] = tokenCount[token] + 1;
                }
                else
                {
                    tokenCount.Add(token, 1);
                }
            }
            tokenCount.Keys.ToArray();//make tokenCount.Keys become an array
            foreach (string key in tokenCount.Keys) {
                query = query + key + " ";
            }
            return phrase+" "+query;
        }//end NLP
        public void CreateSearcher()
        {
            searcher = new Lucene.Net.Search.IndexSearcher(luceneIndexDirectory);
            searcher.Similarity = customSimilarity;//for task 6
          //because the searcher should be used for all the time, it can not be cleared until you close the window.
        }
        public void CreateParter(string fieldname)
        {
            parser = new Lucene.Net.QueryParsers.QueryParser(VERSION,fieldname,analysor);
            //defining parser by using field name
            //here, using my mixture analysor define a parser which translate the query known by human being to the query by machine
        }
        public void CleanSearcher()
        {
            searcher.Dispose();//dispose searcher so that more space can be released.
        }
        //search
        public string SearchIndex(string queryText)
        {
            string output = "Nothing";
            if (queryText != "") { 
               queryText.ToLower();
               Query query = parser.Parse(queryText);
               docs = searcher.Search(query, 1400);//here, 1400 means requiring to find up to 1400 documents
               //because it is impossible to be more than 1400.
               
               numofrelevant = docs.TotalHits;//it represent how many documents found already(no more than 100)
               output = "There are " + numofrelevant.ToString()+" relavant documents.\r\n";//display
               
               numofdoc = 10;
               int totaldoc = 10;
               if (docs.ScoreDocs.Length < 10) {
                    totaldoc = docs.ScoreDocs.Length;
                }
                if (numofrelevant > 0) { output = output + "The relevant documents from 1 to "+ totaldoc.ToString() +" are as follow:\r\n"; }
                option.Clear();//option is a list used to store the documents found in the screen.notice, if the screen is changed, the option list will be changed.
               for (int i=0; i < totaldoc; i++) {
                   ScoreDoc scoredoc = docs.ScoreDocs[i];
                   Document doc1 = searcher.Doc(scoredoc.Doc);
                   option.Add(doc1.Get(DocID));
                   //output = output + "Document " + scoredoc.Doc.ToString() + ":\r\n";
                   output = output+"Rank "+ (i+1).ToString()+": "+DocID + ":" + doc1.Get(DocID) + "\r\n";
                   output = output+TITLE +":"+doc1.Get(TITLE)+"\r\n";
                   output = output + AUTHOR + ":" + doc1.Get(AUTHOR) + "\r\n";
                   output = output + BIBLiINFO + ":" + doc1.Get(BIBLiINFO) + "\r\n";
                   //because requirement is to show the first sentence.
                   char[] symbols = {'.','?','!' };
                   string[] sentences = doc1.Get(ABSTRACT).ToString().Split(symbols, StringSplitOptions.RemoveEmptyEntries);
                   foreach (string sentence in sentences) {
                      if (sentence.Length>0) {
                        output = output + "The first sentence of teh abstract:" + sentence + "\r\n";
                        break;//once I find the first sentence, I will jump out of the loop.
                       }
                    
                   }
                    //output = output + "The score is" + scoredoc.Score.ToString()+"\r\n";
                }
            }
            return output;
        }//end index search
        //see the next 10 results, notice, if there are no 10 records left, it displays the results flexibely.
        public string Nextten()
        {
            string output = "can't be forwards";
            int startnum = numofdoc;
            int endnum=0;
            bool flag = true;
            if(startnum >= docs.ScoreDocs.Length) { flag = false; }
            if (flag == true) { 
               if ((startnum + 9) < docs.ScoreDocs.Length) { endnum = startnum + 9; }
               else { endnum = docs.ScoreDocs.Length-1; }

                option.Clear();
                output = "There are " + numofrelevant.ToString() + " relavant documents.\r\n";
                if (numofrelevant > 0) {
                    output = output + "The documents ranked from " + (startnum + 1).ToString() + " to " + (endnum + 1).ToString() + " as follow:\r\n";
                }
                
                for (int i = startnum; i <= endnum; i++)
                {
                    ScoreDoc scoredoc = docs.ScoreDocs[i];
                    Document doc1 = searcher.Doc(scoredoc.Doc);
                    option.Add(doc1.Get(DocID));
                    //output = output + "Document " + scoredoc.Doc.ToString() + ":\r\n";
                    output=output+ "Rank " + (i + 1).ToString() + ": " + DocID + ":" + doc1.Get(DocID) + "\r\n";
                    output=output+ TITLE + ":" + doc1.Get(TITLE) + "\r\n";
                    output = output + AUTHOR + ":" + doc1.Get(AUTHOR) + "\r\n";
                    output = output + BIBLiINFO + ":" + doc1.Get(BIBLiINFO) + "\r\n";
                    char[] symbols = { '.', '?', '!' };
                    string[] sentences = doc1.Get(ABSTRACT).ToString().Split(symbols, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string sentence in sentences)
                    {
                        if (sentence.Length > 0)
                        {
                            output = output + "The first sentence of teh abstract:" + sentence + "\r\n";
                            break;//once I find the first sentence, I will jump out of the loop.
                        }

                    }
                }

                numofdoc =startnum + 10;//let machine kwon which document will be shown in the next srcreen.
                //numofdoc represent the the doucment rank No. for the "next 10" 
            }
            return output;
            
        }
        //browse the last 10 results 
        public string Lastten() {
            string output = "can't be backwards";
            int startnum = numofdoc - 20;

            if (startnum >= 0) {
                
                int endnum = startnum + 9;
                option.Clear();
                output = "There are " + numofrelevant.ToString() + " relavant documents.\r\n";
                if (numofrelevant>0) {
                    output =output +"The documents ranked from " + (startnum + 1).ToString() + " to " + (endnum + 1).ToString() + " as follow:\r\n";
                }
                for (int i = startnum; i <= endnum; i++)
                {
                    ScoreDoc scoredoc = docs.ScoreDocs[i];
                    Document doc1 = searcher.Doc(scoredoc.Doc);
                    option.Add(doc1.Get(DocID));
                    //output = output + "Document " + scoredoc.Doc.ToString() + ":\r\n";
                    output=output+ "Rank " + (i + 1).ToString() + ": " + DocID + ":" + doc1.Get(DocID) + "\r\n";
                    output = output+ TITLE + ":" + doc1.Get(TITLE) + "\r\n";
                    output = output + AUTHOR + ":" + doc1.Get(AUTHOR) + "\r\n";
                    output = output + BIBLiINFO + ":" + doc1.Get(BIBLiINFO) + "\r\n";
                    char[] symbols = { '.', '?', '!' };
                    string[] sentences = doc1.Get(ABSTRACT).ToString().Split(symbols, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string sentence in sentences)
                    {
                        if (sentence.Length > 0)
                        {
                            output = output + "The first sentence of teh abstract:" + sentence + "\r\n";
                            break;//once I find the first sentence, I will jump out of the loop.
                        }

                    }

                }
                numofdoc = endnum + 1;
            }

            return output;
        }
        //see the abstracts for a specific docid
        public string AbstractWatch(string id) {
            string output = "Nothing";
            foreach (ScoreDoc scoredoc in docs.ScoreDocs) {
                Document docforab = searcher.Doc(scoredoc.Doc);
                if (docforab.Get(DocID) == id) {
                  output = docforab.Get(ABSTRACT);
                 }
            }
            return output;
         }
        //get the information needs  from their files. 
        public void InformationNeedProcess(string filepath) {
            StreamReader file3 = new StreamReader(filepath);
           
            string content = file3.ReadToEnd();
            string[] separators = { ".I" };
            string[] inforneeds = content.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < inforneeds.Length; i++) {
                string[] separtors2 = {".D"};
                string[] segments = inforneeds[i].Split(separtors2, StringSplitOptions.RemoveEmptyEntries);
                segments[0] = segments[0].Replace(" ",string.Empty);//segments[0] represents queryid
                segments[1] = segments[1].Replace(" .",string.Empty);//segments[1] represents description.
                infneed.Add(segments[0], segments[1]);
            }

            file3.Close();
            
        }
        //give the system topicid and filepath, store the result
        public void SaveResults(string topicid,string filepath) {
            StreamWriter resultfile = new StreamWriter(filepath, true);//"true"means it can be appended by a new line in the exsiting results.
            //char[] c = { ' ' };
            topicid = topicid.Trim();
            string record = topicid + "\t" + "Q0";
            int rank = 0;
            string groupname = "9794182_10118705_9785094_codermen";
            foreach (ScoreDoc scoredoc in docs.ScoreDocs) {
                rank++;
                Document docofresult = searcher.Doc(scoredoc.Doc);
                
                resultfile.WriteLine(record +"\t"+docofresult.Get(DocID).ToString().Trim() +"\t"+rank.ToString() +"\t"+scoredoc.Score.ToString()+"\t"+groupname.Trim());
            }
            resultfile.Close();
        }
        public string ExpandWeightedQuery(string level, string query) {
            string expandedquery = "";
            WordNetEngine wordnet = new WordNetEngine();
            var directory = System.IO.Directory.GetCurrentDirectory();
            Dictionary<string, string> thesaurus = new Dictionary<string, string>();
            string path = directory + "\\wordnet\\";
            wordnet.LoadFromDirectory(path);
            if (wordnet.IsLoaded) {
                char[] delimiter = {' ',';'};
                string[] querylist = query.Split(delimiter,StringSplitOptions.RemoveEmptyEntries);
                //separate the text inputed into several parts;
                foreach (string item in querylist) {
                    var synSetList = wordnet.GetSynSets(item);//create a set of synonyms for the item
                    
                    if (synSetList.Count != 0) {//if there is synonym, it continues to do the next things
                        Dictionary<string, int> uniqueword = new Dictionary<string, int>();
                        
                        foreach (SynSet syns in synSetList)
                        {
                            
                            //syns.Words is a list not a string
                            foreach (string w in syns.Words) {
                                if (uniqueword.ContainsKey(w))
                                {
                                    uniqueword[w] = uniqueword[w] + 1;
                                }
                                else { uniqueword.Add(w, 1); }
                            }
                            
                            //if a user want to expand the query to a certian lexical level, such as hypernym...
                            //if the level is not synonym,it means the uniqueword will be larger 
                            if (level != "Synonym")
                            { 
                                SynSetRelation relation = (SynSetRelation)Enum.Parse(typeof(SynSetRelation), level);
                                var relationsynset = syns.GetRelatedSynSets(relation, true);
                                
                                foreach (SynSet element in relationsynset)
                                {
                                    foreach (string ite in element.Words) {
                                        if (uniqueword.ContainsKey(ite))
                                        {
                                            uniqueword[ite] = uniqueword[ite] + 1;
                                        }
                                        else {
                                            uniqueword.Add(ite, 1);
                                        }
                                    }
                                }
                                
                            }
                        }//finish exploring all synonyms for a specific item, so can add them into the dictionary
                        string lexical = "";
                        foreach (string w in uniqueword.Keys)
                        {
                            if (w != item) { lexical = lexical + " " + w; }
                        }

                        thesaurus.Add(item, lexical);
                    }//this condition is there are synonyms 

                }//end the loop for each item( item is actualy a query)

                foreach (string term in thesaurus.Keys) {
                    expandedquery = expandedquery + " " +term+"^5"+ thesaurus[term];
                }
            }//this condition is that wordnet engine is loaded, if you change the database directory, it can't work.
            return expandedquery;
        }
    }
}
