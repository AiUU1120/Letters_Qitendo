using Spine.Unity;
using Spine.Unity.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndAnimationController : MonoBehaviour
{
	public bool EnableMove = true;
	public bool EnableRun = true;
	public bool EnableAnim = true;

	[Range(1f, 100f)]
	public float MoveSpeed = 50f;
	[Range(1f, 5f)]
	public static readonly float RunRate = 1.5f;

	[Header("限制可移动区域")]
	public float MoveEdge = 888f;
	[SerializeField]
	private float currentX;

	[Header("水平移动输入源")]
	public string HorizontalAxis = "Horizontal";

	[SerializeField]
	AnimState CurrentState, PreviousState;
	bool facingLeft;

	[SerializeField,Range(-1f, 1f)]
	float currentSpeed;

	public SkeletonGraphic skeleton;

	public AnimationReferenceAsset run, idle, walk;

    public bool stayBed = false;

    private void Update()
	{
		if (skeleton == null) return;

		float currentHorizontal = Input.GetAxisRaw(HorizontalAxis);
		if (EnableAnim)
		{
			SetMove(currentHorizontal);
		}

		if ((skeleton.Skeleton.ScaleX < 0) != facingLeft)
		{
			Turn();
		}

		if (PreviousState != CurrentState)
		{
			PlayNewStableAnimation();
		}

		PreviousState = CurrentState;
		currentX = transform.position.x;

		if(EnableMove)
		{
			Move(currentHorizontal);
		}

		
	}

	void PlayNewStableAnimation()
	{
		var newState = CurrentState;
		Spine.Animation nextAnimation;

		if (newState == AnimState.Walking)
		{
			nextAnimation = walk;
		}
		else if(newState == AnimState.Running)
		{
			nextAnimation = run;
		}
		else
		{
			nextAnimation = idle;
		}

		skeleton.AnimationState.SetAnimation(0, nextAnimation, true);
	}
	/// <summary>
	/// 转向
	/// </summary>
	void Turn()
	{
		skeleton.Skeleton.ScaleX = facingLeft ? -1f : 1f;
	}

	void SetMove(float speed)
	{
		if(currentX > -MoveEdge && currentX < MoveEdge)
		{
			currentSpeed = speed; // show the "speed" in the Inspector.
			if (speed != 0)
			{
				bool speedIsNegative = (speed < 0f);
				facingLeft = speedIsNegative; // Change facing direction whenever speed is not 0.
			}
			CurrentState = (speed == 0) ? AnimState.Idle : AnimState.Walking;								//状态检测
			if(CurrentState == AnimState.Walking && Input.GetKeyDown(KeyCode.LeftShift) && EnableRun)
			{
				CurrentState = AnimState.Running;
			}

		}
		else
		{
			CurrentState = AnimState.Idle;
		}
	}
	private void Move(float input)
	{
		if (input != 0f)
		{
			if (input < 0f)
			{
				if (currentX > -MoveEdge)
				{
					float left = -MoveSpeed * Time.deltaTime * 5;
					if (Input.GetKey(KeyCode.LeftShift) && EnableRun)
					{
						left *= RunRate;
					}
					gameObject.transform.Translate(left, 0, 0);
				}

			}
			if (input > 0f)
			{
				if (currentX < MoveEdge)
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

	public IEnumerator Auto(float targetX)
	{
		if (currentX > targetX)
		{
			SetMove(-1f);
			Move(-1f);
		}
		else
		{
			SetMove(1f);
			Move(0f);
		}
		yield return null;
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bed"))
		{
			stayBed = true;
		}
        else stayBed = false;
    }
}

enum AnimState
{
	Walking,
	Running,
	Idle,
}