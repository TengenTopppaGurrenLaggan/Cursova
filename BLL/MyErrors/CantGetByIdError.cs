using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MyErrors
{
    public class CantGetByIdError : BasicError
    {

        public CantGetByIdError() : this(new List<String> { "this element not exist" }) { }


        public CantGetByIdError (string error) : this (new List<string> {error }) { }

        public CantGetByIdError(IEnumerable<string> Error) : base(Error, ErrorCode.CantGetById) { }



    }
}
