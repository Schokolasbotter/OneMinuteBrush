using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soapScript : MonoBehaviour
{ 
    void Update()
    {
        transform.localScale = transform.localScale - new Vector3(0.01f, 0.01f, 0.01f);
        if(transform.localScale.x <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
