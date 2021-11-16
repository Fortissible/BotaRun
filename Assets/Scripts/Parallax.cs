using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallax;
    private float length, s_post;
    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        s_post = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (mainCamera.transform.position.x * (1 - parallax));
        float distance = (mainCamera.transform.position.x * parallax);

        transform.position = new Vector3(s_post + distance, transform.position.y, transform.position.z);

        if (temp > s_post + length) s_post += length;
        else if (temp < s_post) s_post -= length;
    }
}
