using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Console;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    public enum MonsterState {idle,trace,attack,die};
    public MonsterState monsterState = MonsterState.idle;

    private Transform monsterTr;
    private Transform playerTr;
    private NavMeshAgent nvAgent;
    private Animator animator;
    // Start is called before the first frame update

    public float traceDist = 50.0f;
    public float attackDist = 10.0f;
    private bool isDie = false;

    private int hp = 100;
    void Start()
    {
        monsterTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Me").GetComponent <Transform> ();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();

        StartCoroutine(this.CheckMonsterState());
        StartCoroutine(this.MonsterAction());
        //nvAgent.destination = playerTr.position;
    }

    // Update is called once per frame
    IEnumerator CheckMonsterState() {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(playerTr.position, monsterTr.position);

            if (dist <= attackDist && !FindObjectOfType<GameManager>().isGameOver)
            {
                monsterState = MonsterState.attack;
            }
            else if (dist <= traceDist)
            {
                monsterState = MonsterState.trace;
            }
            else
            {
                monsterState = MonsterState.idle;
            }
        }
    }

    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (monsterState)
            {
                case MonsterState.idle:
                    nvAgent.isStopped = true;
                    animator.SetBool("IsTrace", false);
                    break;
                case MonsterState.trace:
                    nvAgent.destination = playerTr.position;
                    nvAgent.isStopped = false;
                    animator.SetBool("IsAttack", false);
                    animator.SetBool("IsTrace", true);
                    break;

                case MonsterState.attack:
                    nvAgent.isStopped = true;
                    animator.SetBool("IsAttack", true);
                    break;
            }
            yield return null;
        }
    }
    public void GetDamage(float amounnt)
    {
        hp -= (int)(amounnt / 2.0f);
        if(hp<=0)
        {
            MonsterDie();
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            GetDamage(10.0f);
        }
    }*/
    void MonsterDie()
    {
        if (isDie == true) return;
        StopAllCoroutines();
        isDie = true;
        monsterState = MonsterState.die;
        nvAgent.isStopped = true;
        animator.SetTrigger("IsDie");

        gameObject.GetComponentInChildren<CapsuleCollider>().enabled = false;
        foreach(Collider coll in gameObject.GetComponentsInChildren<SphereCollider>())
        {
            coll.enabled = false;
        }
        //FindObjectOfType<GameManager>().GetScored(2);
            }
       

}
