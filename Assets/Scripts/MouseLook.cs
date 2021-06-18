using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField] private Transform playerBody;
    
    public float mouseSensitivity;
    public float minVertRot = -45f;
    public float maxVertRot = 45f;

    private float xRotation = 0f;


	private void Start()
	{
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }



        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 100 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 100 * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minVertRot, maxVertRot);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}
