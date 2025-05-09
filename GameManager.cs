using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance {get; private set;}

    void Awake(){
        if(Instance != null && Instance != this){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        
    }



}
