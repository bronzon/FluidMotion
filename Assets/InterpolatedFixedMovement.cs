using System.Collections;
using UnityEngine;

public class InterpolatedFixedMovement : MonoBehaviour {
    private Vector3 startPoint;
    private Vector3 destinationPoint = Vector3.zero;

    private Quaternion startRotation;
    private Quaternion destinationRotation = Quaternion.identity;

    private readonly Vector3 simulationMovementPerFixedUpdate = new Vector3(0.1f, 0, 0);
    private readonly Quaternion simluatedRotationPerFixedUpdate = Quaternion.AngleAxis(1f, Vector3.up);
    private bool pause = true;

    void Start() {
        StartCoroutine(UnPause());
    }

    private IEnumerator UnPause() {
        yield return new WaitForSeconds(3);
        pause = false;
    }

    void Update() {
        if (pause) {
            return;
        }
        
        transform.localPosition = Vector3.Lerp(startPoint, destinationPoint, InterpolationManager.InterpolationFactor);
        transform.localRotation = Quaternion.Lerp(startRotation, destinationRotation, InterpolationManager.InterpolationFactor);
        //Debug.Log("current: " + transform.localPosition.x + " " + Time.frameCount);
    }

    void FixedUpdate() {
        if (pause) {
            return;
        }
        
        startPoint = destinationPoint != Vector3.zero ? destinationPoint : transform.localPosition;
        startRotation = destinationRotation != Quaternion.identity ? destinationRotation : transform.localRotation;
        
        destinationPoint = startPoint + simulationMovementPerFixedUpdate;
        destinationRotation = startRotation * simluatedRotationPerFixedUpdate;
       // Debug.Log("from " + startPoint.x + " to " + destinationPoint.x + " " + Time.frameCount);
    }    
}