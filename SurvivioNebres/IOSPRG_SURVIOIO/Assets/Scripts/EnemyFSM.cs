using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{       
    Idle,
    Move,
    Chase,
    Attack
}

public class EnemyFSM : MonoBehaviour
{
    [SerializeField] State currentState;
    [SerializeField] State previousState;
    Vector3 destinationPoint = Vector3.zero;
    float speed = 3;
    float minWaitTime = 3;
    float maxWaitTime = 5;
    float waitTime;
    float timeTick;
    public Transform Target { get; set; }
    float chaseDist = 6;
    float chaseSpeed = 4.5f;

    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform firePoint; // Point from where the bullet will be fired
    public float shootingCooldown = 1f; // Time between shots
    private float lastShotTime;

    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Idle;
        waitTime = Random.Range(minWaitTime, maxWaitTime);
        timeTick = 0;
        lastShotTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState) 
        {
            case State.Idle: IdleUpdate(); break;
            case State.Move: MoveUpdate(); break;
            case State.Chase: ChaseUpdate(); break;
            case State.Attack: AttackUpdate(); break;
        }
    }

    void IdleUpdate()
    {
        if (Target != null) 
        {
            timeTick = 0;
            ChangeState(State.Chase);
            return;
        }

        timeTick += Time.deltaTime;
        if (timeTick > waitTime)
        {
            timeTick = 0;
            waitTime = Random.Range(minWaitTime, maxWaitTime);
            ChangeState(State.Move);
        }
    }

    void MoveUpdate()
    {
        if (Target != null) 
        {
            ChangeState(State.Chase);
            return;
        }

        if (destinationPoint == Vector3.zero) 
        {
            destinationPoint = new Vector3(Random.Range(-19, 19), Random.Range(-19, 19), 0); 
        }

        float step = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, destinationPoint, step);

        if (Vector3.Distance(transform.position, destinationPoint) <= 0.1f) 
        {
            destinationPoint = Vector3.zero;
            ChangeState(State.Idle);
        }
    }

    void ChaseUpdate() 
{
    if (Target == null)
    {
        ChangeState(previousState);
        return;
    }

    RotateTowards(Target.position);

    float step = chaseSpeed * Time.deltaTime;
    this.transform.position = Vector3.MoveTowards(this.transform.position, Target.position, step);

    // Check if within chase distance
    if (Vector3.Distance(transform.position, Target.position) <= chaseDist)
    {
        ChangeState(State.Attack); 
    }
    else
    {
        
        ChangeState(State.Idle); 
    }
}

void AttackUpdate()
{
    if (Target == null)
    {
        ChangeState(previousState);
        return;
    }

    RotateTowards(Target.position);

    if (Vector3.Distance(transform.position, Target.position) > chaseDist)
    {
        // If the target moves out of attack range, go back to Idle or Move state
        ChangeState(State.Move); 
        return;
    }

    if (Time.time >= lastShotTime + shootingCooldown)
    {
        Shoot();
        lastShotTime = Time.time; 
    }
}

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Instantiate the bullet and set its direction towards the target
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>(); // Get the Bullet script
            if (bulletScript != null)
            {
                bulletScript.SetTarget(Target); // Set the target for the bullet
            }
        }
    }

    void RotateTowards(Vector3 targetPosition)
    {
       
        Vector3 direction = targetPosition - transform.position;
        direction.z = 0; 
        if (direction != Vector3.zero) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.deltaTime); // Rotate smoothly towards the target
        }
    }


    void ChangeState(State state) 
    {
        if (currentState == state) 
            return;

        previousState = currentState;
        currentState = state;
    }
}
