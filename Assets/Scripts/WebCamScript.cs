using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamScript : MonoBehaviour {

	float zAxis;
	public GameObject slider;
	public Slider sliderVal;

	IEnumerator Start() {

		yield return Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);

		if (Application.HasUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone)) {

			float height = Camera.main.orthographicSize * 2.0F;
			float width = height * Screen.width / Screen.height;
			transform.localScale = new Vector3(width, height, 1F);

			WebCamTexture webcamTexture = new WebCamTexture();
			Renderer renderer = GetComponent<Renderer>();
			renderer.material.mainTexture = webcamTexture;
			webcamTexture.Play();

			transform.eulerAngles = new Vector3 (0, 0, 0);

			//slider = GetComponent<GameObject>();
			//sliderVal = slider.GetComponent<Slider> ();


		} else {
		}
	}

	void Update() {

		zAxis = float.Parse(sliderVal.value.ToString());
		transform.eulerAngles = new Vector3 (0, 0, zAxis);
	}
}
