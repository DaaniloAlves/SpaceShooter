using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntidadeController : MonoBehaviour
{
	[SerializeField] protected GameObject animacaoDestruicao;
	[SerializeField] protected int HP;
	[SerializeField] protected GameObject tiro;
	[SerializeField] protected float velocidade;
	protected Transform posicaoTiro;
	protected Rigidbody2D rb;
	protected float controladorTiro = 0f;
	protected int pontuacao;

	public void perderVida(int qtd)
	{
		HP -= qtd;
		if (HP <= 0)
		{
			Destroy(gameObject);
			Instantiate(animacaoDestruicao, transform.position, Quaternion.identity);
			if (pontuacao > 0f)
			{
				FindObjectOfType<GameController>().aumentarScore(pontuacao);
			}
		}
	}

	public void atirar(GameObject tiro, float delay, bool seguir, float velocidadeX, float velocidadeY)
	{
		if (controladorTiro <= 0)
		{
			var player = FindObjectOfType<PlayerController>();
			if (player)
			{
				posicaoTiro = transform.Find("tiro");
				GameObject tiroInstanciado = Instantiate(tiro, posicaoTiro.position, Quaternion.identity);
				controladorTiro = delay;
				tiroInstanciado.GetComponent<Rigidbody2D>().velocity =  new Vector2(velocidadeX, velocidadeY);
				if (seguir)
				{		
					Vector2 direcao = player.transform.position - tiroInstanciado.transform.position;
					tiroInstanciado.GetComponent<Rigidbody2D>().velocity = direcao.normalized * velocidadeY;
					float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
					tiro.transform.rotation = Quaternion.Euler(0, 0, angulo + 90);
				}
			}
		}

	}

	public int getHP()
	{
		return HP;
	}

	public bool verificarVisibilidade()
	{
		return GetComponentInChildren<SpriteRenderer>().isVisible;
	}

}
