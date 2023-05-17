using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keep a record of the current side of the cube in the form of lists of gameObject
public class CubeState : MonoBehaviour
{
    // Sides
    public List<GameObject> _front = new List<GameObject>(), _back = new List<GameObject>();
    public List<GameObject> _right = new List<GameObject>(), _left = new List<GameObject>();
    public List<GameObject> _up = new List<GameObject>(), _down = new List<GameObject>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
