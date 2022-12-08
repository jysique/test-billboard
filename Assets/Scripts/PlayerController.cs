using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player reference")]
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private Transform viewCam;
    [SerializeField] private TestCameraDirection direction;

    [Header("Player variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float mouseSensitivity;

    [Header("Player debug")]
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private Vector2 mouseInput;

    bool moveCamera = true;

    private void Awake()
    {
        direction = GetComponent<TestCameraDirection>();
    }

    private void Update()
    {
        if(moveCamera)
            PlayerViewControl();

        if (Input.GetKeyDown(KeyCode.Space)){
            moveCamera = !moveCamera;
        }
    }
    private void LateUpdate()
    {
        PlayerMovement();
    }
    private void PlayerViewControl()
    {
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        //Rotation in X
        float rotX = transform.rotation.eulerAngles.z - mouseInput.x;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotX);

        //Rotation in Y
        float rotY = viewCam.localRotation.eulerAngles.y + mouseInput.y;
        rotY = Mathf.Clamp(rotY, 70 , 100);
        viewCam.localRotation = Quaternion.Euler(new Vector3(viewCam.localEulerAngles.x, rotY, viewCam.localEulerAngles.z));
    }
    private void PlayerMovement()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveHorizontal = transform.up * -moveInput.x;
        Vector3 moveVertical = transform.right * moveInput.y;
        rigidbody2d.velocity = (moveHorizontal + moveVertical) * moveSpeed;
    }
    public TestCameraDirection TestCameraDirection { get { return direction; } }
}
