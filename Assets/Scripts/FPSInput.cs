using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{
    private CharacterController cc;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    private Vector3 velocity;
    private float moveSpeed;
    bool isGrounded;

    [SerializeField] float baseSpeed = 6f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3f;

    [SerializeField] GameObject gun;
    [SerializeField] Transform normalGunPosition;
    [SerializeField] Transform aDSGunPosition;
    bool adsOn = false;



    private void Awake()
	{
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	void Start()
    {
        gun.transform.position = normalGunPosition.position;
        moveSpeed = baseSpeed;
        cc = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        if (Physics.CheckSphere(groundCheck.position, 0.27f, groundLayer)) //Lower values causes problems with ramps
        {
            isGrounded = true;
        }
        else isGrounded = false;


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaZ = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        
        Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
        //movement = Vector3.ClampMagnitude(movement, moveSpeed);
        movement = transform.TransformDirection(movement);
        cc.Move(movement);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            
            velocity.y += Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (adsOn)
            {
                adsOn = false;
            }
            else
            {
                adsOn = true;
            }
            
        }
        if (adsOn)
        {
            gun.transform.position = aDSGunPosition.position;
        }
        else
        {
            gun.transform.position = normalGunPosition.position;
        }


        
    }

	private void OnDestroy()
	{
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}


    private void OnSpeedChanged (float value)
	{
        moveSpeed = baseSpeed * value;
	}
}
