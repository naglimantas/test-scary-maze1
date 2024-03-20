using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Jumpscare : MonoBehaviour
{
    [SerializeField] private Image customImage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            print("touched");
            customImage.enabled = true;
        }
    }
}
