using UnityEngine;

public class SmoothMovementNoDeltaTime : MonoBehaviour {
	private Vector3 movement = new Vector3(0.042f, 0, 0);
	// Update is called once per frame
	void Update() {
		transform.localPosition = transform.localPosition + movement;
		transform.Rotate(new Vector3(0,0.3f, 0));
	}
}
