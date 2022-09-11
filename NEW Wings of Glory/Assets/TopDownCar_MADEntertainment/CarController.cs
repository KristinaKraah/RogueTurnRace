using UnityEngine;
using System.Collections;

public enum controlMode
{
	KeyBoard,Touch
}

public class CarController : MonoBehaviour 
{

	public controlMode CarControlMode;

	public float MaxSpeed = 7.0f;
	public float MaxSteer = 2.0f;
	public float Breaks = 0.2f;
	public float MaxAcceleration = 1f;
	public float TurnSpeed = 0.01f;

    [SerializeField]
    public float Acceleration = 0.0f;
	public float Steer = 0.0f;

    bool AccelFwd, AccelBwd;
	bool TouchAccel,TouchBack,TouchBreaks;
	bool SteerLeft, SteerRight;

	Upgrades upgrades;

	void Awake()
	{
		upgrades = GetComponent<Upgrades>();
	}

	void Start () 
	{
		Acceleration = 0.6f;
	}

	void FixedUpdate () 
	{
		MaxSpeed = GameObject.FindObjectOfType<Upgrades>().speedChange;
		TurnSpeed = GameObject.FindObjectOfType<Upgrades>().turnSpeedChange;
		MaxAcceleration = GameObject.FindObjectOfType<Upgrades>().accelerationChange;

		if (CarControlMode == controlMode.KeyBoard) 
		{
			if (Input.GetKey (KeyCode.UpArrow))
				Accel (1);													//Accelerate in forward direction
			else if (Input.GetKey (KeyCode.DownArrow))
				Accel (-1);													//Accelerate in backward direction
			else if (Input.GetKey (KeyCode.Space)) 
			{
				if (AccelFwd)
					StopAccel (1, Breaks);									//Breaks while in forward direction
				else if (AccelBwd)
					StopAccel (-1, Breaks);									//Breaks while in backward direction
			} 
			else 
			{
				if (AccelFwd)
					StopAccel (1, 0.1f);									//Applies breaks slowly if no key is pressed while in forward direction
				else if (AccelBwd)
					StopAccel (-1, 0.1f);									//Applies breaks slowly if no key is pressed while in backward direction
			}
		}

		if (CarControlMode == controlMode.Touch) 
		{
			if (TouchAccel)
				Accel (1);
			else if(TouchBack)
				Accel (-1);
			else if(TouchBreaks)
			{
				if (AccelFwd)
					StopAccel (1, Breaks);
				else if (AccelBwd)
					StopAccel (-1, Breaks);	
			}
			else
			{
				if (AccelFwd)
					StopAccel (1, 0.1f);
				else if (AccelBwd)
					StopAccel (-1, 0.1f);
			}
		}
	}

	// Functions to be called from Onscreen buttons for touch input.
	public void SetTouchAccel(bool TouchState)
	{
		TouchAccel = TouchState;
	}

	public void SetTouchBack(bool TouchState)
	{
		TouchBack = TouchState;
	}

	public void SetTouchBreaks(bool TouchState)
	{
		TouchBreaks = TouchState;
	}

	public void SetSteerLeft(bool TouchState)
	{
		SteerLeft = TouchState;
	}

	public void SetSteerRight(bool TouchState)
	{
		SteerRight = TouchState;
	}

	public void Accel(int Direction)
	{
		if (Direction == 1) 
		{
			AccelFwd = true;
			if (Acceleration <= MaxSpeed) 
			{
				Acceleration += MaxAcceleration;
			}

			if(CarControlMode == controlMode.KeyBoard)
			{
				if (Input.GetKey (KeyCode.LeftArrow))
					transform.Rotate (Vector3.forward * Steer);				//Steer left
				if (Input.GetKey (KeyCode.RightArrow))
					transform.Rotate (Vector3.back * Steer);				//steer right
			}
			else if(CarControlMode == controlMode.Touch)
			{
				if(SteerLeft)
					transform.Rotate (Vector3.forward * Steer);
				else if(SteerRight)
					transform.Rotate (Vector3.back * Steer);
			}
		} 
		else if (Direction == -1) 
		{
			AccelBwd = true;
			if ((-1 * MaxSpeed) <= Acceleration) 
			{
				Acceleration -= MaxAcceleration;
			}

			if(CarControlMode == controlMode.KeyBoard)
			{
				if (Input.GetKey (KeyCode.LeftArrow))
					transform.Rotate (Vector3.back * Steer);				//Steer left (while in reverse direction)
				if (Input.GetKey (KeyCode.RightArrow))
					transform.Rotate (Vector3.forward * Steer);				//Steer left (while in reverse direction)
			}
			else if(CarControlMode == controlMode.Touch)
			{
				if(SteerLeft)
					transform.Rotate (Vector3.forward * Steer);
				else if(SteerRight)
					transform.Rotate (Vector3.back * Steer);
			}
		}
			
		if (Steer <= MaxSteer)
			Steer += TurnSpeed;

		if(CarControlMode == controlMode.Touch)
			transform.Translate (Vector2.up * Acceleration * Time.deltaTime);
		else if(CarControlMode == controlMode.KeyBoard)
			transform.Translate (Vector2.up * Acceleration * Time.deltaTime);
	}

	public void StopAccel(int Direction, float BreakingFactor)
	{
		if (Direction == 1) 
		{
			if (Acceleration >= 0.0f) 
			{
				Acceleration -= BreakingFactor;

				if (CarControlMode == controlMode.KeyBoard) 
				{
					if (Input.GetKey (KeyCode.LeftArrow))
						transform.Rotate (Vector3.forward * Steer);
					if (Input.GetKey (KeyCode.RightArrow))
						transform.Rotate (Vector3.back * Steer);
				}
				else if(CarControlMode == controlMode.Touch)
				{
					if(SteerLeft)
						transform.Rotate (Vector3.forward * Steer);
					else if(SteerRight)
						transform.Rotate (Vector3.back * Steer);
				}
			}
			else
				AccelFwd = false;
		} 
		else if (Direction == -1) 
		{
			if(Acceleration <= 0.0f)
			{
				Acceleration += BreakingFactor;

				if (CarControlMode == controlMode.KeyBoard) 
				{
					if (Input.GetKey (KeyCode.LeftArrow))
						transform.Rotate (Vector3.back * Steer);
					if (Input.GetKey (KeyCode.RightArrow))
						transform.Rotate (Vector3.forward * Steer);
				}
				else if(CarControlMode == controlMode.Touch)
				{
					if(SteerLeft)
						transform.Rotate (Vector3.forward * Steer);
					else if(SteerRight)
						transform.Rotate (Vector3.back * Steer);
				}
			}
			else
				AccelBwd = false;
		}

		if (Steer >= 0.0f)
			Steer -= TurnSpeed;

		transform.Translate (Vector2.up * Acceleration * Time.deltaTime);
	}
}
