using UnityEngine;
using UnityEngine.UI;
public class CombatRewards : MonoBehaviour
{
    
    public Button getHeroButton;
    public Button getItemButton;
    
    
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        getHeroButton.onClick.AddListener(generateHeroReward);
        getItemButton.onClick.AddListener(generateItemRewards);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void generateItemRewards(){

    }

    public void generateHeroReward(){

    }



}
