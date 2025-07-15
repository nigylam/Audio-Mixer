using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public static event Action SubmitButtonDown;
    public static event Action SubmitButtonUp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            SubmitButtonDown?.Invoke();

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return))
            SubmitButtonUp?.Invoke();
    }
}
