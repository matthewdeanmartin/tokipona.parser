using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Palmmedia.ReportGenerator.Reporting.Rendering
{
    /// <summary>
    /// Occurs when saving of a report fails.
    /// </summary>
    [Serializable]
    public class RenderingException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderingException" /> class.
        /// </summary>
        public RenderingException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderingException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public RenderingException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderingException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner <see cref="Exception"/></param>
        public RenderingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderingException" /> class.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/>.</param>
        /// <param name="streamingContext">The <see cref="StreamingContext"/>.</param>
        protected RenderingException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
