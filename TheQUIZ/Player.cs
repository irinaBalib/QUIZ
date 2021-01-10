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
        

      
        public int AddScore()  // this works ok
        {
           return Score += 5;
        }
        public int ViewScore()   //this works ok
        {
            return Score;
        }
        public int CalculateTotalScore()
        {
            //will need to add bonus points for fast answers
            
            return 0;
             
        }
    }
    
}
