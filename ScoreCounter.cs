using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Magic
{
    
    public class ScoreCounter : MonoBehaviour
    {
        public int score;
        public Text scoreLabel;

        // Use this for initialization
        void Start()
        {
            //scoreLabel = GameObject.Find("Text").GetComponent<Text>();
            score = 0;
            scoreLabel.text = score.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            //scoreLabel.text = score.ToString();
        }

        public void AddScore()
        {
            score++;
            //Debug.Log(score);
            scoreLabel.text = score.ToString();
        }
    }
}

