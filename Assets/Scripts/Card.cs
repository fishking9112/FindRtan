using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int index = 0;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    public SpriteRenderer frontImage;

    AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void Setting(int _index)
    {
        index = _index;

        frontImage.sprite = Resources.Load<Sprite>($"rtan{index}");
    }

    public void OpenCard()
    {
        if (GameManager.Instance.secondCard != null) return;

        //Sound
        audioSource.PlayOneShot(clip);

        anim.SetBool("isOpen", true);

        front.SetActive(true);
        back.SetActive(false);

        //카드 매칭 확인

        //첫번째 카드인지 확인
        //
        if(GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();
        }
    }

    //카드 파괴
    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
    //다시 닫기
    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }
    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
