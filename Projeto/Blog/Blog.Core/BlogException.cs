using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
    [Serializable]
    public class BlogException : Exception
    {
        public BlogException(string message)
            : base(message)
        {
        }

        public BlogException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {
        }
        public BlogException(SerializationInfo
            info, StreamingContext context)
            : base(info, context)
        {
        }

        public BlogException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
