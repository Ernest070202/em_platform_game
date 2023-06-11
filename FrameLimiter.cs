using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameLimiter : MonoBehaviour
{
    [SerializeField] int limit = 60;

    void Awake()
    {
        Application.targetFrameRate = limit;
    }
}
