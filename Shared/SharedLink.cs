using System;
using OpenGloves_Unity.Data;

namespace OpenGloves_Unity.Shared
{
    public class SharedLink : Link
    {
        public SharedLink(Handedness handedness) : base(handedness)
        { }

        [Obsolete("This is not supported in Shared Links.", true)]
        public new void Dispose()
        {
            throw new NotImplementedException("This method is obsolete in Shared Links.");
        }
    }
}