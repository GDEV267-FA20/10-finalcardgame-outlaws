using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrintTestScript : MonoBehaviour
{
    public Copperplate copperplate;
    public Sally sally;
    public Sabrina sabrina;
    public William william;

    public void printStatement()
    {
        print(copperplate.name);
    }

    public void printStatement2()
    {
        print(sabrina.name);
    }

    public void printStatement3()
    {
        print(sally.name);
    }

    public void printStatement4()
    {
        print(william.name);
    }

    public void characterSelected()
    {
        List <Scriptable_object_parent> characters = new List<Scriptable_object_parent> {copperplate, sally, sabrina, william};
        List<Scriptable_object_parent> aiCharacters = new List<Scriptable_object_parent> { };

        foreach (Scriptable_object_parent eachCharacter in characters)
        {
            if (eachCharacter.human != 1)
            {
                aiCharacters.Add(eachCharacter);
            }
        }

        int i = Random.Range(0, 3);
        aiCharacters[i].ai = 1;
        //SceneManager.LoadScene();
    }

    public void Awake()
    {
        copperplate.UndoChange();
        sabrina.UndoChange();
        sally.UndoChange();
        william.UndoChange();
    }
}
