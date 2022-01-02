using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action<Vector2> moveInput;
    static FloatingJoystick _joystick;
    private void Awake()
    {
        _joystick = GameObject.FindObjectOfType<FloatingJoystick>();
    }

    private void Update()
    {
        if (_joystick.Direction.magnitude > 0)
        {
            moveInput?.Invoke(_joystick.Direction);
        }
    }
}
