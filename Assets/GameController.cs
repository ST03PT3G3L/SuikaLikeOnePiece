using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Vector3 mousePosition;
    [SerializeField] List<GameObject> fruits;
    [SerializeField] Image nextFruitIcon;

    GameObject fruitNow;
    GameObject nextFruit;

    int rand = 0;

    [SerializeField] float spawnHeight;
    // Start is called before the first frame update
    void Start()
    {
        nextFruit = fruits[0];
        StartCoroutine(SpawnFruit());
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (fruitNow != null)
        {
            Vector3 p = fruitNow.transform.position;
            p.x = mousePosition.x;
            fruitNow.transform.position = p;


            if (fruitNow.transform.position.x < -3.4)
            {
                fruitNow.transform.position = new Vector3(-3.4f, fruitNow.transform.position.y);
            }

            if (fruitNow.transform.position.x > 3.4)
            {
                fruitNow.transform.position = new Vector3(3.4f, fruitNow.transform.position.y);
            }

            if (Input.GetMouseButtonDown(0))
            {
                fruitNow.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
                fruitNow = null;
                StartCoroutine(SpawnFruit());
            }
        }
    }

    IEnumerator SpawnFruit()
    {
        yield return new WaitForSeconds(1);
        fruitNow = Instantiate(nextFruit, new Vector3(0, spawnHeight, 0), Quaternion.identity);
        fruitNow.GetComponent<Rigidbody2D>().gravityScale = 0;
        ChooseNextFruit();
    }

    void ChooseNextFruit()
    {
        int rand = Random.Range(0, fruits.Count - 1);
        nextFruit = fruits[rand];
        nextFruitIcon.sprite = nextFruit.gameObject.GetComponent<SpriteRenderer>().sprite;
    }
}
