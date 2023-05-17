using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    Vector2 _firstPressPos;
    Vector2 _secondPressPos;
    Vector2 _currentSwipe;
    Vector3 _previousMousePosition;
    Vector3 _mouseDelta;


    public GameObject _target;
    float _speed = 300f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
        Drag();
        
    }

    void Drag()
    {

        if (Input.GetMouseButton(1))
        {
            // While right mouse is held down, the cube can be move around its central
            _mouseDelta = Input.mousePosition - _previousMousePosition;
            _mouseDelta *= .1f; //reduction of rotation speed

            transform.rotation = Quaternion.Euler(_mouseDelta.y, -_mouseDelta.x, 0f) * transform.rotation;
        }
        else
        {
            //automatically move to the target position
            if (this.transform.rotation != _target.transform.rotation)
            {
                var step = _speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, _target.transform.rotation, step);
            }
        }

        _previousMousePosition = Input.mousePosition;
    }

    
    
    void Swipe()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // get the 2D position of the 1st mouse click
            _firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            print("1st Press pos: " + _firstPressPos);
        }   

        if (Input.GetMouseButtonUp(1))
        {
            _secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            print("2nd Press pos: " + _secondPressPos);

            // Calculate the vector made by 1st and 2nd mouse click
            _currentSwipe = new Vector2(_secondPressPos.x - _firstPressPos.x, _secondPressPos.y - _firstPressPos.y);

            // Normalize the currentSwipe vector
            _currentSwipe.Normalize();


            if (LeftSwipe(_currentSwipe))
            {
                _target.transform.Rotate(new Vector3(0f, 90f, 0f), Space.World);
            }
            else if (RightSwipe(_currentSwipe))
            {
                _target.transform.Rotate(new Vector3(0f, -90f, 0f), Space.World);
            }
            else if (UpLeftSwipe(_currentSwipe))
            {
                _target.transform.Rotate(new Vector3(90f, 0f, 0), Space.World);
            }
            else if (UpRightSwipe(_currentSwipe))
            {
                _target.transform.Rotate(new Vector3(0f, 0f, -90f), Space.World);
            }
            else if (DownLeftSwipe(_currentSwipe))
            {
                _target.transform.Rotate(new Vector3(0f, 0f, 90f), Space.World);
            }
            else if (DownRightSwipe(_currentSwipe))
            {
                _target.transform.Rotate(new Vector3(-90f, 0f, 0), Space.World);
            }


        }
    }

    bool LeftSwipe(Vector2 swipe)
    {
        print("LeftSwipe");
        return swipe.x < 0f && swipe.y > -.5f && swipe.y < .5f;
    }

    bool RightSwipe(Vector2 swipe)
    {
        print("RightSwipe");
        return swipe.x > 0f && swipe.y > -.5f && swipe.y < .5f;
    }

    bool UpLeftSwipe(Vector2 swipe)
    {
        print("UpLeftSwipe");
        return swipe.x < 0f && swipe.y > 0f;
    }

    bool UpRightSwipe(Vector2 swipe)
    {
        print("UpRightSwipe");
        return swipe.x > 0f && swipe.y > 0f; 
    }

    bool DownLeftSwipe(Vector2 swipe)
    {
        print("DownLeftSwipe");
        return swipe.x < 0f && swipe.y < 0f;
    }

    bool DownRightSwipe(Vector2 swipe)
    {
        print("DownRightSwipe");
        return swipe.x > 0f && swipe.y < 0f;
    }


}
