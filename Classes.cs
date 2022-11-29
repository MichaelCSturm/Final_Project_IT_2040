using System;
namespace Final_Project_2040
{
    public class Players{
            public string _Screenname;
            public int _wins;
            public int _loses;
            public int _ties;
            public int _line_num;
   public Players(string Screen_Name,int wins,int loses, int ties,int line_num){
            _Screenname = Screen_Name;
            _wins = wins;
            _loses = loses;
            _ties = ties;
            _line_num = line_num;
            }
            
        
        }
}