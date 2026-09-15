using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public Transform camTransform;
    [SerializeField] private float mouseSens = 300f, moveSpeed = 5f, vRotation;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        camTransform = GetComponentInChildren<Camera>().transform;
    }
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSens;
        float kbH = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        float kbV = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;
        vRotation -= mouseY;
        vRotation = Mathf.Clamp(vRotation, -90, 90);
        transform.Rotate(0, mouseX, 0);
        transform.Translate(kbH, 0, kbV);
        camTransform.localEulerAngles = new Vector3(vRotation, 0, 0);
    }
}
