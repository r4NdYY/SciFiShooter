using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    private Camera _camera;

    private void Start() {
        _camera = Camera.main;
    }

    private void Update() {
        //GunToCamera();
    }

    public void GunToCamera() {
        this.transform.rotation = _camera.transform.rotation;
    }
}
