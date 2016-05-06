using System;

namespace HungLocSon.EHLS
{
    public class EDocuments
    {
        public EDocuments()
        {
        }


        private int docid;
        public int DocId
        {
            get { return docid; }
            set { docid = value; }
        }

        private string docname;
        public string DocName
        {
            get { return docname; }
            set { docname = value; }
        }

        public EDocuments(int c)
        {
            this.docid = c;
        }
    }
}

