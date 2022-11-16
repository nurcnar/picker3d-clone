using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BallMovement : MonoBehaviour
{
    public bool inside=false;
    public int i = 0;
    private Rigidbody rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Control"))
        {
            if(inside==false)
            {
                PlayerMovement.instance.balls.Add(this);
            }
            inside = true;
            /*i++;
            if(i%2==0)
            {
                inside = false;
                //GameObject last = PlayerMovement.instance.balls.Last();
                PlayerMovement.instance.balls.Remove(this);

            }
            else
            {
                inside = true;
                PlayerMovement.instance.balls.Add(this);
            }*/
        }
    }
    public void Throw()
    {
        rb.AddForce(Vector3.right*Time.deltaTime*0.0050f);
    }
}
