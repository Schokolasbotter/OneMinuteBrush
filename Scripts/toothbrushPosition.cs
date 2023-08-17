using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class toothbrushPosition : MonoBehaviour
{
    private Input inputActions;
    private InputAction position, click;
    private SpriteRenderer spriteRenderer;
    private AudioSource audiosource;
    public Sprite liftedSprite, brushingSprite;
    public GameObject soap;

    public bool isBrushing = false;
    private Vector2 previousPosition;
    public float positionDifferenceMagnitude = 0;

    private void Awake()
    {
        inputActions = new Input();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        audiosource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        position = inputActions.toothBrushMap.Mouse;
        click = inputActions.toothBrushMap.Click;
        position.Enable();
        click.Enable();
    }

    private void OnDisable()
    {
        position.Disable();
        click.Disable();
    }

    private void Start()
    {
        previousPosition = Camera.main.ScreenToWorldPoint(position.ReadValue<Vector2>());
    }

    private void FixedUpdate()
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(position.ReadValue<Vector2>());
        transform.position = worldPosition;
        if(worldPosition != previousPosition && click.phase == InputActionPhase.Performed)
        {
            isBrushing = true;
            Vector3 colliderPosition = transform.GetChild(0).position;
            Instantiate(soap, colliderPosition,Quaternion.AngleAxis(Random.Range(-180f,180f),Vector3.forward),Camera.main.transform);
            audiosource.mute = false;
        }
        else
        {
            isBrushing = false;
            audiosource.mute = true;
        }
        positionDifferenceMagnitude = (worldPosition - previousPosition).magnitude;
        previousPosition = worldPosition;
    }

    private void Update()
    {
        if(click.phase == InputActionPhase.Performed)
        {
            spriteRenderer.sprite = brushingSprite;
        }
        else
        {
            spriteRenderer.sprite = liftedSprite;
        }
    }


}
