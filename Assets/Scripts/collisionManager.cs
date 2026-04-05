using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour
{
    [SerializeField] private GameObject rose;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == rose)
        {
            Debug.Log(gameObject.name + " was hit by rose! ");
            rose.SetActive(false);
        }
    }
}
