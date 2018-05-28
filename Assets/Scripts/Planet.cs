using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

    public Transform bird;
    private float gravitationalForce = 5;
    private Vector3 directionOfBirdFromPlanet;

    void Start()
    {
        directionOfBirdFromPlanet = Vector3.zero;
    }

    void FixedUpdate()
    {
        directionOfBirdFromPlanet = (transform.position - bird.position).normalized;
        GetComponent<Rigidbody2D>().AddForce(directionOfBirdFromPlanet * gravitationalForce);
    }
}
