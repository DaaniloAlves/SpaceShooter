using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private GameObject nave;

    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        rb.velocity += new Vector2(0, velocidade);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        Destroy(this.gameObject);
	}

}
