using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Utility
{
    public static class Constantes
    {
        public const string passPhrase = "GAP2016F*";
        public const string saltValue = "Develop";
        public const string hashAlgorithm = "SHA1";
        public const int passwordIterations = 2;
        public const string initVector = "GAPDevelop2016F*";
        public const int keySize = 256;
    }
}
