using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IActivable
{
    [SerializeField]
    private List<Transform> points = new List<Transform>();

    private Vector3 startPosition;

    private Vector3 targetPostion;

    private int targetIndex = 1;

    private float startTime = 0f;

    [SerializeField]
    private float duration = 3f;

    private bool canMove = false;

    private void Awake()
    {
        startPosition = points[0].position;
        targetPostion = points[targetIndex].position;
    }

    private void Update()
    {
        if (canMove)
        {
            float t = (Time.time - startTime) / duration;
            transform.position = new Vector3(Mathf.SmoothStep(startPosition.x, targetPostion.x, t),
                Mathf.SmoothStep(startPosition.y, targetPostion.y, t), transform.position.z);

            if (t >= 1)
            {
                NextPoint();
            }
        }
    }

    private void NextPoint()
    {
        startPosition = targetPostion;
        targetIndex = (targetIndex + 1) % points.Count;
        targetPostion = points[targetIndex].position;
        startTime = Time.time;
    }

    public void Activate()
    {
        canMove = true;
        startTime = Time.time;
    }

    public void Deactivate()
    {
        startPosition = transform.position;
        startTime = Time.time;
        canMove = false;
    }
}
