using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplayPlatform : MonoBehaviour
{
    [SerializeField] private GameObject plateform;
    //[SerializeField] private GameObject goldbar;
    //[SerializeField] private GameObject health;
    private float respawnTime = 1.0f;
    private Vector2 screenbound;
    private int number;
    private GameObject level;
    private string levelname;
    //private GameObject Ball;
    //private float timer;
    //private float timer2;

    // Start is called before the first frame update
    void Start()
    {
        //Ball = GameObject.Find("Ball");
        screenbound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(platformmove());
        
    }
    private void deployfloor() {
        GameObject floor = Instantiate(plateform) as GameObject;
        
        number = Random.Range(1,4);
        levelname = "Level" + number.ToString();
        level = GameObject.Find(levelname);
        floor.transform.position = new Vector3(20,level.GetComponent<Transform>().position.y,level.GetComponent<Transform>().position.z);
        //Debug.Log(timer);
       /* if (timer < 0.03)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            GameObject goldie = Instantiate(goldbar) as GameObject;
            goldie.transform.position = new Vector3(screenbound.x * -2, level.GetComponent<Transform>().position.y + 0.7f, level.GetComponent<Transform>().position.z);
            timer = 0;
        }
        if (timer2 < 0.06)
        {
            timer2 = timer2 + Time.deltaTime;
        }
        else
        {
            GameObject heartie = Instantiate(health) as GameObject;
            heartie.transform.position = new Vector3(screenbound.x * -2, level.GetComponent<Transform>().position.y - 1.0f, level.GetComponent<Transform>().position.z);
            timer2 = 0;
        }*/

    }
    // Update is called once per frame
    IEnumerator platformmove()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            deployfloor();
        }
    }
}
