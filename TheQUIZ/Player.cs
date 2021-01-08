using System;
using System.Collections.Generic;
using System.Text;

namespace TheQUIZ
{
    class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }   //mb should be a list of points? easier to handle
        
        
        public Player(string n) 
        {
            Name = n;
            Score = 0;
        }
        

      
        public void AddScore(int points, List<int> Score)
        {
            //....
        }
        public void ViewScore(Player p, List<int> l)
        {
            //...
        }
        public int CalculateTotalScore()
        {
            // sum all points from the score list
            return 0;
        }
    }
    
}
