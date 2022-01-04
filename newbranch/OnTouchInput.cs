using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchInput : MonoBehaviour
{
    public GameObject leftJoystick;
    public GameObject rightJoystick;
    public SC_ClickTracker scTracker;

    public bool leftSide = false;


    private void Start()
    {

    }
    private void Update()
    {

    }

    public void OnTouchDown(Vector3 point)
    {
       

        Debug.Log("touched");
        if (leftSide)
        {
            leftJoystick.transform.position = Camera.main.WorldToScreenPoint(point);
        }
        else
        {
            rightJoystick.transform.position = Camera.main.WorldToScreenPoint(point);
        }

        scTracker.startPos = scTracker.gameObject.transform.localPosition;
        scTracker.clickPos = Camera.main.WorldToScreenPoint(point);
    }

    public void OnTouchUp(Vector3 point)
    {
        if (leftSide)
        {
            leftJoystick.transform.position = new Vector3(-150, -300, 0);
            scTracker.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            rightJoystick.transform.position = new Vector3(150, -300, 0);
            scTracker.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    public void OnTouchStay(Vector3 point)
    {
        scTracker.UpdateJoystickPositionManually(Camera.main.WorldToScreenPoint(point));
    }

    public void OnTouchExit(Vector3 point)
    {
        if (leftSide)
        {
            leftJoystick.transform.position = new Vector3(-150, -300, 0);
            scTracker.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            rightJoystick.transform.position = new Vector3(150, -300, 0);
            scTracker.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

}
