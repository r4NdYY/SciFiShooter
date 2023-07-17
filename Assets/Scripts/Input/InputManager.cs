using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput _input;
    private Vector2 _mouse;
    private Vector2 _move;
    private bool _sprint;
    private bool _interact;

    private void Awake() {
        _input = new PlayerInput();
    }

    private void OnEnable() {
        _input.Enable();
    }

    // Update is called once per frame
    void Update() {
        _mouse = _input.Player.Looking.ReadValue<Vector2>();
        _move = _input.Player.Move.ReadValue<Vector2>();
        _sprint = _input.Player.Action.IsPressed();
        _interact = _input.Player.Interact.triggered ? true : false;

        UpdateStorage();
    }

    void UpdateStorage() {
        InputStorage.Move = _move;
        InputStorage.Mouse = _mouse;
        InputStorage.Sprint = _sprint;
        InputStorage.Interact = _interact;
    }

    void OnDisable() {
        _input.Disable();
    }
}
