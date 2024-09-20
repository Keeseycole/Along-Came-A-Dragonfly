
using System.Collections;

using UnityEngine;





public class BattleNpcMove : Enemy, ITeam
{
    private Animator anim;

    public bool shouldRotate;

    public Creature creature;

    public float checkRadius, attackRadius;

    public float speed;

     [SerializeField] GameObject target;

    Vector3 dir;

    public bool  isInAttackRange;

    // Start is called before the first frame update

    [SerializeField] Teams curTeam;



    // Refrences

    public Teams CurrentTeam { get => curTeam; }

   

    public GameObject getGameObject => gameObject;

   protected  void Start()
    {
        currentState = EnemyStates.idle;
        creature = GetComponentInParent<Party>().creatures[0];
    }

    // Update is called once per frame
    protected  void Update()
    {
      
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();

        if (target == null)
        {

            FindTarget();

           
        } else
        {

            isInAttackRange = (Vector2.Distance(transform.position, target.transform.position) <= attackRadius);

            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            if (isInAttackRange == true)
            {  
                speed = 0;
               ChangeState(EnemyStates.attack);


              
                // StartCoroutine(Damage());

            } else if(!isInAttackRange)
            {
                speed = 3;
                StopCoroutine(Damage());
            }
           

        }      
 
        if (creature.HP == 0)
        {
            Destroy(this.gameObject);
        }

    }

    private IEnumerator Damage()
    {
        yield return new WaitForSeconds(5f);
        creature.DecreaseHP(creature.MaxHP/creature.HP);
        
    }

    public void FindTarget()
    {
        Collider2D[] potenTar = Physics2D.OverlapCircleAll(transform.position, checkRadius);
      

        foreach (Collider2D potenEnemy in potenTar)
        {
            ITeam tempCollidable = potenEnemy.GetComponent<ITeam>();

           
            if (tempCollidable != null)
            {
             if(tempCollidable.CurrentTeam == curTeam)
                {
                    continue;
                } 
                    GameObject potentailTar = tempCollidable.getGameObject;

                if (target != null)
                {

                    float disA = Vector2.Distance(transform.position, target.transform.position);
                    float disB = Vector2.Distance(transform.position, potentailTar.transform.position);
                   
                    if (disA <= disB)
                    {
                      
                        continue;
                    }
                }
                if (currentState == EnemyStates.walk || currentState == EnemyStates.idle)
                {
                    ChangeAnim(dir);
                    ChangeState(EnemyStates.walk);
                }
                target = potentailTar;
                StartCoroutine(Attack());
            }
        }

    }

    private void ChangeAnim(Vector2 dir)
    {
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0)
            {
                SetAnimFloat(Vector2.right);
            } else if (dir.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
            else if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y))
            {
                if (dir.y > 0)
                {
                    SetAnimFloat(Vector2.up);
                }
                else if (dir.y < 0)
                {
                    SetAnimFloat(Vector2.down);
                }
            }

        }
       
    }

    private void SetAnimFloat(Vector2 setVec)
    {
        anim.SetFloat("MoveX", setVec.x);
        anim.SetFloat("MoveY", setVec.y);
    }

    private void ChangeState(EnemyStates newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }

    public IEnumerator Attack()
    {
        currentState = EnemyStates.attack;
        anim.SetBool("Attack", true);
       yield return new WaitForSeconds(1f);
        //currentState = EnemyStates.walk;
       // anim.SetBool("Attack", false);
    }

  
}
