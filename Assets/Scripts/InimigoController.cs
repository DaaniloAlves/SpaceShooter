using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : EntidadeController
{
    private Rigidbody2D rb;
    [SerializeField] private float velocidade = -2.5f;
    [SerializeField] private GameObject tiro;
    private float controladorTiro = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, velocidade);
        HP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        // vendo se o inimigo é visivel, e se for, atirando
        if (verificarVisibilidade())
        {
            controladorTiro -= 1f * Time.deltaTime;
            if (controladorTiro <= 0)
            {
                atirar();
                controladorTiro = 2f;
            }
        }
    }

    bool verificarVisibilidade()
    {
        return GetComponentInChildren<SpriteRenderer>().isVisible;
    }

    void atirar()
    {
        Instantiate(tiro, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity);
    }

}
