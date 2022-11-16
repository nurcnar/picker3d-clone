using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public int id;
    public int platformId;
    public int barrierId;

    private void Start()
    {
        GameEventSystem.instance.Platform += Move;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            ScoreManager.instance.AddScore();
            Destroy(other.gameObject);
            //isMove = true;
        }
        if(PlayerMovement.instance.platformMoving == true)
        {
            GameEventSystem.instance.PlatformMovement(platformId);
        }
    }

    public void Move(int _platformId)
    {
        if (platformId != _platformId)
            return;
        
        StartCoroutine(High());
    }
    public IEnumerator High()
    {
        yield return new WaitForSeconds(.1f);
        {
            while (transform.position.y < 0)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                transform.Translate(0, Time.deltaTime, 0);
            }
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            GetComponent<Renderer>().material.color = new Color(250 / 255f, 138 / 255f, 236 / 255f);
            yield return new WaitForSeconds(.5f);
            PlayerMovement.instance.isMove = true;
            GameEventSystem.instance.BarrierOpening(barrierId);
            

        }
    }

}
