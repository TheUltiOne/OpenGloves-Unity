using System.Runtime.InteropServices;

namespace OpenGloves_Unity.Data
{
    /// <summary>
    /// A struct that contains information about force feedback inputs.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)] // As per the wiki docs, the struct needs ot be in this order specifically for it to function, therefore, it is important to specify this attribute.
    public struct Input
    {
        public Input(short thumb = 0, short index = 0, short middle = 0, short ring = 0, short pinky = 0)
        {
            thumbCurl = thumb;
            indexCurl = index;
            middleCurl = middle;
            ringCurl = ring;
            pinkyCurl = pinky;
        }

        public short thumbCurl { get; set; }
        public short indexCurl { get; set; }
        public short middleCurl { get; set; }
        public short ringCurl { get; set; }
        public short pinkyCurl { get; set; }
    }
}