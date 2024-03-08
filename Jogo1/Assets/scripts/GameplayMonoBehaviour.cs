using UnityEngine;

public abstract class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private bool pausable;
    
    private bool initialized = false;


    protected void Awake()
    {
        if (!pausable) return;
        

    }

}
