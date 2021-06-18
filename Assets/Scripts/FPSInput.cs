using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    private float moveSpeed;
    public float baseSpeed = 6f;

    public float gravity = -9.81f;

    private CharacterController characterController;

	private void Awake()
	{
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	void Start()
    {
        moveSpeed = baseSpeed;
        characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaZ = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, moveSpeed);
        
        //movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        movement.y = gravity;

        characterController.Move(movement);
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
