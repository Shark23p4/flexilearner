/*using Google.Cloud.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Firebase
{
#if !UNITY_WEBGL || UNITY_EDITOR
    [FirestoreData]
#endif
    [Serializable]
    public class PlayerData
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        [FirestoreProperty("playerId")]
#endif
        public uint PlayerId { get => playerId; set => playerId = value; }
        [SerializeField] private uint playerId;
#if !UNITY_WEBGL || UNITY_EDITOR
        [FirestoreProperty("totalAttempts")]
#endif
        public int TotalAttempts { get => totalAttempts; set => totalAttempts = value; }
        [SerializeField] private int totalAttempts;
#if !UNITY_WEBGL || UNITY_EDITOR
        [FirestoreProperty("totalDeaths")]
#endif
        public int TotalDeaths { get => totalDeaths; set => totalDeaths = value; }
        [SerializeField] private int totalDeaths;
#if !UNITY_WEBGL || UNITY_EDITOR
        [FirestoreProperty("totalWins")]
#endif
        public int TotalWins { get => totalWins; set => totalWins = value; }
        [SerializeField] private int totalWins;
#if !UNITY_WEBGL || UNITY_EDITOR
        [FirestoreProperty("enemiesKilled")]
#endif
        public int EnemiesKilled { get => enemiesKilled; set => enemiesKilled = value; }
        [SerializeField] private int enemiesKilled;
#if !UNITY_WEBGL || UNITY_EDITOR
        [FirestoreProperty("tokensCollected")]
#endif
        public int TokensCollected { get => tokensCollected; set => tokensCollected = value; }
        [SerializeField] private int tokensCollected;
#if !UNITY_WEBGL || UNITY_EDITOR
        [FirestoreProperty("id")]
#endif
        public string Id { get => id; set => id = value; }
        [SerializeField] private string id;
#if !UNITY_WEBGL || UNITY_EDITOR
        [FirestoreProperty("configuration")]
#endif
        public string Configuration { get => configuration; set => configuration = value; }
        [SerializeField] private string configuration;
#if !UNITY_WEBGL || UNITY_EDITOR
        [FirestoreProperty("questionsRight")]
#endif
        public bool[] QuestionsRight { get => questionsRight; set => questionsRight = value; }
        [SerializeField] private bool[] questionsRight = new bool[20];
#if !UNITY_WEBGL || UNITY_EDITOR
        [FirestoreProperty("questionTimeStamp")]
#endif
        public float[] QuestionTimeStamp { get => questionTimeStamp; set => questionTimeStamp = value; }
        [SerializeField] private float[] questionTimeStamp = new float[20];
#if !UNITY_WEBGL || UNITY_EDITOR
        [FirestoreProperty("feedBackScores")]
#endif
        public int[,] FeedBackScores { get => feedBackScores; set => feedBackScores = value; }
        [SerializeField] private int[,] feedBackScores = new int[4, 8];
    }
}
*/