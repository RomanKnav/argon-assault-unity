using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void Update()
    {
        Debug.Log("fucking work");
    }

    // requires one obj to have "Is Trigger" enabled and have a rigidBody:
    void OnTriggerEnter(Collider other)
    {
        // easier substitute: use this.name:
        var playerName = gameObject.tag;
        Debug.Log(playerName + " collided with " + other.gameObject.tag);
        // Debug.Log("fucking collision!!!");
    }    

    // to work, both objs need to have "Is Trigger" disabled
    void OnCollisionEnter(Collision other) {
        Debug.Log("Actual FUCKING COLLISION");

        // USING STRING INTERPOLATION:
        Debug.Log($"{this.name} collided with {other.gameObject.name}");
    }
}
