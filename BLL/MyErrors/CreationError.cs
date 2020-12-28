using BLL.MyErrors;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MyErrors
{
    public class CreationError : BasicError
    {
        public CreationError() : this(new List<String> { "Cant create , Check Atributes that your write" }) { }



        public CreationError(string error) : this(new List<string> { error }) { }
        public CreationError(IEnumerable<string> Error) : base(Error, ErrorCode.CreationError) { }

    }
}
