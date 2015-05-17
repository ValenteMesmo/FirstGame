//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using UnityEngine;

//[RequireComponent(typeof(DrawedPath2d))]
//public class FollowPath : MonoBehaviour
//{
//    DrawedPath2d Path;
//    int pathIndex = 0;

//    public float Speed = 0.5f;
//    public float MagicNumber = 0.5f;

//    void Start()
//    {
//        Path = GetComponent<DrawedPath2d>();
//    }

//    void Update()
//    {
//        var targetPosition = Path.Points[pathIndex];
//        //Debug.Log("target: x=" + targetPosition.x + "; y=" + targetPosition.y + ";");
//        var currentPosition = transform.position;
//        //Debug.Log("current: x=" + currentPosition.x + "; y=" + currentPosition.y + ";");

//        var xDistance = targetPosition.x - currentPosition.x;

//        //Debug.Log("xDistance: " + xDistance);
//        var yDistance = targetPosition.y - currentPosition.y;
//        //Debug.Log("yDistance: " + yDistance);

//        if (xDistance.IsBetween(-MagicNumber, MagicNumber) && yDistance.IsBetween(-MagicNumber, MagicNumber))
//            SetNextPathIndex();
//        else
//        {
//            var nextPosition = new Vector2(transform.position.x, transform.position.y);

//            if (currentPosition.x < targetPosition.x)
//                nextPosition.x += Speed;
//            else if (currentPosition.x > targetPosition.x)
//                nextPosition.x -= Speed;

//            if (currentPosition.y < targetPosition.y)
//                nextPosition.y += Speed;
//            else if (currentPosition.y > targetPosition.y)
//                nextPosition.y -= Speed;

//            transform.position = nextPosition;
//        }
//    }

//    private void SetNextPathIndex()
//    {
//        pathIndex++;
//        if (pathIndex >= Path.Points.Length)
//            pathIndex = 0;
//    }
//}