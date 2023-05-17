using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour
{
    CubeState _cubeState;
    public Transform _up, _down;
    public Transform _left, _right;
    public Transform _front, _back;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Set the color of the cubeMap
    public void Set()
    {
        _cubeState = FindObjectOfType<CubeState>();

        UpdateMap(_cubeState._front, _front);
        // UpdateMap(_cubeState._back, _back);
        // UpdateMap(_cubeState._left, _left);
        // UpdateMap(_cubeState._right, _right);
        // UpdateMap(_cubeState._up, _up);
        // UpdateMap(_cubeState._down, _down);

    }

    //Update the color of the face in the cubeMap dependent on what side of the 
    // pieces the rayCastHit 
    void UpdateMap(List<GameObject> face, Transform side)
    {
        int i = 0;
        foreach (Transform map in side)
        {
            if (face[0].name[0] == 'F')
            {
                map.GetComponent<Image>().color = Color.red;
            }
            // else if (face[i].name[0] == 'B')
            //     map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
            // else if (face[i].name[0] == 'L')
            //     map.GetComponent<Image>().color = Color.blue;
            // else if (face[i].name[0] == 'R')
            //     map.GetComponent<Image>().color = Color.green;
            // else if (face[i].name[0] == 'U')
            //     map.GetComponent<Image>().color = Color.yellow;
            // else if (face[i].name[0] == 'D')
            //     map.GetComponent<Image>().color = Color.white;

            i++;
        }
    }
}
