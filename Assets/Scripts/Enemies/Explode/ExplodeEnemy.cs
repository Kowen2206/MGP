using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEnemy : MonoBehaviour
{
    [SerializeField] private GameObject explodeObj;
    [SerializeField] private float timeToDestroy;

    private void Start()
    {
        StartCoroutine(DestroyThis());
    }
    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(timeToDestroy);
        GameObject.Destroy(this.gameObject);
        StopAllCoroutines();
    }
}
