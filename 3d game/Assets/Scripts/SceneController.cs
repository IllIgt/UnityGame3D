using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject simpleEnemyPrefab;
    private GameObject _enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(simpleEnemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 359);
            _enemy.transform.Rotate(0, angle, 0);
        }

    }
}
