using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Search;
using FieldInvertState = Lucene.Net.Index.FieldInvertState;

namespace _647project
{
    class CustomSimilarity: DefaultSimilarity
    {    //change the sqrt(termfrequence/numberofallterms) for (termfrequence/numberofallterms)
        public override float Tf(float freq)
        {
            //return(float) System.Math.Sqrt(freq);
            return freq;
        }
        /*
        public override float LengthNorm(string fieldName, int numTerms)
        {
            //return (float)(1.0 / System.Math.Sqrt(numTerms));
            return (float)(1.0 / numTerms);
        }
        */
    }
}
