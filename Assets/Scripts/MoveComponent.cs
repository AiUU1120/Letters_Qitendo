using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Obsolete]
public class MoveComponent : MonoBehaviour
{
	public bool EnableMove = true;
	public bool IsNPC;

	[Range(1f, 100f)]
	public float MoveSpeed = 20f;
	public bool EnableRun = true;
	[Range(1f, 5f)]
	public const float RunRate = 1.5f;

	public float MoveEdge = 888f;

	public float currentX;
	public string HorizontalAxis = "Horizontal";

    private void Awake()
    {
		if (IsNPC)
		{
			MoveSpeed = -MoveSpeed;
		}
	}

    private void Update()
	{
		currentX = transform.position.x;
		//Debug.Log(currentX);
		

		Move();
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log("Ω”¥•µΩ¡À" + other.name);
		
        if(other.CompareTag("Player"))
        {

			MoveSpeed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
		{
			MoveSpeed = -60f;
        }
    }

    private void Move()
	{
		if (EnableMove)
		{
			float input = Input.GetAxisRaw(HorizontalAxis);
			if (input != 0f)
			{
				if (input < 0f)
				{
					if(currentX > -MoveEdge)
                    {
						float left = -MoveSpeed * Time.deltaTime * 5;
						if (Input.GetKey(KeyCode.LeftShift) && EnableRun)
						{
							left *= RunRate;
						}
						gameObject.transform.Translate(left, 0, 0);
					}
					
				}
				if (input > 0f && !IsNPC)
				{
					if(currentX < MoveEdge)
                    {
						float right = MoveSpeed * Time.deltaTime * 5;
						if (Input.GetKey(KeyCode.LeftShift) && EnableRun)
						{
							right *= RunRate;
						}
						gameObject.transform.Translate(right, 0, 0);
					}
					
				}
			}
		}
	}
	public void AutoMove(bool facingLeft)
	{
		if(facingLeft)
		{
			float left = -MoveSpeed * Time.deltaTime * 5;
			if (Input.GetKey(KeyCode.LeftShift) && EnableRun)
			{
				left *= RunRate;
			}
			gameObject.transform.Translate(left, 0, 0);
		}
		else
		{
			float right = MoveSpeed * Time.deltaTime * 5;
			if (Input.GetKey(KeyCode.LeftShift) && EnableRun)
			{
				right *= RunRate;
			}
			gameObject.transform.Translate(right, 0, 0);
		}
	}
}
