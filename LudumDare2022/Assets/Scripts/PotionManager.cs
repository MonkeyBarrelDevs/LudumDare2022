using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    [SerializeField] List<Potion> selectablePotions;
    [SerializeField] GameObject potionLayoutGroup;
    [SerializeField] GameObject potionInventoryLayout;
    [SerializeField] Button potionButtonPrefab;
    [SerializeField] int maxPotions = 3;
    private List<Potion> usablePotions = new();
    private List<Potion> activePotions = new();

    void Start()
    {
        for(int i = 0; i < selectablePotions.Count; i++)
        {
            int index = i;
            Button button = Instantiate(potionButtonPrefab, potionLayoutGroup.transform);
            button.gameObject.GetComponent<Image>().sprite = selectablePotions[index].ItemSprite;
            button.onClick.AddListener(delegate{AddUsablePotion(index);});
        }
    }

    private void ApplyNextEffect()
    {
        Potion potion = usablePotions[0];
        potion.ApplyEffect();
        activePotions.Add(potion);
        usablePotions.Remove(potion);
    }

    private void RemoveNextEffect()
    {
        Potion potion = selectablePotions[0];
        potion.RemoveEffect();
        activePotions.Remove(potion);
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
            button.onClick.AddListener(delegate{RemoveUsablePotion(button);});
        }
    }

    private void RemoveUsablePotion(Button button)
    {
        if(GameController.instance.GameState == GameStates.PlatformState)
            return;
        int siblingIndex = button.transform.GetSiblingIndex();
        Debug.Log(siblingIndex);
        usablePotions.RemoveAt(siblingIndex);

        //Remove potion to player inventory UI
        Destroy(button.gameObject);
    }
}
