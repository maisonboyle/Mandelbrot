using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mandelbrot : MonoBehaviour {

	private float xCent;
	private float yCent;
	private float zoom;
	private float iterations;
	private float preTouch;

	public GameObject HighRes;
	public GameObject LowRes;
	public subDisplay disp1;
	public subDisplay disp2;
	public subDisplay disp3;
	public subDisplay disp4;
	public subDisplay disp5;
	public subDisplay disp6;
	public subDisplay disp7;
	public subDisplay disp8;
	public MandelGraphics PoorQual;


	public void Start(){
		
		xCent = PlayerPrefs.GetFloat ("Xcent");
		yCent = PlayerPrefs.GetFloat ("Ycent");
		zoom = PlayerPrefs.GetFloat ("Zoom");
		iterations = PlayerPrefs.GetFloat ("Iterations");
		preTouch = zoom;
		HighQuality ();
	}
		
	public void Back(){
		SceneManager.LoadScene ("menu");
	}

	public void LowQuality(){
		PoorQual.Draw (xCent, yCent, zoom, iterations);
		HighRes.SetActive (false);
		LowRes.SetActive (true);
	}

	public void HighQuality(){
		disp1.Draw (xCent, yCent, zoom, iterations);
		disp2.Draw (xCent, yCent, zoom, iterations);
		disp3.Draw (xCent, yCent, zoom, iterations);
		disp4.Draw (xCent, yCent, zoom, iterations);
		disp5.Draw (xCent, yCent, zoom, iterations);
		disp6.Draw (xCent, yCent, zoom, iterations);
		disp7.Draw (xCent, yCent, zoom, iterations);
		disp8.Draw (xCent, yCent, zoom, iterations);
		HighRes.SetActive (true);
		LowRes.SetActive (false);
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
			deltaMagnitudeDiff += (touchDeltaMag - prevTouchDeltaMag) / 750;

			// ... change the size based on the change in distance between the touches.
			Vector2 touchDelta = (touchZero.deltaPosition + touchOne.deltaPosition)/2;
			xCent -= touchDelta.x / (2000*zoom);
			yCent -= touchDelta.y / (2000*zoom);
			zoom = preTouch * Mathf.Pow (2.0f, deltaMagnitudeDiff);

			LowQuality ();

		} else if (Input.touchCount == 1){
			touches = true;
			Vector2 touchDelta = Input.GetTouch (0).deltaPosition;
			xCent -= touchDelta.x / (2000*zoom);
			yCent -= touchDelta.y / (2000*zoom);

			LowQuality ();


		} else if (Input.touchCount == 0 && touches) {
			touches = false;
			HighQuality ();
			preTouch = zoom;
			deltaMagnitudeDiff = 0;
			PlayerPrefs.SetFloat ("Xcent",xCent);
			PlayerPrefs.SetFloat ("Ycent", yCent);
			PlayerPrefs.SetFloat ("Zoom", zoom);
		}
	}

}
