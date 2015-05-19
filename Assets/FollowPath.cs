using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(DrawedPath))]
public class FollowPath : MonoBehaviour
{
    DrawedPath Path;
    int pathIndex = 0;

    public float Speed = 0.5f;
    public float MagicNumber = 0.5f;

    void Start()
    {
        Path = GetComponent<DrawedPath>();
    }

    void Update()
    {
        var targetPosition = Path.Points[pathIndex];
        var currentPosition = transform.position;

        var xDistance = targetPosition.x - currentPosition.x;

        var yDistance = targetPosition.y - currentPosition.y;

        if (xDistance.IsBetween(-MagicNumber, MagicNumber) && yDistance.IsBetween(-MagicNumber, MagicNumber))
            SetNextPathIndex();
        else
        {
            var nextPosition = new Vector2(transform.position.x, transform.position.y);

            if (currentPosition.x < targetPosition.x)
                nextPosition.x += Speed;
            else if (currentPosition.x > targetPosition.x)
                nextPosition.x -= Speed;

            if (currentPosition.y < targetPosition.y)
                nextPosition.y += Speed;
            else if (currentPosition.y > targetPosition.y)
                nextPosition.y -= Speed;

            transform.position = nextPosition;
        }
    }

    private void SetNextPathIndex()
    {
        pathIndex++;
        if (pathIndex >= Path.Points.Length)
        {

            pathIndex = 0;
        }
    }
}