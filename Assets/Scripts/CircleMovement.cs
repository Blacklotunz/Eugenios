using UnityEngine;
using System.Collections;

public class CircleMovement : MonoBehaviour
{

    public float time;
    float angle;
    float speed; //2*PI in degress is 360, so you get 5 seconds to complete a circle
    float radius, t, originalRadius, maximum, minimum;
    bool clockwise;
    Collider2D collider;
    Vector3 scale;

    // Use this for initialization
    void Start()
    {
        speed = (2 * Mathf.PI) / time;
        t = 0f;
        angle = 0;
    }

    void Update()
    {
        if (radius != 0f && !this.GetComponent<FollowScript>().catched)
        {
           
            radius += Mathf.Lerp(minimum, maximum, t);
            // .. and increate the t interpolater
            t += 0.5f * Time.deltaTime;
            
            // now check if the interpolator has reached 1.0
            // and swap maximum and minimum so game object moves
            // in the opposite direction.
            if (t > 1.0f)
            {
                float temp = maximum;
                maximum = minimum;
                minimum = temp;
                t = 0.0f;
            }

            float xp2 = this.collider.transform.position.x;
            float yp2 = this.collider.transform.position.y;
            float xp1 = transform.position.x;
            float yp1 = transform.position.y;
            angle = Mathf.Atan2(yp1 - yp2, xp1 - xp2);
            if(clockwise)
                angle += Time.deltaTime * speed; //if you want to switch direction, use -= instead of +=
            else
                angle -= Time.deltaTime * speed;

            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            transform.position = new Vector3(x, y);

        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.name == "Planet")
        {
            this.collider = collider;
            float xp2 = collider.transform.position.x;
            float yp2 = collider.transform.position.y;
            float xp1 = transform.position.x;
            float yp1 = transform.position.y;
            //??
            angle = Mathf.Atan2(yp1 - yp2, xp1 - xp2);
            scale = collider.gameObject.transform.localScale;
            CircleCollider2D Ccollider = collider.GetComponent<CircleCollider2D>();
            radius = ((CircleCollider2D)collider).radius * scale.x;


            clockwise = (Random.value >= 0.5);
            //Debug.Log(clockwise);
            originalRadius = radius;
            minimum = - 0.05f;
            maximum = 0.05f;
        }
    }
}
