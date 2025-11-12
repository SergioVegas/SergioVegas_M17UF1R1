using UnityEngine;

[RequireComponent(typeof(PatrolBehavior))]
public class Enemy : MonoBehaviour
{
    protected PatrolBehavior _pb;

    private void Awake()
    { 
        _pb = GetComponent<PatrolBehavior>();
    }

    
    void Update()
    {
        
    }
}
