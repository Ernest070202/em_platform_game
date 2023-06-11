using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraController : MonoBehaviour
{
    Vector2 BoxSize;
    Vector2 BoxPos;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask CameraStop;

    private void Start()
    {
        BoxSize = new Vector2(10, 10);
    }

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 1, transform.position.z);
        BoxPos = new Vector2(player.position.x, player.position.y);
        IsChasm();
    }

    private bool IsChasm()
    {

        if (Physics2D.BoxCast(BoxPos, BoxSize , 0f, Vector2.down, .1f, CameraStop))
        {
            Debug.Log("IsChasm Collision");
            return true;
        }
        else return false;
    }
}


