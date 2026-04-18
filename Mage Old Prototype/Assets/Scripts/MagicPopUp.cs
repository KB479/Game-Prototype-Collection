using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MagicPopUp : MonoBehaviour
{

    public static event EventHandler<OnPressRatedEventArgs> OnPressRated; 
    public class OnPressRatedEventArgs : EventArgs
    {
        public string rating; 
    }

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI ratingText;

    private float timerRandom; 
    private float timer;
    private bool isActive = false;
    private bool isFinished = false;
    private float destroyTimer = 1f; 


    // rating stringlerle kötü þimdilik böyle enum kullan ilerde

    private void Awake()
    {
        isActive = true;
        timerRandom = UnityEngine.Random.Range(0.5f, 1f); 
        timer = timerRandom; 
    }

    private void Update()
    {

        if (isFinished)
        {
            destroyTimer -= Time.deltaTime;
            if (destroyTimer <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (!isActive) return;

        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F2");

        if(timer <= -0.2)
        {
            FinishPopup("Missed!"); 
        }

    }


    public void OnPopUpPressed()
    {
        if (!isActive) return;
        
        float diff = Mathf.Abs(timer);
        string rating = EvaluateRating(diff);

        FinishPopup(rating); 

    }

    void FinishPopup(string rating)
    {
        isActive = false;
        isFinished = true;

        ratingText.text = rating;

        switch (rating)
        {
            case "Perfect!":
                ratingText.color = Color.green;
                break;
            case "Good!":
                ratingText.color = Color.yellow;
                break;
            case "Missed!":
                ratingText.color = Color.red;
                break;
            default:
                ratingText.color = Color.white;
                break;
        }

        Debug.Log(rating);

        OnPressRated?.Invoke(this, new OnPressRatedEventArgs
        {
            rating = rating,
        }); 


    }

    public string EvaluateRating(float diff)
    {
        if (diff < 0.05f) return "Perfect!";
        else if (diff < 0.15f) return "Good!";
        else return "Missed!";
    }


}
