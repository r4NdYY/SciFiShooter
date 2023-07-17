using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Camera _camera;
    private CharacterController _controller;
    public float currentSpeed;
    private float maxSpeed = 5.0f;
    private float gravity = -9.81f;
    private Vector3 lastMovement;

    void Start() {
        _camera = Camera.main;
        _controller = this.GetComponent<CharacterController>();
        SettingsStorage.SetToDefault(); //settings to default
        lastMovement = new Vector3();
    }

    void Update() {
        LookTransform();
        MoveTransform();
    }

    public void LookTransform() {
        float mouseX = InputStorage.Mouse.x * SettingsStorage.Sen * SettingsStorage.SenX;
        float mouseY = InputStorage.Mouse.y * SettingsStorage.Sen * SettingsStorage.SenY;

        transform.Rotate(0.0f, mouseX, 0.0f);

        float currentLocalAngleX = Mathf.Repeat(_camera.transform.localEulerAngles.x + 180, 360) - 180;
        float rotationX = currentLocalAngleX - mouseY;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        _camera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }

    public void MoveTransform() {
        float moveX = InputStorage.Move.x;
        float moveY = InputStorage.Move.y;

        Vector3 movement = new Vector3(moveX, 0.0f, moveY);

        movement = MovementController(movement);

        if (movement.x == 0.0f && movement.z == 0.0f) {
            movement = lastMovement * currentSpeed;
        } else {
            lastMovement = movement;
        }

        movement = Vector3.ClampMagnitude(movement, currentSpeed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _controller.Move(movement);
    }

    public Vector3 MovementController(Vector3 movement) {
        float minValue = -1.0f;
        float maxValue = 1.0f;
        float minFactor = 0.6f;
        float maxFactor = 1.0f;
        float speedFactor;

        speedFactor = Mathf.InverseLerp(minValue, maxValue, movement.z);
        speedFactor = Mathf.Lerp(minFactor, maxFactor, speedFactor);

        if (InputStorage.Sprint && movement.z > 0.0f) {
            maxSpeed = 10.0f;
        }
        else {
            maxSpeed = 7.0f;
        }

        if (movement.x != 0.0f || movement.z != 0.0f) {
            currentSpeed += 10.0f * Time.deltaTime;
        } else {
            currentSpeed -= 25.0f * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0.0f, maxSpeed);

        return movement * currentSpeed * speedFactor;
    }
}
