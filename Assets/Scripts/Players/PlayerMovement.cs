using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    private Vector2 _moveDirection = Vector2.zero;
    private Rigidbody2D _rigidbody2D;

    private float _velocityMagnitude;
    private Vector3 _lastPostion;

    private Animator _animator;

    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        HandleInput();
        HandleRotation();
        HandleAnimation();
    }


    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleInput()
    {
        _moveDirection = InputManager.Instance.Move;
    }

    private void HandleRotation()
    {
        var screenSpaceMousePosition = Camera.main.ScreenToWorldPoint(InputManager.Instance.MousePosition);
        _spriteRenderer.flipX = transform.position.x < screenSpaceMousePosition.x;
    }

    private void HandleMovement()
    {
        _velocityMagnitude = (transform.position - _lastPostion).magnitude;

        var newPos = _rigidbody2D.position + _moveDirection * _moveSpeed * Time.fixedDeltaTime;
        _rigidbody2D.MovePosition(newPos);

        _lastPostion = transform.position;
    }

    private void HandleAnimation()
    {
        if (_velocityMagnitude < 0.01f)
        {
            _animator.Play("idle");
        }
        else
        {
            _animator.Play("walk");
        }
    }



}
