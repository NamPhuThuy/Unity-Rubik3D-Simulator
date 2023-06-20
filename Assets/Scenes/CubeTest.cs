using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 5f * dt, 0));
        }
    }
}
