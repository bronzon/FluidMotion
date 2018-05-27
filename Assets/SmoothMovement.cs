using UnityEngine;

public class SmoothMovement : MonoBehaviour {
	private Vector3 movement = new Vector3(6f, 0, 0);
	
	void Update() {
		transform.localPosition = transform.localPosition + movement * Time.deltaTime;
		transform.Rotate(new Vector3(0, 50f*Time.deltaTime, 0));
	}
}
