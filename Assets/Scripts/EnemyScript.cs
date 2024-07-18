using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;       // different from INSTANTIATING.
    [SerializeField] Transform parent;          // the Spawn at Runtime obj goes here. It has nothing but a transform component in it.

    [SerializeField] private SelfDestruct selfDestruct; 

    // destroy obj if hit by particle:
    void OnParticleCollision(GameObject other)
    {
        // why do we have to use this? Remember: the particle explosions is not a child of the obj as it is with player. 
        // we make this into a gameObj and store in vfx:
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);     // 3rd arg means no rotation. This just makes the bullets ricochet.
        // this Instantiate is what actually creates the Clone objs in our heirarchy. 
        // since this is assigned to a var, how does it even initiate?

        vfx.transform.parent = parent;      // this is how we assign objs to a parent
        Destroy(gameObject);                // destroys THIS game obj, not vfx. 

        
    }
}