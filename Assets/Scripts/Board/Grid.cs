using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {

    public enum CellType { neutral, special, invisible }
    public GameObject gameObject { get; private set; }

    //Materials
    private Material[] materials = new Material[2];
    private Color specialColor;

    private List<TileModel> cells = new List<TileModel>();

    //Creates a grid with different sub materials
    public Grid (float cellSize, Color specialColor, List<TileModel> cells) {
        this.cells = cells;
        this.specialColor = specialColor;

        SetMaterials();

        gameObject = CreateGridGameObject(cellSize);
    }

    //Set material on mesh
    private void SetMaterials () {
        materials[(int)CellType.neutral] = Resources.Load("Materials/Grid Cells/mat_grid_neutral") as Material;
        materials[(int)CellType.special] = Resources.Load("Materials/Grid Cells/mat_grid_special") as Material;
        materials[(int)CellType.special].color = specialColor;
    }

    //Updates the existing grid
    public void UpdateGrid () {
        UpdateHeight(gameObject.GetComponent<MeshFilter>().mesh);
    }

    //Updates the height on verts
    private void UpdateHeight (Mesh mesh) {
        Vector3[] vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++) {
            vertices[i].y = CheckHeight(gameObject.transform.position + mesh.vertices[i]);
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }

    //Checks height on position
    private float CheckHeight (Vector3 position) {
        Ray heightChecker = new Ray(position + Vector3.up * 10, Vector3.down);
        RaycastHit hit;

        Physics.Raycast(heightChecker, out hit, Mathf.Infinity, 1 << 8);

        return hit.point.y + 0.01f;
    }

    //Creates the grid gameobject
    private GameObject CreateGridGameObject (float cellSize) {
        //Variable creation
        GameObject go = new GameObject("GridObject");
        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        MeshFilter mf = go.AddComponent<MeshFilter>();

        //List of diffrent submeshes
        List<Vector2> meshesInvisible = new List<Vector2>();
        List<Vector2> meshesNeutral = new List<Vector2>();
        List<Vector2> meshesSpecial = new List<Vector2>();

        //List for the combined meshes
        List<Mesh> combinedMeshes = new List<Mesh>();

        //Sort the types into different lists
        for (int i = 0; i < cells.Count; i++) {
            if (cells[i].Type == TileModel.CellType.error)
                meshesInvisible.Add(cells[i].Position);
            else if (cells[i].Type == TileModel.CellType.walkable)
                meshesNeutral.Add(cells[i].Position);
            else if (cells[i].Type == TileModel.CellType.blocked)
                meshesSpecial.Add(cells[i].Position);
        }

        //Combine the the meshes
        combinedMeshes.Add(CreateGridMesh(cellSize, meshesInvisible));
        combinedMeshes.Add(CreateGridMesh(cellSize, meshesNeutral));
        combinedMeshes.Add(CreateGridMesh(cellSize, meshesSpecial));

        //Creathe the final whole mesh
        Mesh mesh = CombineMeshes(combinedMeshes, false);

        mf.mesh = mesh;

        //Assign materials depending on submesh count
        if (mesh.subMeshCount > 1) {
            mr.materials = materials;
        }
        else {
            mr.material = materials[(int)CellType.neutral];
        }

        //Shadow casting and recieving
        mr.receiveShadows = false;
        mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        //Calculate bounds and normals
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        return go;
    }

    //Combines meshes
    private Mesh CombineMeshes (List<Mesh> meshes, bool mergeSubMeshes = true) {
        Mesh mesh = new Mesh();
        CombineInstance combine = new CombineInstance();
        List<CombineInstance> combineList = new List<CombineInstance>();

        for (int i = 0; i < meshes.Count; i++) {
            combine.mesh = meshes[i];
            combineList.Add(combine);
        }

        mesh.CombineMeshes(combineList.ToArray(), mergeSubMeshes, false);
        return mesh;
    }

    //Combines quads to one mesh
    private Mesh CreateGridMesh (float cellSize, List<Vector2> cells) {
        Mesh mesh = new Mesh();
        List<Mesh> meshes = new List<Mesh>();
        mesh.name = "Grid Mesh";

        for (int i = 0; i < cells.Count; i++) {
            meshes.Add(CreateGridCell(cellSize, cells[i]));
        }

        mesh = CombineMeshes(meshes);
        mesh.MarkDynamic();

        return mesh;
    }

    //Create a quad in position
    private Mesh CreateGridCell (float cellSize, Vector2 position) {
        Mesh mesh = new Mesh();
        float offset = -0.5f;

        mesh.name = "Grid Cell";
        mesh.vertices = new Vector3[] {
            new Vector3(offset + position.x, 0, offset + position.y),
            new Vector3(cellSize + position.x + offset, 0, offset + position.y),
            new Vector3(cellSize + position.x + offset, 0, cellSize + position.y + offset),
            new Vector3(offset + position.x, 0, cellSize + position.y + offset)
        };

        mesh.uv = new Vector2[] {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 1),
            new Vector2(1, 0)
        };

        mesh.triangles = new int[] { 2, 1, 0, 3, 2, 0 };
        mesh.normals = new Vector3[] { Vector3.up, Vector3.up, Vector3.up, Vector3.up };

        return mesh;
    }
}

//A cell in the grid
public class GridCell {

    public Vector2 Position { get; private set; }
    public Grid.CellType Type { get; private set; }

    public GridCell (Vector2 position, Grid.CellType type) {
        this.Position = position;
        this.Type = type;
    }
}
