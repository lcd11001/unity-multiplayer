using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform viewPoint;
    [SerializeField] private float mouseSensitivity = 1f;
    [SerializeField] private float rotationYLimit = 60f;
    private float verticalRotationStore;
    private Vector2 mouseInput;


    void Start()
    {

    }


    void Update()
    {
        float mx = Input.GetAxisRaw("Mouse X");
        float my = Input.GetAxisRaw("Mouse Y");
        mouseInput = new Vector2(mx, my) * mouseSensitivity;

        Vector3 currentPlayerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(currentPlayerRotation.x, currentPlayerRotation.y + mouseInput.x, currentPlayerRotation.z);

        Vector3 currentViewpointRotation = viewPoint.rotation.eulerAngles;
        //viewPoint.rotation = Quaternion.Euler(Mathf.Clamp(currentViewpointRotation.x - mouseInput.y, -60f, 60f), currentViewpointRotation.y, currentViewpointRotation.z);

        verticalRotationStore += mouseInput.y;
        verticalRotationStore = Mathf.Clamp(verticalRotationStore, -rotationYLimit, rotationYLimit);
        viewPoint.rotation = Quaternion.Euler(verticalRotationStore, currentViewpointRotation.y, currentViewpointRotation.z);
    }
}
