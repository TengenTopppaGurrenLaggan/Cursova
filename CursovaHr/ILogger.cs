using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaHr
{
    public interface ILogger
    {

        void Info(string message, string args = null);
        void Error(string message, string args = null);
    }
}
