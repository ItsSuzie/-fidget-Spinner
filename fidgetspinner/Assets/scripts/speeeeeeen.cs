using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://answers.unity.com/questions/277426/spinning-an-object-using-touch-input.html
public class speeeeeeen : MonoBehaviour
{


    public enum ROT_DIR
    {
        ROT_X,
        ROT_Y,
        ROT_Z
    }

    public ROT_DIR rotateDir = ROT_DIR.ROT_Y;
    public bool autoRotate;
    public UnityEngine.UI.Dropdown dropdown;
    //private List<string> rotations;
    //private int curDropdownOption;
    


    public float f_lastX = 0.0f;
    public float f_difX = 0.5f;
    public float f_steps = 0.0f;
    int i_direction = 1;
    private float axis;
    private Vector3 rotDir;

    void Start()
    {
        dropdown.SetValueWithoutNotify(1);
    }
   
    // Update is called once per frame
    void Update () 
    {
        // rotate fidget
        rotateFidget();
    }
    


    // Function for rotating fidget
    private void rotateFidget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            f_difX = 0.0f;
        }
        else if (Input.GetMouseButton(0))
        {
            // Get mouse input values
            if (rotateDir == ROT_DIR.ROT_X)
            {
                rotDir = Vector3.right;
                axis = Input.GetAxis("Mouse Y");
                f_difX = Mathf.Abs(f_lastX - axis); // Rotate around x axis
            }
            else if (rotateDir == ROT_DIR.ROT_Y)
            {
                rotDir = Vector3.up;
                axis = Input.GetAxis("Mouse X");
                f_difX = Mathf.Abs(f_lastX - axis); // Rotate around y axis
            }
            else if (rotateDir == ROT_DIR.ROT_Z)
            {
                rotDir = Vector3.forward;
                axis = Input.GetAxis("Mouse X");
                f_difX = Mathf.Abs(f_lastX - axis); // Rotate around z axis
            }



            // Rotate fidget based on current mouse input stuff
            if (f_lastX < axis)
            {
                i_direction = -1;
                transform.Rotate(rotDir, -f_difX);
            }

            if (f_lastX > axis)
            {
                i_direction = 1;
                transform.Rotate(rotDir, f_difX);
            }

            f_lastX = -axis;
        }
        else
        {
            if (autoRotate)
            {
                if (f_difX > 0.5f) f_difX -= 0.05f;
                if (f_difX < 0.5f) f_difX += 0.05f;
            }
            else if (f_difX < 0.5f || f_difX > 0.5f)
            {
                if (f_difX > 0.0f) f_difX -= 0.05f;
                else if (f_difX < 0.0f) f_difX += 0.05f;
            }
            else
            {
                f_difX = 0;
            }

            transform.Rotate(rotDir, f_difX * i_direction);
        }
    }


    // -------------------------------------------------
    // UI elements

    // sets autorotate
    public void setAutorotate(bool toggle)
    {
        autoRotate = toggle;
    }

    // Updates dropdown lsit
    public void updateDropdown(int value)
    {
        /*
        // If the dropdown option has changed
        if (curDropdownOption != (int)rotateDir)
        {
            // set dropdown
            curDropdownOption = dropdown.value;
            if (curDropdownOption == 0) rotateDir = ROT_DIR.ROT_X;
            else if (curDropdownOption == 1) rotateDir = ROT_DIR.ROT_Y;
            else if (curDropdownOption == 2) rotateDir = ROT_DIR.ROT_Z;
        }
        */

        Debug.Log("dropdown value changed");
        if (value == 0) rotateDir = ROT_DIR.ROT_X;
        else if (value == 1) rotateDir = ROT_DIR.ROT_Y;
        else if (value == 2) rotateDir = ROT_DIR.ROT_Z;
    }
}
