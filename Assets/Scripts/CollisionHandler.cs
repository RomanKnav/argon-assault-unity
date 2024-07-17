using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem explodeParticles;

    [Tooltip("Delay before restarting level")] 
    [SerializeField] float delay = 2f;

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

        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", delay);
    }    

    // to work, both objs need to have "Is Trigger" disabled
    void OnCollisionEnter(Collision other) {
        Debug.Log("Actual FUCKING COLLISION");

        explodeParticles.Play();

        // USING STRING INTERPOLATION:
        Debug.Log($"{this.name} collided with {other.gameObject.name}");

        // script disables itself lmfao
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        Invoke("ReloadLevel", delay);
        // Destroy(gameObject);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;   // get the index of the active scene.
        SceneManager.LoadScene(currentSceneIndex);
    }
}
