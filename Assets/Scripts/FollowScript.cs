﻿using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour {
    GameObject target;
    public float speed;
    GameObject[] landingPnts;
    bool arrived, catched;
	
    // Use this for initialization
	void Start () {
        arrived = false;
        catched = false;
        landingPnts = GameObject.FindGameObjectsWithTag("Target");
        target = landingPnts[Random.Range(0, landingPnts.Length)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (!arrived)
        {
            Vector2 heading = target.transform.position - this.transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance; // This is now the normalized direction.
            this.GetComponent<Rigidbody2D>().AddForce(direction * speed);
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Target")
        {
            arrived = true;
            target = landingPnts[Random.Range(0, landingPnts.Length)];
            arrived = false;
        }
        if (collider.tag == "LandingPoint")
        {
            arrived = true;
            this.transform.parent = collider.transform;
           // Invoke("DestroyThis", 3.5f);
            Destroy(this.gameObject, 3.5f);
        }
        if(collider.tag == "Player")
        {
            //Destroy(this.gameObject, 0f);
            Destroy(this.GetComponent<Collider2D>());
            arrived = false;
            this.catched = true;

            if (GameObject.Find("FinalPositionA").transform.childCount == 0)
            {
                target = GameObject.Find("FinalPositionA");
                this.transform.parent = target.transform;
            }
            else if (GameObject.Find("FinalPositionB").transform.childCount == 0)
            {
                target = GameObject.Find("FinalPositionB");
                this.transform.parent = target.transform;
            }
            else if (GameObject.Find("FinalPositionC").transform.childCount == 0)
            {
                target = GameObject.Find("FinalPositionC");
                this.transform.parent = target.transform;
            }
            else
            {
                Destroy(this.gameObject);
                Debug.Log("END");
            }
        }

        if (collider.tag == "FinalPosition")
        {
            this.transform.parent = collider.transform;
        }

    }

    private void DestroyThis()
    {
        Debug.Log("destroy");
        if (!this.catched)
        {
            DestroyImmediate(this.gameObject);
        }
    }
}
