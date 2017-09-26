using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mandelbrot : MonoBehaviour {

	public Renderer rend;
	public Camera cam;
	private float xCent;
	private float yCent;
	private float zoom;
	private float iterations;
	private CameraClearFlags clearFlags;
	private int cullingMask;
	private float preTouch;

	public void Start(){
		xCent = PlayerPrefs.GetFloat ("Xcent");
		yCent = PlayerPrefs.GetFloat ("Ycent");
		zoom = PlayerPrefs.GetFloat ("Zoom");
		iterations = PlayerPrefs.GetFloat ("Iterations");
		preTouch = zoom;
		rend = GetComponent<Renderer> ();
		rend.material.SetFloat ("Xcent", xCent);
		rend.material.SetFloat ("Ycent", yCent);
		rend.material.SetFloat ("Zoom", zoom);
		rend.material.SetFloat ("Iterations", iterations);
		clearFlags = cam.clearFlags;
		cullingMask = cam.cullingMask;
		Invoke ("Freeze", 0.1f);
	}

	private void Freeze(){
		cam.clearFlags =  CameraClearFlags.Nothing;
		cam.cullingMask = 0;
	}

	public void UnFreeze(){
		cam.clearFlags = clearFlags;
		cam.cullingMask = cullingMask;
	}

	public void Back(){
		SceneManager.LoadScene ("menu");
	}

	public float zoomRate = 850f;

	bool touches = false;
	float deltaMagnitudeDiff = 0;

	void Update()
	{
		// If there are two touches on the device...
		if (Input.touchCount == 2) {
			touches = true;
			// Store both touches.
			Touch touchZero = Input.GetTouch (0);
			Touch touchOne = Input.GetTouch (1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			deltaMagnitudeDiff += (touchDeltaMag - prevTouchDeltaMag) / 1000;

			// ... change the size based on the change in distance between the touches.
			zoom = preTouch * Mathf.Pow (2.0f, deltaMagnitudeDiff);
			//	Debug.Log (zoom);
			rend.material.SetFloat ("Zoom", zoom);
			rend.material.SetFloat ("Iterations", 80.0f);
			Vector2 touchDelta = (touchZero.deltaPosition + touchOne.deltaPosition)/2;
			xCent -= touchDelta.x / (2000*zoom);
			yCent -= touchDelta.y / (2000*zoom);
			rend.material.SetFloat ("Xcent", xCent);
			rend.material.SetFloat ("Ycent", yCent);
			UnFreeze ();

		} else if (Input.touchCount == 1){
			touches = true;
			Vector2 touchDelta = Input.GetTouch (0).deltaPosition;
			xCent -= touchDelta.x / (2000*zoom);
			yCent -= touchDelta.y / (2000*zoom);
			rend.material.SetFloat ("Xcent", xCent);
			rend.material.SetFloat ("Ycent", yCent);
			rend.material.SetFloat ("Iterations", 50.0f);
			UnFreeze ();


		} else if (Input.touchCount == 0 && touches) {
			touches = false;
			rend.material.SetFloat ("Iterations", iterations);
			Invoke ("Freeze", 0.1f);
			preTouch = zoom;
			deltaMagnitudeDiff = 0;

		}
	}

}
