using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour
{
	
	//The target of the camera. The camera will always point to this object.
	public Transform _target;
	
	//The default distance of the camera from the target.
	public float _distance = 10.0f;
	
	//Control the speed of zooming and dezooming.
	public float _zoomStep = 0.1f;
	
	//The speed of the camera. Control how fast the camera will rotate.
	public float _xSpeed = 1f;
	public float _ySpeed = 1f;
	
	//The position of the cursor on the screen. Used to rotate the camera.
	private float _x = 0.0f;
	private float _y = 0.0f;
	
	//Distance vector.
	private Vector3 _distanceVector;
	/**
  * Move the camera to its initial position.
  */
	void Start ()
	{
		_distanceVector = new Vector3(0.0f,0.0f,_distance);
		
		
		Vector2 angles = this.transform.localEulerAngles;
		_x = angles.x;
		_y = angles.y;
		
		this.Rotate(_x, _y);
		
		
	}
	
	/**
  * Rotate the camera or zoom depending on the input of the player.
  */
	void LateUpdate()
	{
		if ( _target )
		{
			this.RotateControls();
			this.Zoom();
		}
	}
	
	/**
  * Rotate the camera when the first button of the mouse is pressed.
  *
  */
	void RotateControls()
	{
		if ( Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved )
		{
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			_x += Input.GetTouch(0).deltaPosition.x * _xSpeed;
			_y += -Input.GetTouch(0).deltaPosition.y * _ySpeed;
			this.Rotate(_x,_y);
		}
		
	}
	
	void Rotate( float x, float y )
	{
		//Transform angle in degree in quaternion form used by Unity for rotation.
		Quaternion rotation = Quaternion.Euler(y,x,0.0f);
		
		//The new position is the target position + the distance vector of the camera
		//rotated at the specified angle.
		Vector3 position = rotation * _distanceVector + _target.position;
		
		//Update the rotation and position of the camera.
		transform.rotation = rotation;
		transform.position = position;
	}
	
	/**
  * Zoom or dezoom depending on the input of the mouse wheel.
  */
	void Zoom()
	{
		if (Input.touchCount == 2 && Input.GetTouch (0).phase == TouchPhase.Moved && Input.GetTouch (1).phase == TouchPhase.Moved)
		{
			Vector2 curDist = Input.GetTouch(0).position - Input.GetTouch(1).position;
			Vector2 prevDist = ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition));
			float touchDelta = curDist.magnitude - prevDist.magnitude;
			
			
			if (curDist.magnitude < prevDist.magnitude) {
				this.ZoomOut ();
				if(_distance > 100.0f)
				{
					_distance = 100.0f;
				}
			}else if (curDist.magnitude > prevDist.magnitude) {
				this.ZoomIn ();
				if(_distance < 5.0f)
				{
					_distance = 5.0f;
				}
			}
		}
		
	}
	
	/**
  * Reduce the distance from the camera to the target and
  * update the position of the camera (with the Rotate function).
  */
	void ZoomIn()
	{
		_distance -= _zoomStep;
		_distanceVector = new Vector3(0.0f,0.0f,-_distance);
		this.Rotate(_x,_y);
	}
	
	/**
  * Increase the distance from the camera to the target and
  * update the position of the camera (with the Rotate function).
  */
	void ZoomOut()
	{
		_distance += _zoomStep;
		_distanceVector = new Vector3(0.0f,0.0f,-_distance);
		this.Rotate(_x,_y);
	}
	
	void Update()
	{
		transform.LookAt (_target.transform);
	}
	
} //End class