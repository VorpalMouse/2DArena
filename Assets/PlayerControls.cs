using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControls : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
    {
		anim=GetComponent<Animator>();
    }
    public Vector2 speed = new Vector2(50,50);
    private Animator anim;

	// Update is called once per frame
	void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		if ((inputX==0)&&(inputY==0))
		{
			anim.SetBool("playerMoving",false);
		}
		else
		{
			anim.SetBool("playerMoving",true);
		}
	
		Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

		movement *= Time.deltaTime;

		transform.Translate(movement);
    }
}
