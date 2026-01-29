using UnityEngine;

namespace MinionMadness.HexGrid
{
    public static class HexMetrics
    {
        public const float OuterRadius = 1f;
        public const float InnerRadius = OuterRadius * 0.866025404f;

        public static Vector3 AxialToWorld(HexCoordinates coordinates, float hexSize)
        {
            float x = hexSize * InnerRadius * 2f * (coordinates.Q + coordinates.R * 0.5f);
            float z = hexSize * OuterRadius * 1.5f * coordinates.R;
            return new Vector3(x, 0f, z);
        }
    }
}
