using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : EntidadeController
{
    void Start()
    {
        pontuacao = 10;
	    rb = GetComponent<Rigidbody2D>();
		velocidade = -2.5f;
		rb.velocity = new Vector2(0, velocidade);
        
    }

    // Update is called once per frame
    void Update()
    {
        // vendo se o inimigo é visivel, e se for, atirando
        if (verificarVisibilidade())
        {
            controladorTiro -= 1f * Time.deltaTime;
            atirar(tiro, 2f, false, 0, -5f);
        }
		if (gameObject.transform.position.y <= -5.5)
		{
			Destroy(gameObject);
		}
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
