using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{

    /// <summary>
    /// Helper used as a global object for CSharpScripting.
    /// </summary>
    public class CustomScriptingHelper
    {
        private CustomScriptingHelper() { }

        internal readonly static CustomScriptingHelper Instance = new CustomScriptingHelper();

        public CustomStruct NewCustomStruct(int intValue, DateTime dateValue, string stringValue)
        {
            return new CustomStruct(intValue, dateValue, stringValue);
        }
    }

}
