using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCube : MonoBehaviour
{
    public Transform _tUp, _tDown;
    public Transform _tFront, _tBack;
    public Transform _tLeft, _tRight;
    
    private int _layerMask = 1 << 8; // this layerMask is for the faces of the cube only
    CubeState _cubeState;
    CubeMap _cubeMap;

    void Start()
    {
        _cubeState = FindObjectOfType<CubeState>();
        if (_cubeState == null)
            Debug.LogWarning("ReadCube.cs: CubeState is not found");

        _cubeMap = FindObjectOfType<CubeMap>();
        if (_cubeMap == null)
            Debug.LogWarning("ReadCube.cs: CubeMap is not found");


        List<GameObject> facesHit = new List<GameObject>();
        Vector3 ray = _tFront.transform.position;
        RaycastHit hit;

        //Dose the ray intersect any objects in the layerMask? 
        if (Physics.Raycast(ray, _tFront.right, out hit, Mathf.Infinity, _layerMask))
        {
            Debug.DrawRay(ray, _tFront.right * hit.distance, Color.yellow);
            facesHit.Add(hit.collider.gameObject);
            print(hit.collider.gameObject.name);
        }
        else
        {
            Debug.DrawRay(ray, _tFront.right * 1000, Color.green);
        }

        _cubeState._front = facesHit;
        _cubeMap.Set();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
