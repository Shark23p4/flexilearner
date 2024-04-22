using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Question
{
    // Start is called before the first frame update
    [Serializable]
    public struct question
    {
        public string theQuestion;
        public string answer1;
        public string answer2;
        public string answer3;
        public string answer4;
        public int rightAnswer;
        public string meaning;
    }
    public question[] questions;
}
