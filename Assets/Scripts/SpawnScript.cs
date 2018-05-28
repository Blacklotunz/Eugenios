using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject letter;
    public float spawnTime;
    GameObject spawn;

    // Use this for initialization
    void Start () {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        //Invoke("Spawn", 0f);
    }

    // Update is called once per frame
    void Update () {
	    if(spawn != null) spawn.GetComponent<Rigidbody2D>().AddForce(transform.up * 5f);
    }


   


    void Spawn()
    {
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        spawn = (GameObject)Instantiate(letter, this.transform.position, new Quaternion(0f, 0f, 0f, 0f));
        spawn.GetComponent<Rigidbody2D>().AddForce(transform.up * 5f);
    }
}
