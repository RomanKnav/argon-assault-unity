using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;       // different from INSTANTIATING.

    // destroy obj if hit by particle:
    void OnParticleCollision(GameObject other)
    {
        // why do we have to use this? Remember: the particle explosions is not a child of the obj as it is with player. 
        Instantiate(deathVFX, transform.position, Quaternion.identity);     // 3rd arg means no rotation. This just makes the bullets ricochet.
        Destroy(gameObject);
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyScript : MonoBehaviour
// {
//     /// <summary>
//     /// OnParticleCollision is called when a particle hits a collider.
//     /// </summary>
//     /// <param name="other">The GameObject hit by the particle.</param>
//     private void OnParticleCollision(GameObject other)
//     {
//         Destroy(gameObject);
//     }
// }