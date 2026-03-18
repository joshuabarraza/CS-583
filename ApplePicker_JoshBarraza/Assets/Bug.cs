using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a
// b

public class Bug : MonoBehaviour {
    public static float bottomY = -20f;
    void Update () {
        if ( transform.position.y < bottomY ) {
            Destroy( this.gameObject );
        }
    }
}
