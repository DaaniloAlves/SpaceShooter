using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntidadeController : MonoBehaviour
{
	[SerializeField] protected GameObject animacaoDestruicao;
	[SerializeField] protected int HP;

	void Start()
    {
        
    }

    
    void Update()
    {
        
    }

	public void perderVida(int qtd)
	{
		HP -= qtd;
		if (HP <= 0)
		{
			Destroy(gameObject);
			Instantiate(animacaoDestruicao, transform.position, Quaternion.identity);
		}
	}

}
