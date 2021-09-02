using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float velocidade;

    [SerializeField] private PlayerInput playerInput;
    
    private GameInput _gameInput;

    private Vector2 _movimento;

    private Rigidbody2D _rigidbody2D;
    private void OnEnable()
    {
        playerInput.onActionTriggered += OnActionTriggered;
    }

    private void OnDisable()
    {
        playerInput.onActionTriggered -= OnActionTriggered;
    }

    // Start is called before the first frame update
    void Start()
    {
        _gameInput = new GameInput();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _rigidbody2D.AddForce(_movimento * velocidade);
    }
    
    private void OnActionTriggered(InputAction.CallbackContext obj)
    {
        if (obj.action.name == _gameInput.Gameplay.Move.name)
        {
            _movimento = obj.ReadValue<Vector2>();
        }
    }
}
