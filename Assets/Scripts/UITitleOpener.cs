using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UITitleOpener : MonoBehaviour
{
    public bool isOpened = false;
    [SerializeField] private float closeAnimationDuration = 0.2333f;


    private Animator anim;
    private bool animationWorking = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        if (isOpened)
            Open();
    }

    public void Open()
    {
        if (animationWorking)
            return;
        if(gameObject.activeSelf == false)
            gameObject.SetActive(true);
        isOpened = true;
        anim.SetTrigger("Open");
        StartCoroutine(TimeCloser(closeAnimationDuration));
    }

    public void Close()
    {
        if (animationWorking)
            return;
        isOpened = false;
        anim.SetTrigger("Close");
        StartCoroutine(TimeCloser(closeAnimationDuration));
    }
    public void OpenOrClose()
    {
        if (isOpened)
            Close();
        else
            Open();
    }
    private IEnumerator TimeCloser(float time)
    {
        animationWorking = true;
        yield return new WaitForSeconds(time);
        animationWorking = false;
    }
    private void OnDisable()
    {
        animationWorking = false;
    }
}
