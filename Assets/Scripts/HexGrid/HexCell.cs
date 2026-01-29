using UnityEngine;

namespace MinionMadness.HexGrid
{
    public class HexCell : MonoBehaviour
    {
        [SerializeField] private Renderer cellRenderer;

        public HexCoordinates Coordinates { get; private set; }

        public void Initialize(HexCoordinates coordinates, Material materialOverride = null)
        {
            Coordinates = coordinates;

            if (materialOverride != null && cellRenderer != null)
            {
                cellRenderer.sharedMaterial = materialOverride;
            }
        }
    }
}
