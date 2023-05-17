using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float ExplosionDelay = 5;

    public GameObject ExplosionPrefab;

    void Start() {
        StartCoroutine(ExplosionCoroutine());
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
