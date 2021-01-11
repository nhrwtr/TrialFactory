using System;
using System.Collections.Generic;
using System.Text;

namespace General.Util
{
    public class GuidFactory
    {
        public static string Create()
        {
            string guid = Guid.NewGuid().ToString();
            return guid;
        }
    }
}
