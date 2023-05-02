using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float ExplosionDelay = 5;

    public GameObject ExplosionPrefab;

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
        Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation);
        Destroy(gameObject);
    }
}
