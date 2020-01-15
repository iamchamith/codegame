using System.Collections.Generic;
using System.Linq;
using BlocklyPro.Core.Domain.Play;
using BlocklyPro.Core.Utility;

namespace BlocklyPro.Core.Helper
{
    public class CYC
    {
        public static int Calculate(List<GameCode> codes)
        {
            //https://www.perforce.com/blog/qac/what-cyclomatic-complexity
            //cyc = e-n+2p

           codes.RemoveAll(p =>
                new List<Enums.CodeType>()
                {
                    Enums.CodeType.Loop,
                    Enums.CodeType.Function
                }.Contains(p.CodeType));

           var nodes = codes.Count;
           var edges = codes.Count(p => new List<Enums.CodeType>()
                       {
                           Enums.CodeType.Condition,
                           Enums.CodeType.Loop2
                       }.Contains(p.CodeType)) * 2 +
                       codes.Count(p => new List<Enums.CodeType>()
                       {
                           Enums.CodeType.Statement
                       }.Contains(p.CodeType));

           return edges - nodes + 2;
        }
    }
}
