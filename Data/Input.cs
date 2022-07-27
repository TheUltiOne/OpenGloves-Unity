using System.Runtime.InteropServices;

namespace OpenGloves_Unity.Data
{
    /// <summary>
    /// A struct that contains information about force feedback inputs.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Input
    {
        public Input(short thumb = 0, short index = 0, short middle = 0, short ring = 0, short pinky = 0)
        {
            ThumbCurl = thumb;
            IndexCurl = index;
            MiddleCurl = middle;
            RingCurl = ring;
            PinkyCurl = pinky;
        }

        public short ThumbCurl { get; set; }
        public short IndexCurl { get; set; }
        public short MiddleCurl { get; set; }
        public short RingCurl { get; set; }
        public short PinkyCurl { get; set; }
    }
}