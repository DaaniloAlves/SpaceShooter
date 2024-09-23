using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntidadeController : MonoBehaviour
{
	[SerializeField] protected GameObject animacaoDestruicao;
	[SerializeField] protected int HP;
	[SerializeField] protected GameObject tiro;
	[SerializeField] protected float velocidade;
	protected Rigidbody2D rb;
	protected float controladorTiro = 0f;

	public void perderVida(int qtd)
	{
		HP -= qtd;
		if (HP <= 0)
		{
			Destroy(gameObject);
			Instantiate(animacaoDestruicao, transform.position, Quaternion.identity);
		}
	}

	public void atirar(GameObject tiro, float delay, float posicao)
	{
		if (controladorTiro <= 0)
		{
			Instantiate(tiro, new Vector3(transform.position.x, transform.position.y + posicao, transform.position.z), Quaternion.identity);
			controladorTiro = delay;
		}
	}

	public int getHP()
	{
		return HP;
	}

}
