using OpenGloves_Unity.Data;

namespace OpenGloves_Unity.Shared
{
    public static class SharedLinks
    {
        /// <summary>
        /// A pre-initialized instance of a modified <see cref="Link"/> shared for mulitple mods to use.
        /// </summary>
        public static SharedLink LeftLink { get; private set; } = new SharedLink(Handedness.Left);

        /// <summary>
        /// A pre-initialized instance of a modified <see cref="Link"/> shared for mulitple mods to use.
        /// </summary>
        public static SharedLink RightLink { get; private set; } = new SharedLink(Handedness.Right);
    }
}