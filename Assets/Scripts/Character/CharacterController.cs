using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public bool EnableMoving = true;
	[Range(1f, 100f)]
    public float MoveSpeed = 20;
    public bool EnableRunning = true;
	[Range(1f,3f)]
	public float RunRate = 1.5f;
	public string horizontalAxis = "Horizontal";
	public bool EnableAnimation = true;

	public float currentX;							//获取玩家实时的X轴坐标
	[SerializeField]
	MoveAndAnimationController controler;

	

	private void Update()
    {
		controler.enabled = EnableAnimation;
		currentX = transform.position.x;            //实时获取玩家的X坐标
		Debug.Log(currentX);
		Move();

    }

    private void Move()
    {
		if (EnableMoving)
		{
			float currentHorizontal = Input.GetAxisRaw(horizontalAxis);
			if(currentHorizontal != 0)
			{
				bool IsLeft = (currentHorizontal < 0f);
				if (IsLeft)
				{
					float left = -MoveSpeed * Time.deltaTime * 10;
					if (Input.GetKey(KeyCode.LeftShift) && EnableRunning)
					{
						left *= RunRate;
					}
					gameObject.transform.Translate(left, 0, 0);
				}
				else
				{
					float right = MoveSpeed * Time.deltaTime * 10;
					if (Input.GetKey(KeyCode.LeftShift) && EnableRunning)
					{
						right *= RunRate;
					}
					gameObject.transform.Translate(right, 0, 0);
				}
			}
		}
	}


}
