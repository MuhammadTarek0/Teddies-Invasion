using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySettingsScript : MonoBehaviour
{
    [Space]
    [Header("Enemy Settings")]
    private Transform Target;
    public Transform toyBoxTransform;
    public Transform playerTransform;
    public Transform lightTransform;
    public float chasingSpeed;
    public float rotationSpeed;
    public float diePoint;
    public float triggerZone;
    public float attackDamage;
    public enum enemies { Crawling, Destructor, Lightman, TheBigOne}
    public enemies type;
    private float chasingStep;
    private float rotationStep;
    private float health;
    Animator myAnim;

    string walk;
    string idle;
    string die;
    string punch;
    bool objectIsHitable;
    public bool IsLighOn = false;
    public bool hitting = false;

    Vector3 targetDir;
    public Vector3 newDir;

    bool isHit = false;
    List<GameObject> baseList;

    //Setters and Getters for the targets
    public void SetToyBoxTransform(Transform transform)
    {
        toyBoxTransform = transform;
    }
    public Transform GetToyBoxTransform()
    {
        return toyBoxTransform;
    }
    public void SetPlayerTransform(Transform transform)
    {
        playerTransform = transform;
    }
    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }
    public void SetLightTransform(Transform transform)
    {
        lightTransform = transform;
    }
    public Transform GetLightTransform()
    {
        return lightTransform;
    }

    void Start()
    {
        myAnim = GetComponentInChildren<Animator>();
        if (myAnim == null)
        {
            Debug.LogError("No Anim found please check your input settings:::NO GRAPHICS WILL APPEAR.");
        }

        switch (type)
        {
            case enemies.Crawling:
                {
                    health = 20f;
                    walk = "Walking";
                    idle = "Idle";
                    punch = "RightHook";
                    die = "Falling Back Death";
                    //chasingSpeed = 4f;
                    //rotationSpeed = 5f;
                    //diePoint = 5f;
                    //triggerZone = 25f;
                    //attackDamage = 5f;
                }
                break;
            case enemies.Destructor:
                {
                    health = 70f;
                    walk = "ZombieWalk";
                    idle = "Idle";
                    punch = "Right Hook";
                    die = "Zombie Dying";
                    //chasingSpeed = 7f;
                    //rotationSpeed = 5f;
                    //diePoint = 5f;
                    //triggerZone = 25f;
                    //attackDamage = 12f;
                }
                break;
            case enemies.Lightman:
                {
                    health = 50f;
                    walk = "Walking";
                    idle = "Idle";
                    punch = "Zombie Attack";
                    die = "Falling Forward Death";
                    //chasingSpeed = 20f;
                    //rotationSpeed = 5f;
                    //diePoint = 5f;
                    //triggerZone = 25f;
                    //attackDamage = 3f;
                }
                break;
            case enemies.TheBigOne:
                {
                    health = 150f;
                    walk = "cutewalk";
                    idle = "Idle";
                    punch = "Standing Melee Attack Horizontal";
                    die = "Dying Backwards";
                    //chasingSpeed = 4f;
                    //rotationSpeed = 5f;
                    //diePoint = 5f;
                    //triggerZone = 30f;
                    //attackDamage = 20f;
                }
                break;
        }
        
        myAnim.Play(idle);

        Debug.Log("Type: " + type.ToString() + " Health: " + health);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLighOn)
        {
            Target = lightTransform;
        }
        else if (Vector3.Distance(transform.position, playerTransform.position) < triggerZone)
        {
            Target = playerTransform;
        }
        else
        {
            Target = toyBoxTransform;
        }

        if (Target.tag == "Base" || Target.tag == "Player")
        {
            objectIsHitable = true;
        }
        else
        {
            objectIsHitable = false;
        }
        
        if (!isHit)
        {
            if ((Vector3.Distance(transform.position, Target.position) < diePoint && objectIsHitable) || hitting)
            {
                Debug.Log("Supposed to be punched now");
                Hitting();
            }
            else
            {
                myAnim.Play(walk);
                chasingStep = chasingSpeed * Time.deltaTime;
                var targget = new Vector3(Target.position.x, Target.position.y,transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, Target.position, chasingStep);
            }

            rotationStep = rotationSpeed * Time.deltaTime;
            targetDir = Target.position - transform.position;
            newDir = Vector3.RotateTowards(transform.forward, targetDir, rotationStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }

    public void GotMeMF(float damage)
    {
        isHit = true;

        if (health <= 0)
        {
            Debug.Log(type.ToString() + " has died mf...");
            myAnim.Play(die);
            StartCoroutine(Die());
            
        }
        else
        {
            Debug.Log(type.ToString() + " got a hit...");
            myAnim.Play(punch);
            health -= damage;
            StartCoroutine(GettingDamage());

            if (type == enemies.Destructor && health <= 15)
            {
                walk = "zombiecrawl";
                punch = walk;
            }
        }

    }
    public void Hitting()
    {
        isHit = true;
        StartCoroutine(Punch(Target));
        Debug.Log("Die bitch");
        Debug.Log(type + "has attacked you...");
    }
    IEnumerator EnemyTimer(string x)
    {
        yield return new WaitForSeconds(2.5f);
        GetComponentInChildren<Animator>().Play(x);
    }
    IEnumerator Delay(float seconds)
    {
        isHit = true;
        yield return new WaitForSeconds(seconds);
        isHit = false;
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }
    IEnumerator Punch(Transform x)
    {
        myAnim.Play(punch);
        yield return new WaitForSeconds(1f);
        if (x.tag == "Player")
        {
        FindObjectOfType<PlayerFPS>().TakingDamage((int)attackDamage);
        }
        else
        {
            FindObjectOfType<ToyBoxScript>().TakingDamage((int)attackDamage);
        }
        isHit = false;
    }
    IEnumerator GettingDamage()
    {
        yield return new WaitForSeconds(1f);
        isHit = false;
        Debug.Log(type.ToString() + " health " + health.ToString());

    }

}
