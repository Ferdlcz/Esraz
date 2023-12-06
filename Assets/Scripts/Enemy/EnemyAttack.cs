using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject enemigo;
    public float damage;
    public GameObject Player;

    private int stunCount = 0;

    void OnTriggerEnter(Collider coll)
    {
        if (stunCount >= 3)
            return;

        if (coll.CompareTag("PJ"))
        {
            Player.GetComponent<PlayerHealth>().HealthPlayer -= damage;
            print("Daño");
        }

        if (coll.CompareTag("Block Attack"))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            print("Bloqueo");
        }

        if (coll.CompareTag("parry"))
        {
            stunCount++;
            enemigo.GetComponent<Enemy>().stunned = true;
            enemigo.GetComponent<Animator>().SetBool("stun", true);
            gameObject.GetComponent<BoxCollider>().enabled = false;

            if (stunCount >= 3)
            {
                Invoke("DestroyEnemy", 1.8f);
                Invoke("RespawnEnemy", 120.0f);
            }
        }
    }

    void DestroyEnemy(){
        enemigo.gameObject.SetActive(false);
        Debug.Log("enemigo destruido");
    }

    void RespawnEnemy(){
        enemigo.gameObject.SetActive(true);
        Debug.Log("Enemigo Respawneado");
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
