using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomExplosion : MonoBehaviour
{
    private List<Rigidbody> cells;
    public float cellAliveTime = 1f;
    public GameObject smokeTrailPrefab;
    public GameObject explosionParticlePrefab;
    public Transform explosionCenter; 
    public float upwardsForce, radius, force;

    void Start()
    {
        cells = new List<Rigidbody>();
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<Rigidbody>();
            cells.Add(child.gameObject.GetComponent<Rigidbody>());
        }
        Explode();
    }

    private void Explode()
    {
        foreach(Rigidbody rb in cells)
        {
            rb.AddExplosionForce(force, explosionCenter.position, radius, upwardsForce, ForceMode.Impulse);
            rb.gameObject.AddComponent<DeathScript>().aliveTime = cellAliveTime;
            var smokeTrail = Instantiate(smokeTrailPrefab, rb.transform.position, rb.transform.rotation);

            smokeTrail.transform.parent = rb.transform;
        }
        var boom = Instantiate(explosionParticlePrefab, transform.position, transform.rotation);
    }
}
