using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MyErrors
{
     public class NullableItemError : BasicError
    {
        public NullableItemError() : this(new List<String> { "Nullable Item" }) { }



        public NullableItemError(IEnumerable<string> Error) : base(Error, ErrorCode.NullableItem) { }

    }
}
