using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fruit", menuName = "ScriptableObjects/Create Fruit", order = 1)]
public class Fruit : ScriptableObject
{
    int fruitId;
    string fruitName;
    Sprite fruitIcon;
}
