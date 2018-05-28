using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

    [Range(1f,20f)]
    public float gravityScale;
    public GameObject planet;
    private Vector2 vectorToPlanetCenter, vectorToThisCenter;
    private Vector3 planetCenter, thisObjectCenter;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        setGravity();
    }




    private void _setGravity()
    {
        planetCenter = planet.GetComponent<SpriteRenderer>().bounds.center;
        thisObjectCenter = GetComponent<SpriteRenderer>().bounds.center;
        vectorToPlanetCenter = new Vector2(planetCenter.x, -planetCenter.y);
        vectorToThisCenter = new Vector2(thisObjectCenter.x, thisObjectCenter.y);
        Physics2D.gravity = gravityScale * (vectorToPlanetCenter - vectorToThisCenter);
    }

    private void setGravity()
    {
        Vector3 line = this.transform.position - planet.transform.position;
        line.Normalize();
        //float distance = Vector3.Distance(this.transform.position, planet.transform.position);
        this.transform.GetComponent<Rigidbody2D>().AddForce(-(line * 9.8f) * gravityScale);

    }
    
}
