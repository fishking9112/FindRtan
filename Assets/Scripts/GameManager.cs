using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public  static GameManager Instance;

    public Text timeText;
    float time = 0.0f;

    public GameObject endText;
    public int cardCount = 0;

    public Card firstCard;
    public Card secondCard;

    //sound
    AudioSource audioSource;
    public AudioClip clip;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");

        if(time >= 30.0f)
        {
            // ���ѽð� �ʰ� !
            Time.timeScale = 0.0f;
            endText.SetActive(true);
        }
    }

    public void Matched()
    {
        // �� ī�尡 ������ �����ֱ�
        if(firstCard.index == secondCard.index)
        {
            audioSource.PlayOneShot(clip);

            //�ı�
            firstCard.DestroyCard();
            secondCard.DestroyCard();

            cardCount -= 2;
            if(cardCount == 0)
            {
                Time.timeScale = 0.0f;
                endText.SetActive(true);
            }
        }
        else
        {
            //�ٽ� ������
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }
}
