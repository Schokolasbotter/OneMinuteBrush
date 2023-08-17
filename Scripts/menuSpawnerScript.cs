using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuSpawnerScript : MonoBehaviour
{
    public float speed = 1, spawnRate = 1f;
    private float timer = 0f;
    public GameObject toothPrefab, teethParent;
    
    private void Update()
    {
        //Move on X-Axis with sine wave
        Vector3 positionVector = new Vector3(Mathf.Sin(Time.time * speed) * Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x, 0f, 0f);
        transform.position = new Vector3(positionVector.x,transform.position.y,transform.position.z);
        //Spawn Object
        if(timer <= 0)
        {
            Instantiate(toothPrefab,transform.position,Quaternion.AngleAxis(0,Vector3.zero),teethParent.transform);
            timer = spawnRate;
        }
        timer -= Time.deltaTime;

    }
}
