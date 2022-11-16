using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 mousePosStart;
    public Vector2 mousePosCurrent;
    public bool isMove = true;
    public bool platformMoving=false;
    public List<BallMovement> balls = new List<BallMovement>();
    public static PlayerMovement instance;
    public Rigidbody rb;
    public bool wheel=false;
    public List<Rotator> rotators;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
       
        if (isMove)
            transform.Translate(Time.deltaTime * 5, 0, 0); //ileri yön

        DirectionMovement();
    }
    public void DirectionMovement()//sağ sol hareket
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosStart = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            mousePosCurrent = Input.mousePosition;
            if (mousePosStart.x < mousePosCurrent.x)
            {
                transform.position -= Vector3.forward * Time.deltaTime * 5;
            }
            else
            {
                transform.position += Vector3.forward * Time.deltaTime * 5;
            }
            mousePosCurrent = Input.mousePosition;

            float z = Mathf.Clamp(transform.position.z, -8, 9);
            float x = Mathf.Clamp(transform.position.x, -1, 100);

            transform.position = new Vector3(x, transform.position.y, z);
        }
    } 
    public void Add(BallMovement ball)
    {
        balls.Add(ball);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Level"))
        {
            Destroy(other.gameObject);
            isMove = false;
            RotatorOffActive();
            if (balls.Count >= 0)
            {
                StopAndTransfer();
                StartCoroutine(Rotator());
            }
        }
    }
    public void StopAndTransfer()
    {
        int ballCount = balls.Count;

        for (int i = 0; i < ballCount; i++)
        {
            BallMovement bal = balls.Last();
            bal.Throw();
            balls.Remove(bal);
        }
        platformMoving = true;
        wheel = true;
    }

    public IEnumerator Rotator()
    {
        yield return new WaitForSeconds(3);
        foreach (var rotator in rotators)
        {
            rotator.gameObject.SetActive(true);
        }
    }
    public void RotatorOffActive()
    {
        foreach (var rotator in rotators)
        {
            rotator.gameObject.SetActive(false);
        }
    }
    public IEnumerator Throw()
    {
        for (int i = 0; i < 10; i++)
        {
            rb.AddForce((Vector3.up + Vector3.right) * Time.deltaTime * 2000);

        }
        for (int i = 0; i < 10; i++)
        {
            rb.AddForce((Vector3.down + Vector3.right) * Time.deltaTime *2000);
        }
        yield return new WaitForSeconds(1);
        
    }
}
