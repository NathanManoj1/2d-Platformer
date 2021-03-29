using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField]
    public int _backpackSpace = 3;
    [SerializeField]
    public int _currentBackpackItems;
    public List<Crawler> pets = new List<Crawler>();
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        MoveCurrentObjectToMouse();
    }
    private void MoveCurrentObjectToMouse()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0);
        {
            if (hitData && Input.GetMouseButtonDown(0))
            {
                foreach (var crawler in pets)
                {
                    crawler.MoveTowards(hitData.point);
                }
            }


        }
    }
}
