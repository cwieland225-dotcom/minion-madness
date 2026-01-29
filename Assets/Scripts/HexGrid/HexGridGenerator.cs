using UnityEngine;

namespace MinionMadness.HexGrid
{
    public class HexGridGenerator : MonoBehaviour
    {
        [Header("Grid Settings")]
        [SerializeField] private int width = 8;
        [SerializeField] private int height = 8;
        [SerializeField] private float hexSize = 1f;

        [Header("Prefabs")]
        [SerializeField] private HexCell cellPrefab;
        [SerializeField] private Transform gridRoot;
        [SerializeField] private Material[] tileMaterials;

        private HexCell[,] cells;

        public HexCell GetCell(int q, int r)
        {
            if (q < 0 || q >= width || r < 0 || r >= height)
            {
                return null;
            }

            return cells[q, r];
        }

        public void Generate()
        {
            if (cellPrefab == null)
            {
                Debug.LogError("HexGridGenerator requires a cell prefab.");
                return;
            }

            ClearExisting();
            cells = new HexCell[width, height];

            for (int r = 0; r < height; r++)
            {
                for (int q = 0; q < width; q++)
                {
                    HexCoordinates coords = new HexCoordinates(q, r);
                    Vector3 position = HexMetrics.AxialToWorld(coords, hexSize);

                    HexCell cell = Instantiate(cellPrefab, position, Quaternion.identity, gridRoot);
                    Material materialOverride = tileMaterials != null && tileMaterials.Length > 0
                        ? GetMaterialForIndex(q + r)
                        : null;
                    cell.Initialize(coords, materialOverride);
                    cells[q, r] = cell;
                }
            }
        }

        private void ClearExisting()
        {
            if (gridRoot == null)
            {
                gridRoot = transform;
            }

            for (int i = gridRoot.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(gridRoot.GetChild(i).gameObject);
            }
        }

        private Material GetMaterialForIndex(int index)
        {
            if (tileMaterials == null || tileMaterials.Length == 0)
            {
                return null;
            }

            int safeIndex = Mathf.Abs(index) % tileMaterials.Length;
            return tileMaterials[safeIndex];
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            width = Mathf.Max(1, width);
            height = Mathf.Max(1, height);
            hexSize = Mathf.Max(0.1f, hexSize);
        }
#endif
    }
}
