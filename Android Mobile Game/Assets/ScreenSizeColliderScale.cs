using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeColliderScale : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector2 screenScale = new Vector2(Screen.width, Screen.height).normalized;
        transform.localScale = new Vector3(screenScale.x, screenScale.y, 1);
    }
}
