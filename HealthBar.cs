using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public UnityEngine.UI.Image fillImage;
    public IFighter fighter;


    public void SetFighter(IFighter f){
        fighter = f;
    }

    
    
    void Update()
    {
        
        
        if(fighter != null){
            fillImage.fillAmount = (float)fighter._currentLife/ fighter.life;
            
            
        }
    }
}
