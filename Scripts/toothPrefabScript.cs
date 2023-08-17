using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toothPrefabScript : MonoBehaviour
{
    private int rotatioDirection = 0;
    public float downwardSpeed = 1f, rotationSpeed = 1f;
    public Sprite[] spriteCollection;
    private void Start()
    {
        //Chose rotation
        float randomNumber = Random.value;
        rotatioDirection = randomNumber switch
        {
            < 0.5f => -1,
            >= 0.5f => 1,
            _ => 1,
        };
        //Chose Sprite
        this.GetComponent<SpriteRenderer>().sprite = spriteCollection[Mathf.RoundToInt(Random.Range(0f, spriteCollection.Length-1))];
    }

    private void Update()
    {
        //Move Downwards
        transform.position = transform.position + new Vector3(0f, -downwardSpeed * Time.deltaTime, 0f);
        //Rotate
        transform.Rotate(new Vector3(0f, 0f, rotatioDirection * rotationSpeed));
        //Delete when under screen
        if(transform.position.y <= -6)
        {
            Destroy(this.gameObject);
        }
    }
}
