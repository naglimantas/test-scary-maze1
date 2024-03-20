using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rb;
    private AudioSource audioSource;
    [Header("Audio effects")]
    public AudioClip dieSound;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        //convert ui mouse coordinates to world coordinates
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;

        //move the player towards the mouse according to given speed
        var target = Vector3.MoveTowards(transform.position, worldPos, speed);
        var targetViewPort = Camera.main.WorldToViewportPoint(target);
        rb.MovePosition(target);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(dieSound);
        }
    }
}
