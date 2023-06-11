using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    public GameObject myPrefab;
    GameObject instance;
    public Transform SpawnLocation;
    public Quaternion SpawnRotation;
    [SerializeField] private float FireInterval;
    [SerializeField] private float FireStart = 0f;
    [SerializeField] private float FireballDestroyTimer = 2f;

    void Start()
    {
        InvokeRepeating("Fire", FireStart, FireInterval);
    }
    void Fire()
    {
        instance = Instantiate(myPrefab, SpawnLocation.position, SpawnRotation);
        Destroy(instance, FireballDestroyTimer);
    }

}
