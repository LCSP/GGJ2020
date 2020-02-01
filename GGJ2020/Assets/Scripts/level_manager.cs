using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_manager : MonoBehaviour
{

    public static level_manager INSTANCE;

    public List<GameObject> levels;
    

    private void Awake()
    {
        INSTANCE = this;
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
