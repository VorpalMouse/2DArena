using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAttacking : MonoBehaviour
{
    public float timeToAttack;
    public float attackCooldown;
    public double attacking=0;
    public Collider2D weaponCollider;
    public Animator weaponAnim;
    // Start is called before the first frame update
    void Start()
    {
	Physics2D.IgnoreLayerCollision(0,6);
	weaponCollider.enabled=false;
	weaponAnim.SetBool("isAttack",false);
    }

    // Update is called once per frame

    void Update()
    {
        attacking=attacking-0.1;
	if(timeToAttack<=0){

             if(Input.GetMouseButtonDown(0)){
	  	attacking=50;
		weaponCollider.enabled=true;
                timeToAttack=attackCooldown;
		weaponAnim.SetBool("isAttack",true);
             }
	     
	}
        else{
             timeToAttack-=Time.deltaTime;
        }
	if(attacking<=1)
	{
		weaponCollider.enabled=false;
		attacking=0;
		weaponAnim.SetBool("isAttack",false);
	}
    }
}