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
    private float latestFixed;

    void Awake() {
        Time.timeScale = 1f;
    }
    
    
    void Update() {
        var scale = Mathf.Min(1, (Time.time - latestFixed) / Time.fixedDeltaTime);
        transform.localPosition = Vector3.Lerp(startPoint, destinationPoint, scale);
    }

    void FixedUpdate() {
        latestFixed = Time.time;
        startPoint = destinationPoint != Vector3.zero ? destinationPoint : transform.localPosition;
        startRotation = destinationRotation != Quaternion.identity ? destinationRotation : transform.localRotation;
        
        destinationPoint = startPoint + simulationMovementPerFixedUpdate;
        destinationRotation = startRotation * simluatedRotationPerFixedUpdate;
        //Debug.Log("FixedUpdate");
    }    
}