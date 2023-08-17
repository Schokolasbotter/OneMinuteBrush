using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class toothScript : MonoBehaviour
{
    public int dirtLevel = 0;
    public float brushTimer = 0f;
    public teethCollection gameScript;
    public Sprite clean, dirt1, dirt2, dirt3, dirt4, dirt5;
    private SpriteRenderer spriteRenderer;
    public AudioClip cleanEffect;

    private void Start()
    {
           spriteRenderer = GetComponent<SpriteRenderer>();        
    }

    private void Update()
    {
        switch (dirtLevel)
        {
            case < 1:
                spriteRenderer.sprite = clean;
                break;
            case < 3:
                spriteRenderer.sprite = dirt1;
                break;
            case < 6:
                spriteRenderer.sprite = dirt2;
                break;
            case < 9:
                spriteRenderer.sprite = dirt3;
                break;
            case < 12:
                spriteRenderer.sprite = dirt4;
                break;
            case < 15:
                spriteRenderer.sprite = dirt4;
                break;
            default:
                spriteRenderer.sprite = clean;
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && gameScript.gameOn)
        {
            toothbrushPosition toothbrushPos = collision.GetComponentInParent<toothbrushPosition>();
            if (brushTimer > 0f && toothbrushPos.isBrushing)
            {
                float normal = Mathf.InverseLerp(0f, 2f, toothbrushPos.positionDifferenceMagnitude);
                float timerMultiplier = Mathf.Lerp(1f, 2f, normal);
                brushTimer -= timerMultiplier * Time.deltaTime;
            }

            if(brushTimer <= 0 && dirtLevel > 0)
            {
                dirtLevel--;
                brushTimer = 1f;
                if(dirtLevel == 0)
                {
                    GameObject.Find("SoundEffect").GetComponent<AudioSource>().PlayOneShot(cleanEffect);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && gameScript.gameOn)
        {
            if (brushTimer <= 0f)
            {
                
                brushTimer = 1f;
            }
        }
    }
}
