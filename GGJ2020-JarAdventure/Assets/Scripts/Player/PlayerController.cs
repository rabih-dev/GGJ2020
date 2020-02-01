using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float horizontalRotation;

	private float verticalRotation;

	[Header("Bounding")]
	[SerializeField] private float verticalRotationBound;


	[Header("Movement")]
	public float maxSpeed;
	[HideInInspector] public float curSpeed;

	[SerializeField] private float jumpStrength;

	private Vector3 playerMovement;

	private Rigidbody rb;

	[Header("Interaction")]
	[HideInInspector] public bool talking;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.Locked;
		curSpeed = maxSpeed;
	}

	// Update is called once per frame
	void Update()
	{
		GettingInputs();
		CamRotating();
	}

	private void FixedUpdate()
	{
		Movement();
	}


	void CamRotating()
	{
		verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationBound, verticalRotationBound);

		transform.Rotate(0, horizontalRotation, 0);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
	}

	void GettingInputs()
	{
		//Mouse
		horizontalRotation = Input.GetAxis("Mouse X");
		verticalRotation -= Input.GetAxis("Mouse Y");

		//Movement
		if (!talking)
		{
			playerMovement = (Camera.main.transform.right * Input.GetAxis("Horizontal") *curSpeed  + Camera.main.transform.forward * Input.GetAxis("Vertical") *curSpeed);
			playerMovement.y = rb.velocity.y;

			//Jump
			/*if (cc.isGrounded && Input.GetButton("Jump"))
			{

				playerMovement.y += jumpStrength;
			}*/
		}
		//se começar a conversar ele para
		else
        {
			playerMovement = new Vector3(0,0,0);
        }
	}

	void Movement()
	{
	//moving around 
	rb.velocity = playerMovement;

	}

	
}
