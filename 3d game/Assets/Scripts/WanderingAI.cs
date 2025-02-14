using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    private bool _alive;
    
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    public float raySphereRadius = 0.75f;
    public float bulletSpeed = 1.5f;
    public int rotationAngleMin = -110;
    public int rotationAngleMax = 110;


    void Start()
    {
        _alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, raySphereRadius, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * bulletSpeed);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(rotationAngleMin, rotationAngleMax);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool isAlive)
    {
        _alive = isAlive;
    }
}
