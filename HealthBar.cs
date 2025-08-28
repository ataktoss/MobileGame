//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
//using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public UnityEngine.UI.Image fillImage;
    public Fighter fighter;


    public void SetFighter(Fighter f){
        fighter = f;
    }

    
    
    void Update()
    {
        
        
        if(fighter != null){
            if (fighter.life > 0)
            {
                fillImage.fillAmount = (float)fighter._currentLife/ fighter.life;
            }
            
            
            
        }
    }
}
