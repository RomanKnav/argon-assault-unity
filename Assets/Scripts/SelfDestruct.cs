using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    void Start() {
        DestroyObject();
    }

    // what exacly are the objs put inside this parent? GAMEOBJECTS. EVERYTHING is a gameobject. They DONT have any scripts on them
    // names of the objs? Enemy Explosion (Clone). Maybe pass script to Enemy Explosion Prefab?     YES
    void DestroyObject() {
        Destroy(gameObject, 2);
    }

}
