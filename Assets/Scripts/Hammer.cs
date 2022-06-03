using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
	public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter(Collision enemy)
	{
		if(enemy.gameObject.tag == "Enemy")
		{
			Mole mole = enemy.transform.GetComponent<Mole>();
			mole.OnHit();
			player.score ++;
		}
			
	}
}
