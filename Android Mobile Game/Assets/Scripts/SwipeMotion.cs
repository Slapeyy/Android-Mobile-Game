using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMotion : MonoBehaviour
{
    private bool dragging = false;
    private bool swipeL, swipeR, swipeUp, swipeD;
    private Vector2 start, deltaSwipe;

    private void Update()
    {
        swipeL = false;
        swipeR = false;
        swipeUp = false;
        swipeD = false;

        #region Standalone Inputs
        if(Input.GetMouseButtonDown(0))
        {
            dragging = true;
            start = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                dragging = true;
                start = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                dragging = false;
                Reset();
            }
        }
        #endregion

        //calculate distance
        deltaSwipe = Vector2.zero;
        if (dragging)
        {
            if (Input.touches.Length > 0)
                deltaSwipe = Input.touches[0].position - start;
            else if (Input.GetMouseButton(0))
                deltaSwipe = (Vector2)Input.mousePosition - start;
        }

        if (deltaSwipe.magnitude > 75)
        {
            //Direction
            float x = deltaSwipe.x;
            float y = deltaSwipe.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                    swipeL = true;
                else
                    swipeR = true;
            }
            else 
            {
                //Up or Down                
                if (y < 0)
                    swipeD = true;
                else
                    swipeUp = true;
            }

            Reset();
        }
    }

    private void Reset()
    {
        start = deltaSwipe = Vector2.zero;
        dragging = false;
    }

    public Vector2 DeltaSwipe { get => deltaSwipe; set => deltaSwipe = value; }
    public bool SwipeL { get => swipeL; set => swipeL = value; }
    public bool SwipeR { get => swipeR; set => swipeR = value; }
    public bool SwipeUp { get => swipeUp; set => swipeUp = value; }
    public bool SwipeD { get => swipeD; set => swipeD = value; }
}
