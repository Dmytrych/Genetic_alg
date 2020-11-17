using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Lab2._1
{
    class GeneCollection
    {
        private readonly List<BackpackItem> _genesList;
        public BackpackItem[] Genes
        {
            get
            {
                var listCopy = new BackpackItem[_genesList.Count];
                _genesList.CopyTo(listCopy);
                return listCopy;
            }
        }

        public GeneCollection(List<BackpackItem> genesList)
        {
            _genesList = genesList;
        }
    }
}
