using System;
using OpenGloves_Unity.Data;
using OpenGloves_Unity.Shared;

namespace OpenGloves_Unity.Extensions
{
    public static class HandednessExtensions
    {
        public static string HandednessToString(this Handedness handedness)
            => handedness.ToString().ToLower();

        public static SharedLink SharedLinkFromHandedness(this Handedness handedness)
        {
            switch (handedness)
            {
                case Handedness.Right:
                    return SharedLinks.RightLink;
                case Handedness.Left:
                    return SharedLinks.LeftLink;
            }

            throw new ArgumentOutOfRangeException(nameof(handedness), $"Unexpected handedness: {handedness}");
        }
    }
}