using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    [SerializeField] List<Potion> selectablePotions;
    [SerializeField] GameObject potionLayoutGroup;
    [SerializeField] Button potionButtonPrefab;
    private List<Potion> usablePotions = new();
    private List<Potion> activePotions = new();

    void Start()
    {
        for(int i = 0; i < selectablePotions.Count; i++)
        {
            int index = i;
            Debug.Log(selectablePotions[index].name);
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
        Potion potion = selectablePotions[index];
        usablePotions.Add(potion);
        //Add potion to player inventory UI
    }

    private void RemoveUsablePotion(int index)
    {
        Potion potion = selectablePotions[index];
        usablePotions.Remove(potion);
        //Remove potion to player inventory UI
    }
}
