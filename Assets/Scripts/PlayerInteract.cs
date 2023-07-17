using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private float distance = 3.0f;
    [SerializeField] private LayerMask mask;
    private PlayerUI playerUI;
     

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance)) {
            if (hitInfo.collider.GetComponent<Interactable>() != null) {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (InputStorage.Interact) {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
