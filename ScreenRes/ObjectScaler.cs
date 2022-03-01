using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    public Camera mainCamera;
    public float currentAspect = .6f;


    float DEVICE_SCREEN_ASPECT;

    public Vector3 startingPos;
    public void Start()
    {
        startingPos = gameObject.transform.position;
        ScaleObjectWithScreenSize();


    }
    public void Update()
    {
        

    }
    public void ScaleObjectWithScreenSize()
    {

        float srcHeight = Screen.height;
        float srcWidth = Screen.width;

        DEVICE_SCREEN_ASPECT = srcWidth / srcHeight;

        // Apply scaling to canvas object
        if (DEVICE_SCREEN_ASPECT != currentAspect)
        {
            float fixAspect = DEVICE_SCREEN_ASPECT / currentAspect;

            if (gameObject.GetComponent<RectTransform>())
            {
                gameObject.transform.localScale = new Vector3
                  (gameObject.transform.localScale.x * fixAspect,
                   gameObject.transform.localScale.y * fixAspect,
                   1);

                gameObject.transform.position = new Vector3
                  (startingPos.x - (fixAspect * DEVICE_SCREEN_ASPECT > .5f ? 10 : 50),
                   gameObject.transform.position.y,
                   1);
            }
            else
            {
                // Apply scaling to game object
                gameObject.transform.localScale = new Vector3
                   (gameObject.transform.localScale.x * fixAspect,
                    gameObject.transform.localScale.y * fixAspect,
                    1);
                gameObject.transform.position = new Vector3
                   (gameObject.transform.position.x * (fixAspect),
                    startingPos.y,
                    1);

            }
          
        }


    }
}
