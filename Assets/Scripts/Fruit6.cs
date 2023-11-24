using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit6 : MonoBehaviour
{
    public GameObject fruitPrefab;
    public GameObject sprite;
    public bool hasCollided = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Fruit6 fruit = collision.gameObject.GetComponent<Fruit6>();
        if(fruit != null)
        {
            if (fruit.hasCollided == false)
            {
                hasCollided = true;
                float newX = (collision.transform.position.x + this.transform.position.x) / 2;
                float newY = (collision.transform.position.y + this.transform.position.y) / 2;
                Instantiate(fruitPrefab, new Vector3(newX, newY, 0), Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
