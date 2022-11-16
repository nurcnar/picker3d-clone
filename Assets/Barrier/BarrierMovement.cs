using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMovement : MonoBehaviour
{
    public bool isActive = false;
    public int id;
    public enum Direction
    {
        Right,
        Left
    };
    public Direction dir;
    private void Start()
    {
        GameEventSystem.instance.Barrier += On;
    }
    public void On(int _id)
    {
        if (id != _id)
            return;
        StartCoroutine(Opening());
    }
    public IEnumerator Opening()
    {
        if (!isActive)
        {
            switch (dir)
            {
                case Direction.Right:
                    for (int i = 0; i < 80; i++)
                    {
                        transform.Rotate(-Vector3.right * 8*Time.deltaTime);
                        yield return new WaitForSeconds(Time.deltaTime);
                    }
                    break;
                case Direction.Left:
                    for (int i = 0; i < 80; i++)
                    {
                        transform.Rotate(Vector3.right *8* Time.deltaTime);
                        yield return new WaitForSeconds(Time.deltaTime);
                    }
                    break;
            }
            isActive = true;
            
        }
    }

}
