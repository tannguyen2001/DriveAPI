using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Core.Exceptions
{
    public class ExceptionValidate:Exception
    {
        string _messenger;
        IDictionary _errorMsgs;
        public ExceptionValidate(string messenger,List<string> errorMsgs)
        {
            _messenger = messenger;
            _errorMsgs = new Dictionary<string, List<string>>();
            _errorMsgs.Add("User",errorMsgs); 
        }

        public override string Message => this._messenger;
        public override IDictionary Data => this._errorMsgs;
    }
}
