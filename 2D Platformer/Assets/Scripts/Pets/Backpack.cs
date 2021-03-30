using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField]
    public int _backpackSpace = 3;
    [SerializeField]
    public int _currentBackpackItems;
    public List<Pets> pets = new List<Pets>();
    void Update()
    {
            MoveCurrentObjectToMouse();
        
    }
    private void MoveCurrentObjectToMouse()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                foreach(var crawler in pets)
                {
                    crawler.GetComponent<Pets>().MoveTowards(hit.transform.position);
                }
            }
        }
         
    }
    public void ConvertToPet(Pets pet)
    {
        if(_currentBackpackItems != _backpackSpace)
        {
            pets.Add(pet);
            _currentBackpackItems++;
            
        }
    }
  
}
