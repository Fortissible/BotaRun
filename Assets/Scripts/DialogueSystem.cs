using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text char_NameText;
    public Text dialogText;
    public Animator animator;
    public bool isDialogActive;
    private Queue<string> kalimat_kalimat;
    private bool checkTaskGiver;

    void Start()
    {
        kalimat_kalimat = new Queue<string>();
    }

    public void StartDialog(Dialog dialog, bool alsoTaskGiver= false)
    {
        checkTaskGiver = alsoTaskGiver;
        animator.SetBool("IsOpen",true);
        isDialogActive = true;
        Debug.Log("Start Convo : " + dialog.char_name);
        FindObjectOfType<TimerSettings>().TimerFreeze(true);

        char_NameText.text = dialog.char_name;

        kalimat_kalimat.Clear();

        foreach(string kalimat in dialog.kalimat_kalimat)
        {
            kalimat_kalimat.Enqueue(kalimat);
        }

        DisplayNextKalimat();
    }

    public void DisplayNextKalimat()
    {
        if (kalimat_kalimat.Count == 0)
        {
            EndDialog();
            Debug.Log(checkTaskGiver);
            if (checkTaskGiver){ 
            FindObjectOfType<Item>().dialogEndFunction();
            }
            return;
        }

        string kalimat = kalimat_kalimat.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(kalimat));
        Debug.Log(kalimat);
    }

    IEnumerator TypeSentence (string kalimat)
    {
        dialogText.text = "";
        foreach (char huruf in kalimat.ToCharArray())
        {
            dialogText.text += huruf;
            yield return null;
        }
    }

    void EndDialog()
    {
        animator.SetBool("IsOpen", false);
        isDialogActive = false;
        FindObjectOfType<TimerSettings>().TimerFreeze(false);
        Debug.Log("End Convo");
    }
}
