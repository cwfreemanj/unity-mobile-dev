using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStick : MonoBehaviour
{
    public LayerMask touchInpMask;
    public GameObject player;
    public GameObject projectile;
    public GameObject visualStick;
    public GameObject gunStick;
    public GameObject visualGunStick;
    private Vector3 prevPoint;
    private float fireTimer = 1f;

    public Vector3 ogPos;
    public Vector3 offsetPos = new Vector3(0, -3, 10);
    public bool joystickInUse = true;
    private RaycastHit hit;

    private void Update()
    {

        
        fireTimer -= Time.deltaTime;
    }
    private void Start()
    {
        ogPos = transform.position;
    }

    void OnTouchDown(Vector3 point)
    {
        prevPoint = point;
        joystickInUse = true;
    }
    void OnTouchUp(Vector3 point)
    {

        transform.position = Camera.main.transform.position + offsetPos;
        ogPos = transform.position;
        joystickInUse = false;
        visualStick.transform.position = ogPos;


    }
    void OnTouchStay(Vector3 point)
    {
       
        Vector3 offset = (point - ogPos);
        Vector3 dir = Vector2.ClampMagnitude(offset, 1.0f);
        player.transform.Translate(dir);
        joystickInUse = true;

       
        GetComponent<SphereCollider>().transform.position = new Vector3(point.x, point.y, 0) + dir;

            Debug.Log(prevPoint.x - point.x + " | " + (prevPoint.y - point.y));
            Vector3 offset1 = (point - ogPos);
            Vector3 dir1 = Vector2.ClampMagnitude(offset1, 1.0f);
            visualStick.transform.position = player.transform.position + (new Vector3(offsetPos.x, offsetPos.y, 0) + dir1);     

        prevPoint = point;
        ogPos = player.transform.position + offsetPos;

    }
    void OnTouchExit(Vector3 point)
    {

        transform.position = Camera.main.transform.position + offsetPos;
        ogPos = transform.position;
        visualStick.transform.position = ogPos;
        joystickInUse = false;


    }
}
