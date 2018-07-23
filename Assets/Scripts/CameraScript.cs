using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject world;
    public float maxSize, minSize, lerpFactor, t;
    public bool zoomIn;

    // Use this for initialization
    void Start () {
        t = 0;
        zoomIn = true;
    }

    void FixedUpdate () {
        float worldSpeed = Mathf.Abs(world.GetComponent<RotationScript>().speed);
        float cameraSize = this.GetComponent<Camera>().orthographicSize;

        if (worldSpeed < 3)
        {
            t -= worldSpeed / lerpFactor;
            worldSpeed = 0;
        }
        else
        {
            t += worldSpeed / (lerpFactor * 30);
        }
           
        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t >= 1f)
        {
            t = 1f;
        }
        if(t <= 0f)
        {
            t = 0f;
        }

        cameraSize = Mathf.Lerp(minSize, maxSize, t);
        this.GetComponent<Camera>().orthographicSize = cameraSize;
    }
}
