using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStick : MonoBehaviour
{
    public LayerMask touchInpMask;
    public GameObject player;
    public GameObject projectile;
    public GameObject visualStick;
    private Vector2 prevPoint;
    private float fireTimer = 1f;

    public Vector3 ogPos;
    public Vector3 offsetPos = new Vector3(0, -3, 10);
    public bool joystickInUse = false;
    private RaycastHit hit;

    private void Update()
    {

        if (!joystickInUse)
        {

            transform.position = Camera.main.transform.position + offsetPos;

        }
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
        visualStick.transform.position = ogPos;
        joystickInUse = false;

    }
    void OnTouchStay(Vector3 point)
    {
        if (fireTimer < 0)
        {
            Vector2 offset = (point - ogPos) * 1000;
            Vector2 dir = Vector2.ClampMagnitude(offset, 1.0f);
            GameObject temp = Instantiate(projectile, player.transform.position, Quaternion.identity, player.transform) as GameObject;
            temp.GetComponent<Projectile>().dir = dir;
            fireTimer = 1f;

        }
        joystickInUse = true;
        GetComponent<SphereCollider>().transform.position = new Vector3(point.x, point.y, 0);

        Vector3 offset1 = (point - ogPos);
        Vector3 dir1 = Vector2.ClampMagnitude(offset1, 1.0f);
        visualStick.transform.position = player.transform.position + (new Vector3(offsetPos.x, offsetPos.y, 0) + dir1);
        ogPos = player.transform.position + offsetPos;

    }
    void OnTouchExit(Vector3 point)
    {
        joystickInUse = false;
        transform.position = Camera.main.transform.position + offsetPos;
        ogPos = transform.position;
        visualStick.transform.position = ogPos;
        joystickInUse = false;


    }
}
