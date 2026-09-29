using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public Transform transGun;      // Para rodar o canhão
    public Transform spawnPoint;     // Criar este ponto na PONTA do canhão no Unity!
    public GameObject bulletObj;

    void Update()
    {
        // Controlo de movimento
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        // Inclinação do canhão (T / G)
        if (Input.GetKey(KeyCode.T))
        {
            transGun.RotateAround(transGun.position, transGun.right, -2);
        }
        else if (Input.GetKey(KeyCode.G))
        {
            transGun.RotateAround(transGun.position, transGun.right, 2);
        }

        // Disparo com a tecla B (usando o SpawnPoint na ponta)
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(bulletObj, spawnPoint.position, spawnPoint.rotation);
        }
    }
}