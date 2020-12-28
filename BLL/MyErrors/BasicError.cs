using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MyErrors
{
    public abstract class BasicError : Exception, IError 
    {

        

        public BasicError (IEnumerable<string> errors,ErrorCode errorcode)
        {
            this.Errorcode = errorcode;
            this.Errors = errors;
        
        }

        public ErrorCode Errorcode { get; }

        public IEnumerable<string> Errors { get; }
    }

}
