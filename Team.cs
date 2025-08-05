using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Team : MonoBehaviour
{


    public GameObject heroHolder1, heroHolder2, heroHolder3;
    public TMP_Text heroname1, heroName2, heroName3;
    public Button hero1Passive1, hero1Passive2, hero2Passive1, hero2Passive2, hero3Passive1, hero3Passive2;
    public Image hero1Passive1Icon, hero1Passive2Icon, hero2Passive1Icon, hero2Passive2Icon, hero3Passive1Icon, hero3Passive2Icon;
    public TMP_Text hero1Passive1Text, hero1Passive2Text, hero2Passive1Text, hero2Passive2Text, hero3Passive1Text, hero3Passive2Text;
    public Button hero1Spell, hero2Spell, hero3Spell;
    public TMP_Text hero1SpellText, hero2SpellText, hero3SpellText;
    // public Button hero1Relic1, hero1Relic2, hero1Relic3, hero1Relic4, hero1Relic5, hero1Relic6, hero1Relic7, hero1Relic8;
    // public Button hero2Relic1, hero2Relic2, hero3Relic3, hero4Relic4, hero5Relic5, hero6Relic6, hero7Relic7, hero8Relic8;
    public List<TMP_Text> hero1Relics;
    private bool showingHeroes = false;
    public GameObject InventoryObj;
    public List<Passive> passiveList;
    

    // REMAKE WHOLE THING MORE ORGANIZED 
    public void GetHeroes()
    {
        List<HeroRuntimeData> heroesData = CombatManager.Instance.GetCurrentTeamInfo();
        if (heroesData[0] != null)
        {
            showingHeroes = true;
            heroHolder1.SetActive(true);
            GameObject heroInstance = Instantiate(heroesData[0].prefab);
            Fighter fighterRef = heroInstance.GetComponent<Fighter>();
            heroname1.text = fighterRef.unitName;
            hero1Passive1Text.text = fighterRef.passives[0].passiveName;
            hero1Passive1Icon.sprite = fighterRef.passives[0].icon;
            hero1SpellText.text = fighterRef.fighterSpell.name;
            for (int i = 0; i < heroesData[0].equippedItems.Count; i++)
            {
                hero1Relics[i].text = heroesData[0].equippedItems[i].itemName;
            }
            Destroy(heroInstance);
        }
        if (heroesData.Count > 1 && heroesData[1] != null)
        {
            heroHolder2.SetActive(true);
            GameObject heroInstance2 = Instantiate(heroesData[1].prefab);
            Fighter fighterRef2 = heroInstance2.GetComponent<Fighter>();
            heroName2.text = fighterRef2.unitName;
            hero2Passive1Text.text = fighterRef2.passives[0].passiveName;
            hero2SpellText.text = fighterRef2.fighterSpell.name;
            Destroy(heroInstance2);
        }
        if (heroesData.Count > 2 && heroesData[2] != null)
        {
            heroHolder3.SetActive(true);
            GameObject heroInstance3 = Instantiate(heroesData[2].prefab);
            Fighter fighterRef3 = heroInstance3.GetComponent<Fighter>();
            heroName3.text = fighterRef3.unitName;
            hero3Passive1Text.text = fighterRef3.passives[0].passiveName;
            hero3SpellText.text = fighterRef3.fighterSpell.name;
            Destroy(heroInstance3);
        }







    }



    public void Onclick()
    {
        if (!showingHeroes)
        {
            GetHeroes();
        }
        else
        {
            showingHeroes = false;
            heroHolder1.SetActive(false);
            heroHolder2.SetActive(false);
            heroHolder3.SetActive(false);
        }
    }


}
