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
    
    public void SetLevel(int index)
    {

    }
}
