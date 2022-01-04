using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MobileControls : MonoBehaviour
{
    [HideInInspector]
    public Canvas canvas;
    List<SC_ClickTracker> buttons = new List<SC_ClickTracker>();
    public GameObject player;

    public static SC_MobileControls instance;

    void Awake()
    {
        //Assign this sript to static variable, so it can be accessed from other scripts. Make sure there is only one SC_MobileControls in the Scene.
        instance = this;

        canvas = GetComponent<Canvas>();
    }

    public int AddButton(SC_ClickTracker button)
    {
        buttons.Add(button);

        return buttons.Count - 1;
    }

    public Vector2 GetJoystick(string joystickName)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].buttonName == joystickName)
            {
                return buttons[i].GetInputAxis();
            }
        }

        Debug.LogError("Joystick with a name '" + joystickName + "' not found. Make sure SC_ClickTracker is assigned to the button and the name is matching.");

        return Vector2.zero;
    }

    public bool GetMobileButton(string buttonName)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].buttonName == buttonName)
            {
                return buttons[i].GetHoldStatus();
            }
        }

        Debug.LogError("Button with a name '" + buttonName + "' not found. Make sure SC_ClickTracker is assigned to the button and the name is matching.");

        return false;
    }

    public bool GetMobileButtonDown(string buttonName)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].buttonName == buttonName)
            {
                return buttons[i].GetClickedStatus();
            }
        }

        Debug.LogError("Button with a name '" + buttonName + "' not found. Make sure SC_ClickTracker is assigned to the button and the name is matching.");

        return false;
    }

    private void Update()
    {
        if (SC_MobileControls.instance.GetMobileButtonDown("JoystickLeft"))
        {
            //Mobile button has been pressed one time, equivalent to if(Input.GetKeyDown(KeyCode...))
            Debug.Log("Button pressed");
            player.transform.Translate(new Vector3(.01f, .01f));
        }

        if (SC_MobileControls.instance.GetMobileButton("JoystickLeft"))
        {
            //Mobile button is being held pressed, equivalent to if(Input.GetKey(KeyCode...))
            Debug.Log("Button pressed");
            player.transform.Translate(new Vector3(.01f, .01f));
        }

        if (SC_MobileControls.instance.GetMobileButtonDown("JoystickRight"))
        {
            //Mobile button has been pressed one time, equivalent to if(Input.GetKeyDown(KeyCode...))
            Debug.Log("Button pressed");
            //player.transform.Translate(new Vector3(.01f, .01f));
        }

        if (SC_MobileControls.instance.GetMobileButton("JoystickRight"))
        {
            //Mobile button is being held pressed, equivalent to if(Input.GetKey(KeyCode...))
            Debug.Log("Button pressed");
            GameObject temp = Instantiate(player, player.transform.position, Quaternion.identity) as GameObject;
        }

        //Get normalized direction of a on-screen Joystick
        //Could be compared to: new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) or new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"))
        Vector2 inputAxis = SC_MobileControls.instance.GetJoystick("JoystickLeft");
    }
}
