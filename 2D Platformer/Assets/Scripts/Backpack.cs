using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField]
    public int _backpackSpace = 3;
    [SerializeField]
    public int _currentBackpackItems;
    public List<GameObject> pets = new List<GameObject>();
    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update()
    {
        if (pets.Count == 1)
        {
            foreach (var GameObject in pets)
            {

            }
        }
    }
}
