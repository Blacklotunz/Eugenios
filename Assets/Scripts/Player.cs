using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Transform planet;
    private float forceAmountForRotation = 10;
    private Vector3 directionOfPlanetFromBird;
    private bool allowForce;

    void Start()
    {
        directionOfPlanetFromBird = Vector3.zero;
    }

    void Update()
    {

        allowForce = false;

        if (Input.GetKey(KeyCode.Space))
            allowForce = true;

        directionOfPlanetFromBird = transform.position - planet.position;
        transform.right = Vector3.Cross(directionOfPlanetFromBird, Vector3.forward);
    }

    void FixedUpdate()
    {
        if (allowForce)
            GetComponent<Rigidbody2D>().AddForce(transform.right * forceAmountForRotation);
    }
}
