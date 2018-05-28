using UnityEngine;
using System.Collections;

public class OrbitScript : MonoBehaviour {

    Rigidbody2D rb;
    public float maxSpeed = 5f;

    // Use this for initialization
    void Start () {
        rb = transform.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(500f, 0f));
	}

    // Update is called once per frame
    void Update() {
        if (rb.velocity.magnitude > maxSpeed ) {
            Debug.Log(rb.velocity.magnitude);
            rb.velocity.Set(0f,0f);
        }
    }

    void FixedUpdate()
    {
    }
}
