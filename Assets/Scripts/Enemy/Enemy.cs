using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public Animator anim;
    public GameObject target;
    public EnemyRange range;

    public NavMeshAgent agent;
    public float attackDistance;
    public float radioVision;
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
        agent = GetComponent<NavMeshAgent>();
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
        if (Vector3.Distance(transform.position, target.transform.position) > radioVision)
        {
            agent.isStopped = true;
            seeYou.Play();
            anim.SetBool("run", false);
            chronometer += Time.deltaTime;

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
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 180.0f * Time.deltaTime);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim.SetBool("walk", true);
                    break;

                case 3:
                    routine = 0;
                    break;
            }
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(target.transform.position);

            if (Vector3.Distance(transform.position, target.transform.position) > attackDistance && !attack)
            {
                anim.SetBool("walk", false);
                anim.SetBool("run", true);
            }
            else
            {
                if (!attack)
                {
                    anim.SetBool("walk", true);
                    anim.SetBool("run", false);
                }
            }
        }

        if (attack)
        {
            agent.isStopped = true;
        }
    }

    public void Stop_Attack()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > attackDistance + 0.2f)
        {
            anim.SetBool("attack", false);
        }
        attack = false;
        stunned = false;
        range.GetComponent<CapsuleCollider>().enabled = true;
    }

}