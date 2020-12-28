using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{


    public enum ErrorCode
    {

       
        CantGetById = 1000,
        NullableItem = 1001,         
        IncorrectId = 1002 ,          
		CreationError = 1003 ,
        

    }
    public interface IError 
    {
        ErrorCode Errorcode { get; }
        IEnumerable<string> Errors { get; }
    }
}
