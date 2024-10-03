using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02Controller : EntidadeController
{
	private bool movimentou = false;
	void Start()
	{
		pontuacao = 20;
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
			PlayerController player = FindObjectOfType<PlayerController>();
			atirar(tiro, 2.5f, true, 0, 4.5f);
		}
		movimentar();
		if (gameObject.transform.position.y <= -5.5)
		{
			Destroy(gameObject);
		}
	}

	void movimentar()
	{
		if (gameObject.transform.position.y <= 0 && gameObject.transform.position.y <= 2.5f)
		{
			if (!movimentou)
			{
				gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(3.5f, 0);
				movimentou = true;
			}
		} else if (gameObject.transform.position.x >= 0 && gameObject.transform.position.y <= 2.5f)
		{
			if (!movimentou)
			{
				gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(-3.5f, 0);
				movimentou = true;
			}
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
