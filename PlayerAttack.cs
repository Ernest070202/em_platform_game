using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject myPrefab;
    GameObject player;
    SpriteRenderer playerSprite;
    Vector3 spawnPoint;
    GameObject instance;
    [SerializeField] private LayerMask Ground;
    void Start()
    {
        player = GameObject.Find("Player");
        spawnPoint = player.transform.position;
        playerSprite = player.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            spawnPoint = player.transform.position;
            if (playerSprite.flipX == true)
            {
                spawnPoint.x -= 1f;
                instance = Instantiate(myPrefab, spawnPoint, Quaternion.identity);
            }
            if (playerSprite.flipX == false)
            {
                spawnPoint.x += 1f;
                instance = Instantiate(myPrefab, spawnPoint, Quaternion.identity);
            }
            Destroy(instance, 2);
        }
    }
}