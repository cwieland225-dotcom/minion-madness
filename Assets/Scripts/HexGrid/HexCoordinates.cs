using System;
using UnityEngine;

namespace MinionMadness.HexGrid
{
    [Serializable]
    public struct HexCoordinates
    {
        public int Q;
        public int R;

        public HexCoordinates(int q, int r)
        {
            Q = q;
            R = r;
        }

        public int S => -Q - R;

        public override string ToString()
        {
            return $"({Q}, {R}, {S})";
        }

        public static readonly HexCoordinates[] Directions =
        {
            new HexCoordinates(1, 0),
            new HexCoordinates(1, -1),
            new HexCoordinates(0, -1),
            new HexCoordinates(-1, 0),
            new HexCoordinates(-1, 1),
            new HexCoordinates(0, 1)
        };

        public HexCoordinates GetNeighbor(int directionIndex)
        {
            if (directionIndex < 0 || directionIndex >= Directions.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(directionIndex));
            }

            HexCoordinates direction = Directions[directionIndex];
            return new HexCoordinates(Q + direction.Q, R + direction.R);
        }
    }
}
