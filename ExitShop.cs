using UnityEngine;

public class ExitShop : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void ExitShopMenu()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.PickingNode);
    }
    

}
