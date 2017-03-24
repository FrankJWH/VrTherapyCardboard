using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCamScript : MonoBehaviour {

	float zAxis = 0F;

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

			transform.eulerAngles = new Vector3 (0, 0, zAxis);

		} else {
		}
	}
}
