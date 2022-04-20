using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	private Vector3 moveVec;
	
	public void OnJump()
	{
		Debug.Log("OnJump!");
		jump = true;
		animator.SetBool("IsJumping", true);
	}

	public void OnMove(InputValue input)
	{
		Vector2 inputVec = input.Get<Vector2>();

		moveVec = new Vector3(inputVec.x, 0, inputVec.y);
		horizontalMove = moveVec.x * runSpeed;
	}

	// Update is called once per frame
	void Update () {

		// horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		// if (Input.GetButtonDown("Jump"))
		// {
		// 	jump = true;
		// 	animator.SetBool("IsJumping", true);
		// }
		//
		// if (Input.GetButtonDown("Crouch"))
		// {
		// 	crouch = true;
		// } else if (Input.GetButtonUp("Crouch"))
		// {
		// 	crouch = false;
		// }

	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
		jump = false;
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
	}
}
