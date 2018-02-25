﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;


[Serializable]
public class Conversation
{
    public Dialogue[] dialogueList;
}

[Serializable]
public class Dialogue 
{
    public GameObject person;
    private Color color;
    public string text;

    public Dialogue(GameObject person, string text)
    {
        this.person = person;
        this.color = person.GetComponent<DialogOptions>().color;
        this.text = text;
    }

    public Color getDialogColor()
    {
        return this.color;
    }
}

public class DialogueManager : MonoBehaviour
{
    private Text textDialog;
    public bool Busy;
    public List<Dialogue> dialogueList;
    public Image baloonDialog;
    public float xDisp;
    public float yDisp;
    public static DialogueManager instance = null;
    public float dialogueWaitTime = 1.5f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        dialogueList = new List<Dialogue>();
        textDialog = baloonDialog.GetComponentInChildren<Text>();
        DisableDialogBaloon();
    }

    void Update()
    {
        if ((dialogueList.Count == 0) || (this.Busy))
            return;
        StartCoroutine(DisplayDialog());
    }

    public void AddDialog(Dialogue dialogue)
    {
        dialogueList.Add(dialogue);
    }

    private void setupDialogBaloon(Color color, GameObject person)
    {
        baloonDialog.GetComponent<Image>().color = new Color(color.r, color.g, color.b);

        Vector3 wantedPos = Camera.main.WorldToViewportPoint(person.transform.position);
        baloonDialog.transform.position = new Vector3(wantedPos.x * Screen.width + xDisp,
                                                      wantedPos.y * Screen.height + yDisp,
                                                      40);
    }

    IEnumerator DisplayDialog()
    {
        this.Busy = true;
        Dialogue dialogue = dialogueList[0];

        setupDialogBaloon(dialogue.getDialogColor(), dialogue.person);
        EnableDialogBaloon();
        textDialog.text = "";
        foreach (char Letter in dialogue.text)
        {
            textDialog.text += Letter;
            yield return null;
        }
        yield return new WaitForSeconds(this.dialogueWaitTime);
        DisableDialogBaloon();
        dialogueList.RemoveAt(0);
        this.Busy = false;
    }

    void EnableDialogBaloon()
    {
        baloonDialog.gameObject.SetActive(true);
    }

    void DisableDialogBaloon()
    {
        baloonDialog.gameObject.SetActive(false);

    }
}
