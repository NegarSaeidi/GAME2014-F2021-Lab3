using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    public float randomSpeed;
    public Bounds movementBounds;
    public Bounds boundary;
    public float startingPoint;
    public int frameDelay;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    public BulletManager bManager;
    // Start is called before the first frame update
    void Start()
    {
        randomSpeed = Random.Range(movementBounds.min, movementBounds.max);
        startingPoint = Random.Range(boundary.min, boundary.max);
        bManager = GameObject.FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, randomSpeed)+startingPoint, transform.position.y);

    }
    private void FixedUpdate()
    {
        if(Time.frameCount % frameDelay ==0)
        {
         
            var tempBullet = Instantiate(bulletPrefab);
            tempBullet.transform.position = bulletSpawn.position;
            bManager.getBullet(bulletSpawn.position);
        }
    }
}
