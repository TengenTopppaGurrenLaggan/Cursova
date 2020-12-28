using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MyErrors
{
    public class IncorrectId : BasicError
    {
        public IncorrectId() : this(new List<String> { "Id Cant be <=0" }) { }


      

        public IncorrectId(IEnumerable<string> Error) : base(Error, ErrorCode.IncorrectId) { }

    }
}
