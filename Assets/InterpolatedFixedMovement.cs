using System.Collections;
using UnityEngine;

public class InterpolatedFixedMovement : MonoBehaviour {
    private Vector3 startPoint;
    private Vector3 destinationPoint = Vector3.zero;

    private Quaternion startRotation;
    private Quaternion destinationRotation = Quaternion.identity;

    private readonly Vector3 simulationMovementPerFixedUpdate = new Vector3(0.1f, 0, 0);
    private readonly Quaternion simluatedRotationPerFixedUpdate = Quaternion.AngleAxis(1f, Vector3.up);
    private bool pause = false;
    private float deltaTime = 0;

    void Awake() {
        Time.timeScale = 0.1f;
    }
    
    
    void Update() {
        deltaTime += Time.deltaTime;
        var scale = Mathf.Min(1, deltaTime / Time.fixedDeltaTime);
        transform.localPosition = Vector3.Lerp(startPoint, destinationPoint, scale);
        transform.localRotation = Quaternion.Lerp(startRotation, destinationRotation, scale);
    }

    void FixedUpdate() {
        startPoint = destinationPoint != Vector3.zero ? destinationPoint : transform.localPosition;
        startRotation = destinationRotation != Quaternion.identity ? destinationRotation : transform.localRotation;
        
        destinationPoint = startPoint + simulationMovementPerFixedUpdate;
        destinationRotation = startRotation * simluatedRotationPerFixedUpdate;
        deltaTime = 0;
    }    
}