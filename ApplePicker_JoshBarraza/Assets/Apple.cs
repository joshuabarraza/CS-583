using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a
// b

public class Apple : MonoBehaviour {
    public static float bottomY = -20f;
    void Update () {
        if ( transform.position.y < bottomY ) {
            Destroy( this.gameObject );
            // c
        }
    }

// void Start() {…} // Please delete the unused Start() method
}
