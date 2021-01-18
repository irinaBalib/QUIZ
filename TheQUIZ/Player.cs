using System;
using System.Collections.Generic;
using System.Text;

namespace TheQUIZ
{
    class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }  
        
        
        public Player(string n) 
        {
            Name = n;
            Score = 0;
        }
        

      
        public int AddScore(int secondsSpent)  
        {
            int pointsPerQuestion = 10;
            int timeLimit = 30;  // seconds
            if (secondsSpent <= timeLimit)
            {
              Score = pointsPerQuestion + (timeLimit - secondsSpent);
            }
            return Score;
        }

      /*  public int ViewScore()   
        {
            return Score;
        }
        */
        
    }
    
}
