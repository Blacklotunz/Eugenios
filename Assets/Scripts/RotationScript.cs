using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {

    public float speed;
    public float minSpeed, maxSpeed;
    private Vector3 angle;
    private float oldSpeed;
	// Use this for initialization
	void Start () {
        angle = new Vector3(0, 0, speed);
        oldSpeed = speed;
    }

    // Update is called once per frame
    void Update() {
        if (speed > maxSpeed) speed = maxSpeed;
        if (speed < minSpeed) speed = minSpeed;

        if (oldSpeed != speed)
        {
            oldSpeed = speed;
            angle.z = speed;
        }

        this.transform.Rotate(angle * Time.deltaTime);
	}
}
