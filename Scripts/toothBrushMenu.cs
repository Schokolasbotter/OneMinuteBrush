using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toothBrushMenu : MonoBehaviour
{
    public float movingRange = 10f, movementSpeedX = 2, movementSpeedY = 1, timer = 1, rotationSpeed = 3f;
    public GameObject soapPrefab;
    private Vector3 colliderPosition;
    private float randomXPhase, randomYPhase, randomRotationPhase;

    private void Start()
    {
        randomXPhase = Random.Range(0, 10000);
        randomYPhase = Random.Range(0, 10000);
        randomRotationPhase = Random.Range(0, 10000);
    }
    private void Update()
    {
        //Move the brush
        Vector3 movingVector = new Vector3(Mathf.Sin((Time.time + randomXPhase) * movementSpeedX)*9, Mathf.Sin((Time.time + randomYPhase) * movementSpeedY)*5, 0f);
        transform.position = movingVector;
        //Rotate the brush
        transform.rotation = Quaternion.AngleAxis(Mathf.Cos(Time.time + randomRotationPhase)*180,Vector3.forward);
        //Spawn Soap
        colliderPosition = transform.GetChild(0).position;
        Instantiate(soapPrefab, colliderPosition, Quaternion.AngleAxis(Random.Range(-180f, 180f), Vector3.forward), Camera.main.transform);
        timer = 1;  
    }
}
