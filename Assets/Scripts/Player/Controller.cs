using System;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Action Jumped;
    public Action<bool> RunnedLeft;
    public Action<bool> RunnedRight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jumped?.Invoke();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            RunnedLeft?.Invoke(true);

        if ( Input.GetKeyDown(KeyCode.RightArrow))
            RunnedRight?.Invoke(true);

        if (Input.GetKeyUp(KeyCode.LeftArrow))
            RunnedLeft?.Invoke(false);

        if (Input.GetKeyUp(KeyCode.RightArrow))
            RunnedRight?.Invoke(false);
    }
}
