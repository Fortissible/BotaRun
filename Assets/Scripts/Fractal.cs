using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    public Mesh mesh;
    public Material material;
    public int maxChild;
    private int child;
    public float childSize;
    // Start is called before the first frame update
    private void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        if (child < maxChild)
        {
            new GameObject("Fractal Child").AddComponent<Fractal>().Create(this);
        }
    }

    private void Create(Fractal parent)
    {
        mesh = parent.mesh;
        material = parent.material;

        maxChild = parent.maxChild;
        child = parent.child + 1;
        childSize = parent.childSize;

        transform.parent = parent.transform;
        transform.localScale = Vector2.one * childSize;
        transform.localPosition = Vector2.up * (0.5f + 0.5f * childSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
