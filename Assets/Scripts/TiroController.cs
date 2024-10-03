using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject animacao;

    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Inimigo") || collision.CompareTag("Jogador"))
        {
            if (collision.GetComponent<Transform>().position.y < 5)
            {
                collision.GetComponent<EntidadeController>().perderVida(1);
            }
		}
        Instantiate(animacao, transform.position, Quaternion.identity);
	    Destroy(this.gameObject);
		
	}

    public void setVelocidade(Vector2 v2)
    {
        rb.velocity = v2;
    }

}
