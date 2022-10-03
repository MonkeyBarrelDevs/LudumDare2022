using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    public static PotionManager instance;
    [SerializeField] List<Potion> selectablePotions;
    [SerializeField] GameObject potionLayoutGroup;
    [SerializeField] GameObject potionInventoryLayout;
    [SerializeField] Button potionButtonPrefab;
    [SerializeField] int maxPotions = 3;
    public List<Potion> usablePotions = new();
    public List<Potion> activePotions = new();
    private string[] SelectPotionSounds;
    private string[] DrinkPotionSounds;
    private string[] DeselectPotionSounds;

    void Awake()
    {
        instance = this;
        SelectPotionSounds = new string[3] {"Select Potion 1", "Select Potion 2", "Select Potion 3" };
        DeselectPotionSounds = new string[3] { "Deselect 1", "Deselect 2", "Deselect 3" };
        DrinkPotionSounds = new string[4] { "Drink 1", "Drink 2", "Drink 3", "Drink 4" };
        
    }

    void Start()
    {
        for (int i = 0; i < selectablePotions.Count; i++)
        {
            int index = i;
            Button button = Instantiate(potionButtonPrefab, potionLayoutGroup.transform);
            button.gameObject.GetComponent<Image>().sprite = selectablePotions[index].ItemSprite;
            button.onClick.AddListener(delegate { AddUsablePotion(index); });
        }
    }

    public void ApplyNextEffect()
    {
        if (usablePotions.Count > 0)
        { 
            Potion potion = usablePotions[0];
            potion.ApplyEffect();
            activePotions.Add(potion);
            usablePotions.Remove(potion);
            Destroy(potionInventoryLayout.transform.GetChild(0).gameObject);
            AudioManager.instance.PlayRandom(DrinkPotionSounds);
        }
    }
    public void RemoveNextEffect()
    {
        Potion potion = selectablePotions[0];
        potion.RemoveEffect();
        activePotions.Remove(potion);

    }

    public void RemoveAllEffects()
    {
        foreach (Potion potion in activePotions){
            potion.RemoveEffect();
        }
        activePotions = new();
    }

    private void AddUsablePotion(int index)
    {
        if(GameController.instance.GameState == GameStates.PlatformState)
            return;
        if(usablePotions.Count < maxPotions)
        {
            Potion potion = selectablePotions[index];
            usablePotions.Add(potion);
            Button button = Instantiate(potionButtonPrefab, potionInventoryLayout.transform);
            button.image.sprite = potion.ItemSprite;
            button.onClick.AddListener(delegate{RemoveUsablePotion(button);});
            AudioManager.instance.PlayRandom(SelectPotionSounds);
        }
    }

    private void RemoveUsablePotion(Button button)
    {
        if(GameController.instance.GameState == GameStates.PlatformState)
           return;
        int siblingIndex = button.transform.GetSiblingIndex();
        usablePotions.RemoveAt(siblingIndex);
        AudioManager.instance.PlayRandom(DeselectPotionSounds);
        Destroy(button.gameObject);

    }
}
