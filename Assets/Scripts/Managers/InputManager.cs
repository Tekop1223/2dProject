using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private Vector2 _move;

    public Vector2 Move => _move;
    private Vector2 _mousePosition;
    public Vector2 MousePosition => _mousePosition;




    void Awake()
    {
        if (Instance == null)
            Instance = this;

        if (Instance != this)
            Destroy(this);
    }

    public void OnMove(InputValue value)
    {
        // Debug.Log(value.Get<Vector2>());
        _move = value.Get<Vector2>();
    }

    public void OnMousePosition(InputValue value)
    {
        _mousePosition = value.Get<Vector2>();
    }


}
