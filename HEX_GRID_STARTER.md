# Hex Grid Starter (Unity)

This guide walks you through using the provided scripts to generate a hex grid in Unity.

## 1) Create a basic Unity scene
1. Open your Unity project.
2. Create a new scene (or use an existing one).
3. Save the scene as `HexGridDemo`.

## 2) Create a HexCell prefab
1. In the **Hierarchy**, right-click and select **3D Object > Cylinder** (or **Quad** if you prefer flat tiles).
2. Rename it to `HexCell`.
3. Adjust scale to look hex-like:
   - For a cylinder, set **Y scale** to something small (e.g., `0.1`).
4. Add a **Collider** if you want clickable tiles later (e.g., **MeshCollider** or **BoxCollider**).
5. Create a folder named `Prefabs` in your project.
6. Drag the `HexCell` object into `Prefabs` to create a prefab.
7. Delete the object from the scene (keep the prefab).

## 3) Add the HexGridGenerator
1. Create an empty GameObject in the scene named `HexGrid`.
2. Add the script `HexGridGenerator` to it.
3. Create an empty child GameObject named `GridRoot` (optional but keeps the hierarchy clean).
4. Assign fields in the Inspector:
   - **Cell Prefab**: drag your `HexCell` prefab here.
   - **Grid Root**: drag `GridRoot` here (or leave empty to use `HexGrid`).
   - **Width/Height**: set to `8` or `10` to start.
   - **Hex Size**: leave at `1`.

## 4) Optional: Add materials
1. Create materials (e.g., Grass, Sand, Stone).
2. Assign them to **Tile Materials** array in `HexGridGenerator`.
3. The grid will cycle materials by `(q + r)`.

## 5) Generate the grid
1. Add a **Generate** button by using Unity’s inspector and calling the method:
   - In play mode, open the `HexGrid` object and call **Generate** from the component’s context menu (three dots).
2. Or call it from `Start()` by adding this to `HexGridGenerator`:
   ```csharp
   private void Start()
   {
       Generate();
   }
   ```

## 6) Verify placement
- The grid should appear as a staggered hex layout.
- If tiles overlap, reduce **Hex Size**.
- If tiles are too far apart, increase **Hex Size**.

## 7) Next suggested step
Add a simple click-to-select system:
- Raycast from mouse to `HexCell` collider.
- Highlight selected cell material.

---

### Common issues
- **Nothing appears**: Ensure `Cell Prefab` is assigned.
- **Cells all at origin**: Check `HexMetrics.AxialToWorld` or prefab position offsets.
- **Grid spawns under terrain**: Raise the `HexGrid` object’s Y position.

