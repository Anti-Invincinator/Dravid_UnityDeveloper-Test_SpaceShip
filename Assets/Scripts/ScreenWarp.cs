using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class warps the GameObject around the screen if it goes out of the viewport
/// 
/// !!~~~~~~~~~~~~~~~~Warning Make sure you are exclusively in the GameView to test this, because it will take the Scene View's Viewport into consideration OtherWise.
/// </summary>
public class ScreenWarp : MonoBehaviour
{
    Renderer spriteRenderer;

    bool isWrappingX = false;
    bool isWrappingY = false;

    void Start()
    {
        spriteRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        ScreenWarping();
    }

    /// <summary>
    /// This function checks whether the Gameobject is in the viewport.
    /// </summary>
    /// <returns>
    /// It returns a boolean with accordance to the aforementioned condition
    /// </returns>
    private bool CheckRenderers()
    {
        //If the GameObject is Visible Return True
       if (spriteRenderer.isVisible)
        return true;

        //Otherwise return false
        return false;
    }

    void ScreenWarping()
    {
        var isVisible = CheckRenderers();

        if (isVisible)
        {
            isWrappingX = false;
            isWrappingY = false;
            return;        
        }

        //This check is done to prevent continuous warping around the screen
        if(isWrappingX && isWrappingY)
        {
            return;
        }

        var cam = Camera.main;
        var viewportPosition = cam.WorldToViewportPoint(transform.position);
        var newPosition = transform.position;

        if(!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            newPosition.x = -newPosition.x;

            isWrappingX = true;
        }

        if(!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            newPosition.y = -newPosition.y;

            isWrappingY = true;
        }

        transform.position = newPosition;
    }    
}
