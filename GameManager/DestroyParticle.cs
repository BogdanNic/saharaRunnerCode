using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {

    void OnParticleCollision(GameObject other)
    {
        print("coll Wall");
        DestroyImmediate(other);
    }
}
