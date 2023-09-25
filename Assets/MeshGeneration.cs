using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class MeshGeneration : MonoBehaviour
{
    [SerializeField] private float lineThickness = 1f;
    [SerializeField] private float polyDistance = 0.4f;

    private Mesh mesh;
    private Vector3 lastMousePosition;
    private Material materialAssign;

    private int lastSortingOrder;
    private EdgeCollider2D edgeCollider;

    [SerializeField] private Material redMaterial;
    [SerializeField] private Material greenMaterial;
    [SerializeField] private Material blackMaterial;
    [SerializeField] private Material brownMaterial;
    [SerializeField] private TMP_Text brushColor;

    private Menu_Handler menuHandler;

    private void Awake()
    {
        menuHandler = FindObjectOfType<Menu_Handler>();
    }

    private void Start()
    {
        materialAssign = blackMaterial;
        blackMaterial.color = Color.black;
    }

    void Update()
    {
        Camera camera = Camera.main;
        Vector3 mousePosition = GetMouseWorldPosition(camera);

        if (Input.GetMouseButtonDown(0))
        {
            OnMouseButtonDown(mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            OnMouseButtonHold(mousePosition, camera);
        }
    }

    private void OnMouseButtonDown(Vector3 mousePosition)
    {
        if(menuHandler.paused || menuHandler.startPanelOn)
        {
            return;
        }

        Vector3[] verticies = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        verticies[0] = new Vector3(mousePosition.x - lineThickness, mousePosition.y + lineThickness, 0);
        verticies[1] = new Vector3(mousePosition.x - lineThickness, mousePosition.y - lineThickness, 0);
        verticies[2] = new Vector3(mousePosition.x + lineThickness, mousePosition.y - lineThickness, 0);
        verticies[3] = new Vector3(mousePosition.x + lineThickness, mousePosition.y + lineThickness, 0);

        uv[0] = new Vector2(mousePosition.x - lineThickness, mousePosition.y + lineThickness);
        uv[1] = new Vector2(mousePosition.x - lineThickness, mousePosition.y - lineThickness);
        uv[2] = new Vector2(mousePosition.x + lineThickness, mousePosition.y - lineThickness);
        uv[3] = new Vector2(mousePosition.x + lineThickness, mousePosition.y + lineThickness);

        triangles[0] = 0;
        triangles[1] = 3;
        triangles[2] = 1;

        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;

        mesh = new Mesh();

        mesh.vertices = verticies;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.MarkDynamic();

        GameObject gameObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer), typeof(EdgeCollider2D), typeof(PolygonCollider2D), typeof(Script), typeof(SortingGroup));
        gameObject.tag = "ColorCollision";

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = materialAssign;

        gameObject.GetComponent<SortingGroup>().sortingLayerName = "Color";

        lastSortingOrder++;
        gameObject.GetComponent<MeshRenderer>().sortingOrder = lastSortingOrder;

        edgeCollider = gameObject.GetComponent<EdgeCollider2D>();
        gameObject.GetComponent<EdgeCollider2D>().isTrigger = true;
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;

        Vector2[] polyPoints = new Vector2[mesh.vertices.Length];
        for (int i = 0; i < polyPoints.Length; i++)
        {
            polyPoints[i] = new Vector2(mesh.vertices[i].x, mesh.vertices[i].y); 
        }
        gameObject.GetComponent<PolygonCollider2D>().points = polyPoints;

        Vector2[] edgePoints = new Vector2[2];

        edgePoints[0] = new Vector2(mesh.vertices[0].x, mesh.vertices[0].y);
        edgePoints[1] = new Vector2(mesh.vertices[1].x, mesh.vertices[1].y);

        edgeCollider.points = edgePoints;

        lastMousePosition = mousePosition;
    }

    private void OnMouseButtonHold(Vector3 mousePosition, Camera camera)
    {
        if (menuHandler.paused || menuHandler.startPanelOn)
        {
            return;
        }

        Vector3 currentPos = GetMouseWorldPosition(camera);
        if (Vector3.Distance(currentPos, lastMousePosition) > polyDistance)
        {
            Vector3[] vertices = new Vector3[mesh.vertices.Length + 2];
            Vector2[] uv = new Vector2[mesh.uv.Length + 2];
            int[] triangles = new int[mesh.triangles.Length + 6];

            mesh.vertices.CopyTo(vertices, 0);
            mesh.uv.CopyTo(uv, 0);
            mesh.triangles.CopyTo(triangles, 0);

            Vector3 direction = (mousePosition - lastMousePosition).normalized;
            Vector3 normal2D = new Vector3(0, 0, -1f);
            Vector3 upVector = mousePosition + Vector3.Cross(direction, normal2D) * lineThickness;
            Vector3 downVector = mousePosition + Vector3.Cross(direction, normal2D * -1f) * lineThickness;

            int vIndex = vertices.Length - 4;
            int vIndex0 = vIndex + 0;
            int vIndex1 = vIndex + 1;
            int vIndex2 = vIndex + 2;
            int vIndex3 = vIndex + 3;


            vertices[vIndex2] = upVector;
            vertices[vIndex3] = downVector;

            uv[vIndex2] = upVector;
            uv[vIndex3] = downVector;

            int tIndex = triangles.Length - 6;

            triangles[tIndex + 0] = vIndex0;
            triangles[tIndex + 1] = vIndex2;
            triangles[tIndex + 2] = vIndex1;

            triangles[tIndex + 3] = vIndex1;
            triangles[tIndex + 4] = vIndex2;
            triangles[tIndex + 5] = vIndex3;

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;

            if(edgeCollider != null)
            {
                edgeCollider.points = ConvertToPolygonPoints(mesh.vertices);
            }

            lastMousePosition = mousePosition;
        }
    }

    private Vector2[] ConvertToPolygonPoints(Vector3[] vertices)
    {
        Vector2[] polygonPoints = new Vector2[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            polygonPoints[i] = new Vector2(vertices[i].x, vertices[i].y);
        }
        return polygonPoints;
    }

    public static Vector3 GetMouseWorldPosition(Camera cam)
    {
        var cPos = cam.transform.position;
        var mousePos = Input.mousePosition;
        mousePos.z = cPos.z * -1f;

        Vector3 vec = cam.ScreenToWorldPoint(mousePos);
        vec.z = 0f;
        return vec;
    }

    public void RedPressed()
    {
        materialAssign = new Material(materialAssign);
        materialAssign.color = Color.red;
        brushColor.SetText("Red");
        brushColor.color = Color.red;
    }

    public void GreenPressed()
    {
        materialAssign = new Material(materialAssign);
        materialAssign.color = Color.green;
        brushColor.SetText("Green");
        brushColor.color = new Color32(56, 161, 51, 255);
    }

    public void BlackPressed()
    {
        materialAssign = new Material(materialAssign);
        materialAssign.color = Color.black;
        brushColor.SetText("Black");
        brushColor.color = Color.black;
    }

    public void BrownPressed()
    {
        materialAssign = new Material(materialAssign);
        materialAssign = brownMaterial;
        brushColor.SetText("Brown");
        brushColor.color = new Color32(133, 66, 19, 255);
    }

    public void LineThickness(float value)
    {
        lineThickness = value;
    }
}
