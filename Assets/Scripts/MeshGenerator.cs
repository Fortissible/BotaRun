using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{   
    Vector3[] mVerts;
    Vector2[] mUVs;
    int[] mTris;
    public Material material;
    private Mesh mesh;
    public int maxChild;
    private int child;
    public float childSize;

    // Start is called before the first frame update
    void Start()
    {
        mVerts = new Vector3[3];
        mUVs = new Vector2[3];
        mTris = new int[3];

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;

        mVerts[0] = new Vector3(1.0f, 0.0f, 0.0f);
        mVerts[1] = new Vector3(0.0f, 0.0f, 0.0f);
        mVerts[2] = new Vector3(0.5f, 0.86f, 0.0f);

        mUVs[0] = new Vector2(1.0f, 0.0f);
        mUVs[1] = new Vector2(0.0f, 0.0f);
        mUVs[2] = new Vector2(0.5f, 0.86f);

        mTris[0] = 0;
        mTris[1] = 1;
        mTris[2] = 2;

        mesh.vertices = mVerts;
        mesh.uv = mUVs;
        mesh.triangles = mTris;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        if (child < maxChild)
        {
            new GameObject("Fractal Child").AddComponent<MeshGenerator>().CreateMinus(this, new Vector2(1.5f,0f));
            new GameObject("Fractal Child").AddComponent<MeshGenerator>().CreateMinus(this, new Vector2(0.5f,0.86f));
            new GameObject("Fractal Child").AddComponent<MeshGenerator>().CreateMinus(this, new Vector2(1.5f, 0.86f));
            //new GameObject("Fractal Child").AddComponent<MeshGenerator>().CreatePlus(this, new Vector2(0.86f, 0f));
            //new GameObject("Fractal Child").AddComponent<MeshGenerator>().CreatePlus(this, new Vector2(0f, 0f));
           // new GameObject("Fractal Child").AddComponent<MeshGenerator>().CreatePlus(this, new Vector2(0.43f, 0.75f));
        }
    }

    private void CreateMinus(MeshGenerator parent, Vector2 direction)
    {
        mesh = parent.mesh;
        material = parent.material;
        gameObject.AddComponent<MeshFilter>().mesh = mesh;

        maxChild = parent.maxChild;
        child = parent.child + 1;
        childSize = parent.childSize;

        transform.parent = parent.transform;
        transform.localScale = Vector2.one * -childSize;
        transform.localPosition = direction * (0.5f + 0.5f * childSize);
    }

    private void CreatePlus(MeshGenerator parent, Vector2 direction)
    {
        mesh = parent.mesh;
        material = parent.material;
        gameObject.AddComponent<MeshFilter>().mesh = mesh;

        maxChild = parent.maxChild;
        child = parent.child + 1;
        childSize = parent.childSize;

        transform.parent = parent.transform;
        transform.localScale = Vector2.one * childSize;
        transform.localPosition = direction * (0.5f + 0.5f * childSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
