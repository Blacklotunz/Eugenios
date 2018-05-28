using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    [Range(1f, 20f)]
    public float speed = 1f;
    public float scrollOffset;
    public GameObject relatedBackground;

    // Use this for initialization
    void Start () {
        
    }
	
	void Update () {        
        if(transform.position.x < -scrollOffset)
        {
            var x = relatedBackground.transform.position.x + 2 * relatedBackground.GetComponent<SpriteRenderer>().bounds.extents.x;
            transform.position = new Vector3(x, 0);
        }
        transform.position = new Vector3(transform.position.x + Vector2.left.x * (speed * Time.deltaTime), 0f);
    }
}
