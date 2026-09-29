using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShell : MonoBehaviour
{
    public GameObject explosion;
    Rigidbody rb;

    void OnCollisionEnter(Collision col)
    {
        // Se bater noutra bala (qualquer objeto que tenha o script AIShell), ignora
        if (col.gameObject.GetComponent<AIShell>() != null)
        {
            return;
        }

        // Instancia a explosão ao bater no chão, tanque ou outro obstáculo
        if (explosion != null)
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
        }

        // Destroi a bala
        Destroy(this.gameObject);
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
#if UNITY_6000_0_OR_NEWER
            this.transform.forward = rb.linearVelocity;
#else
        this.transform.forward = rb.velocity;
#endif
    }
}