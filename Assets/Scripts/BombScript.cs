using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float ExplosionDelay = 5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExplosionCoroutine()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ExplosionCoroutine() {
        yield return new WaitForSeconds(ExplosionDelay);

        Explode();
    }

    private void Explode() {
        Destroy(gameObject);
    }
}
