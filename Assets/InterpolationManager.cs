using System;
using UnityEngine;

public class InterpolationManager : MonoBehaviour{
    private readonly float[] lastFixedUpdateTimes = new float[2];
    private int timeIndex;

    public static float InterpolationFactor { get; private set; }

    public void Update() {
        float newerTime = lastFixedUpdateTimes[timeIndex];
        float olderTime = lastFixedUpdateTimes[OldTimeIndex()];

        if (Math.Abs(newerTime - olderTime) > Mathf.Epsilon) {
            InterpolationFactor = (Time.time - newerTime) / (newerTime - olderTime);
        }
        else {
            InterpolationFactor = 1;
        }
    }

    private int OldTimeIndex() {
        return timeIndex == 0 ? 1 : 0;
    }

    public void FixedUpdate() {
        timeIndex = OldTimeIndex();
        lastFixedUpdateTimes[timeIndex] = Time.fixedTime;
    }
}

