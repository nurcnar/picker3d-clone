using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public enum Direction
    {
        Right,
        Left 
    };
    public Direction dir;
    void Update()
    {
        if(PlayerMovement.instance.wheel==true)
        {
            switch (dir)
            {
                case Direction.Right:
                    transform.Rotate(-Vector3.up);
                    break;
                case Direction.Left:
                    transform.Rotate(Vector3.up);
                    break;
            }
        }
        
    }
}
