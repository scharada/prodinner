using System;

namespace Omu.AwesomeDemo.Core
{
    [Serializable]
    public class AwesomeDemoException : Exception
    {
        public AwesomeDemoException(string message)
            : base(message)
        {
        }
    }
}