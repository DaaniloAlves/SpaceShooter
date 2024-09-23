using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : EntidadeController
{
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, velocidade);
        velocidade = -2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // vendo se o inimigo é visivel, e se for, atirando
        if (verificarVisibilidade())
        {
            controladorTiro -= 1f * Time.deltaTime;
            atirar(tiro, 2f, -1f);
        }
    }

    bool verificarVisibilidade()
    {
        return GetComponentInChildren<SpriteRenderer>().isVisible;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Jogador"))
        {
            collision.GetComponent<EntidadeController>().perderVida(1);
        }
        if (collision.CompareTag("Destruidor"))
        {
            Destroy(gameObject);
        }
	}

}
