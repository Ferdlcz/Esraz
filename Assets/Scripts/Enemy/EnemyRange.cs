using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{

    public Animator anim;
    public Enemy enemy;
    
    void OnTriggerEnter(Collider coll){

        if(coll.CompareTag("PJ")){
           
            if(!enemy.stunned){
                anim.SetBool("walk", false);
                anim.SetBool("run", false);

                enemy.enemyAttack.Play();
                anim.SetBool("attack", true);
                
                enemy.attack = true;
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
