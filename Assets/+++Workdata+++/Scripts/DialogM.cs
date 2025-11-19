using System;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.InputSystem;
public class DialogM : MonoBehaviour
{
    [SerializeField] private TextAsset inkAsset;
    [SerializeField] private GameObject DialougeBox;
    [SerializeField] public TMP_Text dialougeText;
    
    [SerializeField] private GameObject ChoiceOneButton;
    [SerializeField] private GameObject ChoiceTwoButton;
    [SerializeField] private GameObject ChoiceThreeButton;
    [SerializeField] private GameObject ChoiceFourButton;
    
    [SerializeField] public TMP_Text choiceOneText;
    [SerializeField] public TMP_Text choiceTwoText;
    [SerializeField] public TMP_Text choiceThreeText;
    [SerializeField] public TMP_Text choiceFourText;
    private Story inkStory;
    

    private void Awake()
    {
        inkStory = new Story(inkAsset.text);
    }

    private void Start()
    {
        DialougeBox.SetActive(false);
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            InkStoryContinue();
        }  
    }

    public void ChoiceOne()
    {
        SelectInkChoice(0);
    }
    public void ChoiceTwo()
    {
        SelectInkChoice(1);
    }
    public void ChoiceThree()
    {
        SelectInkChoice(2);
    }
    public void ChoiceFour()
    {
        SelectInkChoice(3);
    }
    
    
    
    void InkStoryContinue()
    {
        if (inkStory.canContinue && DialougeBox.activeSelf == true)
        {
            dialougeText.text = inkStory.Continue();
        }

        if (inkStory.currentChoices.Count > 0)
        {
            ChoiceOneButton.SetActive(true);
            ChoiceTwoButton.SetActive(true);
            ChoiceThreeButton.SetActive(true);
            ChoiceFourButton.SetActive(true);
            for (int i = 0; i < inkStory.currentChoices.Count; i++)
            {
                Choice currentChoice = inkStory.currentChoices[i];
                if (i == 0)
                {
                    choiceOneText.text = currentChoice.text;
                }

                if (i == 1)
                {
                    choiceTwoText.text = currentChoice.text;
                }

                if (i == 2)
                {
                    choiceThreeText.text = currentChoice.text;
                }

                if (i == 3)
                {
                    choiceFourText.text = currentChoice.text;
                }
            }
        }
        else
        {
            ChoiceOneButton.SetActive(false);
            ChoiceTwoButton.SetActive(false);
            ChoiceThreeButton.SetActive(false);
            ChoiceFourButton.SetActive(false);
        }
       
    }

    void SelectInkChoice(int choiceIndex)
    {
        if (inkStory.currentChoices.Count > 0)
        {
            inkStory.ChooseChoiceIndex(choiceIndex);
            InkStoryContinue();
        }
    }
    
    
    
    
    
    
}
