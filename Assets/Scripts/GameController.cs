using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHP;
    [SerializeField] private GameObject player;
    private int HP;

    // Start is called before the first frame update
    void Start()
    {
		HP = player.GetComponent<PlayerController>().getHP();
	}

    // Update is called once per frame
    void Update()
    {
        HP = player.GetComponent<PlayerController>().getHP();
        textHP.text = "HP: " + HP;
        Debug.Log(HP);
    }



}
