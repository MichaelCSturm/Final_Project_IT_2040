using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace Final_Project_2040{
    public class Databoy{
        public static List<Players> Datalad(){
            //* \\*
                List<Players> Playerlist = new List<Players>(); 
                                //StreamReader  
                  using(StreamReader reader = new StreamReader("player_log.csv"))
                  {
                          string line;
                          int line_number = 0;
                          
                          while((line = reader.ReadLine())!=null)
                          {
                              line_number+=1;
                              //Console.WriteLine(line);
                              string[] splitter = line.Split(",");
                              Playerlist.Add( new Players(
                             splitter[0], 
                              Convert.ToInt32(splitter[1]),
                              Convert.ToInt32(splitter[2]),
                              Convert.ToInt32(splitter[3]), line_number));     
                                  
                              }
                      }
                return Playerlist;
                  
        }
        public static int[] Game(
            int tie_num, 
            int win_num,
            int lose_num,
            string name)
            {
            int round_number = tie_num+win_num+lose_num;
            
            
                //round_number+=1;
                Console.WriteLine($"Round {round_number}\n1. Rock\n2. Paper\n3. Scissors\nWhat will it be?\nIf you want to quit use input 4");
                string optionselected = Console.ReadLine();
                
                    
                if (Convert.ToInt32(optionselected) == 4){
                    Program.LoadGameEnd(win_num,tie_num,lose_num,name);
                }
                int answer = Program.Checker(Convert.ToInt32(optionselected));
                if (answer == 1){
                    Console.WriteLine("\nYou tied!\n");
                    tie_num+=1;
                }
                if(answer == 2){
                    Console.WriteLine("\nYou win!\n");
                    win_num+=1;
                }
                if(answer==3){
                    Console.WriteLine("\nYou lose!\n");
                    lose_num+=1;
                }
                if(answer ==4){
                    Console.WriteLine("HEY YOUR CHOICE WAS NO GOOOOD");
                }
                Console.WriteLine($"Your wins are{win_num}, Your loses are{lose_num},Your ties are{tie_num}");
                
                //1. Rock\n2. Paper\n3. Scissors
                // 1 Tie 2 Win 3 Lose
                

        int [] totals = new int[3];
        totals[0] = tie_num;
        totals[1] = win_num;
        totals[2] = lose_num;



           return totals;
        }

    }
}