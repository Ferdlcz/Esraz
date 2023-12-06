using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator anim;
    public GameObject target;
    public EnemyRange range;


    public bool attack;
    public bool stunned;
    public float routine;
    public float chronometer;
    public Quaternion angle;

    public float grade;

    public GameObject arma;

    public AudioSource seeYou;

    public AudioSource enemyAttack;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        target = GameObject.Find("PrincipalCharacter");
    }

    public void ColliderWeaponTrue()
    {
        arma.GetComponent<BoxCollider>().enabled = true;
    }

    public void ColliderWeaponfalse()
    {
        arma.GetComponent<BoxCollider>().enabled = false;
    }

    void Update()
    {
        Behavior_Enemy();
    }

    void Behavior_Enemy()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 20)
        {

            seeYou.Play();
            anim.SetBool("run", false);
            chronometer += 1 * Time.deltaTime;

            if (chronometer >= 4)
            {
                routine = Random.Range(0, 2);
                chronometer = 0;
            }
            switch (routine)
            {
                case 0:
                    anim.SetBool("walk", false);
                    break;

                case 1:
                    grade = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, grade, 0);
                    routine++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim.SetBool("walk", true);
                    break;
            }
        }
        else
        {

                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);

            if (Vector3.Distance(transform.position, target.transform.position) > 1f && !attack)
            {

                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                anim.SetBool("walk", false);
                anim.SetBool("run", true);
                transform.Translate(Vector3.forward * 5 * Time.deltaTime);

                anim.SetBool("attack", false);
            }
            else
            {
                if(!stunned && !attack){
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);   
                anim.SetBool("walk", false);
                anim.SetBool("run", false);
                }
                
            }
        }
    }

    public void Stop_Attack(){
        anim.SetBool("attack", false);
        attack = false;
        stunned = false;
        range.GetComponent<CapsuleCollider>().enabled = true;
    }

}