using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
	public Player player;
	//public GameObject MoleContainer;
	//private Mole[] moles;

    // Start is called before the first frame update
    void Start()
    {
        //moles = MoleContainer.GetComponentsInChildren<Mole> ();
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
			print("collided with mole");
			mole.OnHit();
			player.score ++;
		}
			
	}
}
