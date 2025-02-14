using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public float speed = 10.0f;

    public int damage = 1;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider otherObject)
    {
        PlayerCharacter player = otherObject.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Heart(damage);
        }

        Destroy(this.gameObject);
    }
}