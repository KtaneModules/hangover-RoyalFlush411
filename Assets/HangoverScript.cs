using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;

public class HangoverScript : MonoBehaviour
{
    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable showNoteButton;
    public KMSelectable actionButton;
    public KMSelectable ingredientButton;
    public KMSelectable actionLeftButton;
    public KMSelectable actionRightButton;
    public KMSelectable ingredientLeftButton;
    public KMSelectable ingredientRightButton;

    public TextMesh actionText;
    public String[] actionOptions;
    private int displayedActionIndex = 0;
    public TextMesh ingredientText;
    public String[] ingredientOptions;
    private int displayedIngredientIndex = 0;

    private int[] variableIndices = new int[6];
    public TextMesh[] noteText;
    public String[] drinkNoteOptions;
    public String[] sickNoteOptions;
    public String[] sleptNoteOptions;
    public String[] shotNoteOptions;
    public String[] kebabNoteOptions;
    public String[] uberNoteOptions;
    public GameObject noteToSelf;
    public GameObject recipe;
    private bool noteActive;
    public TextMesh noteToSelfText;
    [TextArea] public String[] noteToSelfOptions;

    private int stage = 0;
    public TextMesh[] recipeText;

    public List<String> correctIngredients = new List<String>();
    public List<String> ingredientsAdded = new List<String>();
    private bool correct = true;

    //Logging
    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    void Awake()
    {
        moduleId = moduleIdCounter++;
        showNoteButton.OnInteract += delegate () { ShowNoteButton(); return false; };
        actionButton.OnInteract += delegate () { PressActionButton(); return false; };
        ingredientButton.OnInteract += delegate () { PressIngredientButton(); return false; };
        actionLeftButton.OnInteract += delegate () { ActionLeft(); return false; };
        actionRightButton.OnInteract += delegate () { ActionRight(); return false; };
        ingredientLeftButton.OnInteract += delegate () { IngredientLeft(); return false; };
        ingredientRightButton.OnInteract += delegate () { IngredientRight(); return false; };
    }

    void Start()
    {
        SetScreens();
        SetNote();
        CalculateElixir();
    }

    void SetScreens()
    {
        displayedActionIndex = UnityEngine.Random.Range(0,4);
        actionText.text = actionOptions[displayedActionIndex];
        displayedIngredientIndex = UnityEngine.Random.Range(0,20);
        ingredientText.text = ingredientOptions[displayedIngredientIndex];
    }

    void SetNote()
    {
        noteToSelf.SetActive(true);
        variableIndices[0] = UnityEngine.Random.Range(0,8);
        variableIndices[1] = UnityEngine.Random.Range(0,2);
        variableIndices[2] = UnityEngine.Random.Range(0,4);
        variableIndices[3] = UnityEngine.Random.Range(0,2);
        variableIndices[4] = UnityEngine.Random.Range(0,4);
        variableIndices[5] = UnityEngine.Random.Range(0,2);

        noteText[0].text = drinkNoteOptions[variableIndices[0]];
        noteText[1].text = sickNoteOptions[variableIndices[1]];
        noteText[2].text = sleptNoteOptions[variableIndices[2]];
        noteText[3].text = shotNoteOptions[variableIndices[3]];
        noteText[4].text = kebabNoteOptions[variableIndices[4]];
        noteText[5].text = uberNoteOptions[variableIndices[5]];

        noteToSelf.SetActive(false);
        recipe.SetActive(false);
        Debug.LogFormat("[The Hangover #{0}] {1} {2} {3} {4} {5} {6} -", moduleId, noteText[0].text, noteText[1].text, noteText[2].text, noteText[3].text, noteText[4].text, noteText[5].text);
    }

    void CalculateElixir()
    {
        if(variableIndices[0] == 0)
        {
            Oreos();
        }
        else if(variableIndices[0] == 1)
        {
            Remorse();
        }
        else if(variableIndices[0] == 2)
        {
            BigMac();
        }
        else if(variableIndices[0] == 3)
        {
            Dirt();
        }
        else if(variableIndices[0] == 4)
        {
            Tea();
        }
        else if(variableIndices[0] == 5)
        {
            Lard();
        }
        else if(variableIndices[0] == 6)
        {
            Kale();
        }
        else if(variableIndices[0] == 7)
        {
            Coffee();
        }
    }

    void BaconCrisps()
    {
        if(correctIngredients.Contains(ingredientOptions[0]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[0]);
            if(variableIndices[1] == 1)
            {
                Blend();
            }
            else
            {
                RedBull();
            }
        }
    }

    void RedBull()
    {
        if(correctIngredients.Contains(ingredientOptions[1]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[1]);
            if(variableIndices[4] == 0)
            {
                Remorse();
            }
            else if(variableIndices[4] == 1)
            {
                Pizza();
            }
            else if(variableIndices[4] == 2)
            {
                Sugar();
            }
            else
            {
                BaconCrisps();
            }
        }
    }

    void Sugar()
    {
        if(correctIngredients.Contains(ingredientOptions[2]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[2]);
            if(variableIndices[1] == 1)
            {
                Pizza();
            }
            else
            {
                Tea();
            }
        }
    }

    void Pizza()
    {
        if(correctIngredients.Contains(ingredientOptions[3]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[3]);
            if(variableIndices[1] == 1)
            {
                Tea();
            }
            else
            {
                Whisk();
            }
        }
    }

    void Whisk()
    {
        if(correctIngredients.Contains(actionOptions[3]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(actionOptions[3]);
            if(variableIndices[3] == 1)
            {
                RedBull();
            }
            else
            {
                Petrol();
            }
        }
    }

    void RawEggs()
    {
        if(correctIngredients.Contains(ingredientOptions[4]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[4]);
            if(variableIndices[0] >= 5)
            {
                RedBull();
            }
            else
            {
                BaconCrisps();
            }
        }
    }

    void Oreos()
    {
        if(correctIngredients.Contains(ingredientOptions[5]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[5]);
            if(variableIndices[3] == 1)
            {
                RawEggs();
            }
            else
            {
                RedBull();
            }
        }
    }

    void Remorse()
    {
        if(correctIngredients.Contains(ingredientOptions[6]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[6]);
            if(variableIndices[5] == 0)
            {
                Oreos();
            }
            else
            {
                Sugar();
            }
        }
    }

    void Tea()
    {
        if(correctIngredients.Contains(ingredientOptions[7]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[7]);
            if(variableIndices[3] == 1)
            {
                Remorse();
            }
            else
            {
                Dirt();
            }
        }
    }

    void Petrol()
    {
        if(correctIngredients.Contains(ingredientOptions[8]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[8]);
            if(variableIndices[1] == 1)
            {
                Tea();
            }
            else
            {
                Whisk();
            }
        }
    }

    void Blend()
    {
        if(correctIngredients.Contains(actionOptions[0]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(actionOptions[0]);
            if(variableIndices[2] == 0)
            {
                Avocado();
            }
            else if(variableIndices[2] == 1)
            {
                Lard();
            }
            else if(variableIndices[2] == 2)
            {
                RawEggs();
            }
            else
            {
                Coffee();
            }
        }
    }

    void Coffee()
    {
        if(correctIngredients.Contains(ingredientOptions[9]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[9]);
            if(variableIndices[3] == 1)
            {
                Oreos();
            }
            else
            {
                Lard();
            }
        }
    }

    void Dirt()
    {
        if(correctIngredients.Contains(ingredientOptions[10]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[10]);
            if(variableIndices[2] == 0)
            {
                Tea();
            }
            else if(variableIndices[2] == 1)
            {
                Petrol();
            }
            else if(variableIndices[2] == 2)
            {
                BigMac();
            }
            else
            {
                Aspirin();
            }
        }
    }

    void Aspirin()
    {
        if(correctIngredients.Contains(ingredientOptions[11]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[11]);
            if(variableIndices[5] == 0)
            {
                Whisk();
            }
            else
            {
                Petrol();
            }
        }
    }

    void Avocado()
    {
        if(correctIngredients.Contains(ingredientOptions[12]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[12]);
            if(variableIndices[0] >= 5)
            {
                SlicedApple();
            }
            else
            {
                Stir();
            }
        }
    }

    void Lard()
    {
        if(correctIngredients.Contains(ingredientOptions[13]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[13]);
            if(variableIndices[3] == 1)
            {
                Avocado();
            }
            else
            {
                Stir();
            }
        }
    }

    void Kale()
    {
        if(correctIngredients.Contains(ingredientOptions[14]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[14]);
            Lard();
        }
    }

    void BigMac()
    {
        if(correctIngredients.Contains(ingredientOptions[15]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[15]);
            if(variableIndices[0] >= 5)
            {
                Kale();
            }
            else
            {
                Dirt();
            }
        }
    }

    void ShotOfWine()
    {
        if(correctIngredients.Contains(ingredientOptions[16]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[16]);
            if(variableIndices[3] == 1)
            {
                BigMac();
            }
            else
            {
                Aspirin();
            }
        }
    }

    void Stir()
    {
        if(correctIngredients.Contains(actionOptions[1]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(actionOptions[1]);
            if(variableIndices[5] == 0)
            {
                Lard();
            }
            else
            {
                SlicedApple();
            }
        }
    }

    void SlicedApple()
    {
        if(correctIngredients.Contains(ingredientOptions[17]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[17]);
            if(variableIndices[4] == 0)
            {
                Mayonnaise();
            }
            else if(variableIndices[4] == 1)
            {
                Lard();
            }
            else if(variableIndices[4] == 2)
            {
                Kale();
            }
            else
            {
                CookingOil();
            }
        }
    }

    void Mayonnaise()
    {
        if(correctIngredients.Contains(ingredientOptions[18]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[18]);
            if(variableIndices[5] == 0)
            {
                Kale();
            }
            else
            {
                CookingOil();
            }
        }
    }

    void CookingOil()
    {
        if(correctIngredients.Contains(ingredientOptions[19]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(ingredientOptions[19]);
            if(variableIndices[2] == 0)
            {
                ShotOfWine();
            }
            else if(variableIndices[2] == 1)
            {
                Shake();
            }
            else if(variableIndices[2] == 2)
            {
                BigMac();
            }
            else
            {
                Kale();
            }
        }
    }

    void Shake()
    {
        if(correctIngredients.Contains(actionOptions[2]))
        {
            LogIngredients();
        }
        else
        {
            correctIngredients.Add(actionOptions[2]);
            if(variableIndices[1] == 1)
            {
                BigMac();
            }
            else
            {
                ShotOfWine();
            }
        }
    }

    void LogIngredients()
    {
        Debug.LogFormat("[The Hangover #{0}] Your hangover elixir recipe is as follows: {1}.", moduleId, string.Join(", ", correctIngredients.Select((x) => x).ToArray()));
    }

    void CheckIngredients()
    {
        if(!correct)
        {
            for(int i = 0; i <= 19; i++)
            {
                recipeText[i].text = "";
                recipeText[i].text = (i+1).ToString() + ")";
            }
            Debug.LogFormat("[The Hangover #{0}] Strike! Your elixir was incorrect.", moduleId);
            GetComponent<KMBombModule>().HandleStrike();
            correct = true;
            stage = 0;
            noteActive = false;
            noteToSelf.SetActive(false);
            recipe.SetActive(false);
            noteToSelfText.text = noteToSelfOptions[0];
            ingredientsAdded.Clear();
        }
        else
        {
            Debug.LogFormat("[The Hangover #{0}] Your elixir was correct. Module disarmed.", moduleId);
            GetComponent<KMBombModule>().HandlePass();
            moduleSolved = true;
        }
    }

    public void ShowNoteButton()
    {
        if(moduleSolved)
        {
            return;
        }
        GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
        showNoteButton.AddInteractionPunch();
        if(showNoteButton.GetComponentInChildren<TextMesh>().text == noteToSelfOptions[2])
        {
            CheckIngredients();
        }
        else if(!noteActive)
        {
            noteActive = true;
            noteToSelf.SetActive(true);
            noteToSelfText.text = noteToSelfOptions[1];
        }
        else
        {
            noteActive = false;
            noteToSelf.SetActive(false);
            noteToSelfText.text = noteToSelfOptions[0];
        }
    }

    public void PressActionButton()
    {
        if(moduleSolved)
        {
            return;
        }
        GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
        actionButton.AddInteractionPunch();
        noteActive = false;
        noteToSelf.SetActive(false);
        recipe.SetActive(true);
        noteToSelfText.text = noteToSelfOptions[2];
        if(stage < 20)
        {
            recipeText[stage].text += " " + actionButton.GetComponentInChildren<TextMesh>().text;
            ingredientsAdded.Add(actionOptions[displayedActionIndex]);
        }
        if(stage < correctIngredients.Count())
        {
            if(ingredientsAdded[stage] != correctIngredients[stage])
            {
                correct = false;
            }
        }
        else
        {
            correct = false;
        }
        Debug.LogFormat("[The Hangover #{0}] {1}) *{2}* your elixir.", moduleId, (stage + 1), actionOptions[displayedActionIndex]);
        stage++;
    }

    public void PressIngredientButton()
    {
        if(moduleSolved)
        {
            return;
        }
        GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
        ingredientButton.AddInteractionPunch();
        noteActive = false;
        noteToSelf.SetActive(false);
        recipe.SetActive(true);
        noteToSelfText.text = noteToSelfOptions[2];
        if(stage < 20)
        {
            recipeText[stage].text += " " + ingredientButton.GetComponentInChildren<TextMesh>().text;
            ingredientsAdded.Add(ingredientOptions[displayedIngredientIndex]);
        }
        if(stage < correctIngredients.Count())
        {
            if(ingredientsAdded[stage] != correctIngredients[stage])
            {
                correct = false;
            }
        }
        else
        {
            correct = false;
        }
        Debug.LogFormat("[The Hangover #{0}] {1}) *{2}* added to your elixir.", moduleId, (stage + 1), ingredientOptions[displayedIngredientIndex]);
        stage++;
    }

    public void ActionLeft()
    {
        if(moduleSolved)
        {
            return;
        }
        actionLeftButton.AddInteractionPunch(.5f);
        GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
        displayedActionIndex = (displayedActionIndex + 1) % 4;
        actionText.text = actionOptions[displayedActionIndex];
    }

    public void ActionRight()
    {
        if(moduleSolved)
        {
            return;
        }
        actionRightButton.AddInteractionPunch(.5f);
        GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
        displayedActionIndex = (displayedActionIndex + 3) % 4;
        actionText.text = actionOptions[displayedActionIndex];
    }

    public void IngredientLeft()
    {
        if(moduleSolved)
        {
            return;
        }
        ingredientLeftButton.AddInteractionPunch(.5f);
        GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
        displayedIngredientIndex = (displayedIngredientIndex + 1) % 20;
        ingredientText.text = ingredientOptions[displayedIngredientIndex];
    }

    public void IngredientRight()
    {
        if(moduleSolved)
        {
            return;
        }
        ingredientRightButton.AddInteractionPunch(.5f);
        GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
        displayedIngredientIndex = (displayedIngredientIndex + 19) % 20;
        ingredientText.text = ingredientOptions[displayedIngredientIndex];
    }
}
