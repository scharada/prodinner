using System;

namespace Omu.ProDinner.Core
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