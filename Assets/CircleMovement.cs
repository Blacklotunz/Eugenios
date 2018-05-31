using UnityEngine;
using System.Collections;

public class CircleMovement : MonoBehaviour
{

    public float time;
    float angle = 0;
    float speed; //2*PI in degress is 360, so you get 5 seconds to complete a circle
    float radius;
    Vector3 scale;

    // Use this for initialization
    void Start()
    {
        speed = (2 * Mathf.PI) / time;
    }

    void Update()
    {
        if (radius != 0f)
        {
            angle += Time.deltaTime * speed; //if you want to switch direction, use -= instead of +=
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            transform.position = new Vector3(x, y);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.name == "Planet")
        {
            float xp2 = collider.transform.position.x;
            float yp2 = collider.transform.position.y;
            float xp1 = transform.position.x;
            float yp1 = transform.position.y;
            //??
            angle = Mathf.Atan2(yp1 - yp2, xp1 - xp2);
            scale = collider.gameObject.transform.localScale;
            CircleCollider2D Ccollider = collider.GetComponent<CircleCollider2D>();
            radius = ((CircleCollider2D)collider).radius * scale.x;
        }
    }
}
