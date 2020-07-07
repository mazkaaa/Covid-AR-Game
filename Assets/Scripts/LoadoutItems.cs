using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "Loadout/Items", order = 1)]
public class LoadoutItems : ScriptableObject
{
    public string weaponName;
    public float damage;
    public bool owned;
    public bool equipped;
    public int price;
    
    [Range (5.0f, 20.0f)]
    public float sprayArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
