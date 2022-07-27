using OpenGloves_Unity.Data;

namespace OpenGloves_Unity.Extensions
{
    public static class HandednessExtensions
    {
        public static string HandednessToString(this Handedness handedness)
            => handedness.ToString().ToLower();
    }
}