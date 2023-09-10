using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{

    [SerializeField] float movingForce = 2f;
    [SerializeField] bool levelLost = false;
    [SerializeField] ParticleSystem balloonExplodeEffect;

    private void Update()
    {
        if (levelLost)
            return;

        transform.position += Vector3.up * movingForce * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Obstucle"))
        {
            LevelLost();
        }
    }

    void LevelLost()
    {
        levelLost = true;
        if (balloonExplodeEffect != null)
            Instantiate(balloonExplodeEffect, transform.position, Quaternion.identity);
        UIManager.instance.LevelFailed();
        gameObject.SetActive(false);
    }
}
