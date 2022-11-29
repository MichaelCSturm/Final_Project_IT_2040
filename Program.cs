using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Final_Project_2040
{
    class Program
    {
        
        public static void LoadGameEnd(int wins, int ties, int loses, string name){
            //Console.WriteLine(name);
            string fileName = @"player_log.csv"; 
            //List<Players> Playerlist = new List<Players>(); 
                    //StreamReader  
                    List<Players> Playerslist = Databoy.Datalad();
                    var EverythingBUT = from Players in Playerslist where Players._Screenname != name select Players._Screenname;
                    
                    //File.WriteAllText(@"player_log.csv", String.Empty);
                    using (StreamWriter writer = new StreamWriter((fileName))){
                            
                                foreach(var selected in EverythingBUT){
                                  //  if(selected== name){continue;}
                                    var Namey = from Players in Playerslist where Players._Screenname == selected select Players._Screenname;
                                    foreach(var playername in Namey){
                                    var Tiey = from Players in Playerslist where Players._Screenname == selected select Players._ties;
                                    foreach(var tiedie in Tiey){
                                    var Winey = from Players in Playerslist where Players._Screenname == selected select Players._wins;
                                    foreach(var windie in Winey){
                                    var Losey = from Players in Playerslist where Players._Screenname == selected select Players._loses;
                                    foreach(var losedie in Losey){
                                        //Console.WriteLine("AAAAAAAAAAAAAA");

                                        writer.WriteLine($"{playername},{windie},{losedie},{tiedie}");
                                    }
                                    }
                                    }
                                    }
                                    }
                                    }
                        using (StreamWriter appender = File.AppendText(fileName))   
                    {   
                    appender.WriteLine($"{name},{wins},{loses},{ties}");
                    }
                    
                                          

            System.Environment.Exit(0);  
        }
        static void Error(){
            Console.WriteLine("Error");
            System.Environment.Exit(0);  
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors! \n1. Start New Game \n2. Load Game\n3. Quit \nEnter choice");
            string answer = Console.ReadLine();
            if (answer == "1"){
                Start_Game();
            }
            else if (answer == "2"){
                Load_Game();
            }

        
        }
        static void Start_Game(){
            
            List<Players> Playerlist = Databoy.Datalad();
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            //Console.WriteLine($"Hello {name}. Let's play!");
            int[] totals = new int[3];
            int tie = 0;
            int win = 0;
            int lose = 0;

            totals = Databoy.Game(tie,win,lose,name);
            while(true){
            Console.WriteLine($" What would you like to do? \n1. Play Again\n2. View Player Statistics\n3. View Leaderboard\n4. Quit\nEnter choice:");
        

        //totals[0] = tie_num;
        //totals[1] = win_num;
        //totals[2] = lose_num;

        int selected = Convert.ToInt32(Console.ReadLine());
 
            if(selected == 1){
                tie = totals[0];
                win = totals[1];
                lose = totals[2];
                totals = Databoy.Game(tie,win,lose,name);
            }
            if(selected == 2){
                double ratio = (double)win/(double)lose;
                Console.WriteLine($"{name} Your stats are {win}, {lose}, {tie}\n---------------------\nYour Win/Lose ration is {ratio}");
            }
            if(selected == 4){
                using (StreamWriter writer = new StreamWriter("player_log.csv", append:true)){
                    writer.WriteLineAsync($"{name},{win},{lose},{tie}");

                }
                System.Environment.Exit(0);
            }
            if(selected ==3 ){
            //var biggestprice = (from Sales in Saleslist where Sales.Unit_price > 1 orderby Sales.Unit_price descending select Sales.Product_line).FirstOrDefault();
            Leaderboard.Datalad();
            }  
            }
            }

        public static int Checker(int hand){
            try{
            Random rnd = new Random();
            int computer_choice = rnd.Next(1, 4);
            Console.WriteLine($"\nComputer chooses {computer_choice}\n");
            if (hand == computer_choice){
                return 1;
            }
            if ( hand ==3 && computer_choice==1){
                return 3;
            }
            if ( hand ==2 && computer_choice==1){
                return 2;
            }
            if ( hand ==3 && computer_choice==2){
                return 2;
            }
            if ( hand ==2 && computer_choice==3){
                return 2;
            }
            if ( hand ==1 && computer_choice==3){
                return 2;
            }
            if ( hand ==1 && computer_choice==2){
                return 3;
            }
            //1. Rock\n2. Paper\n3. Scissors
            // 1 Tie 2 Win 3 Lose
            return 4;
            }
            catch(Exception){
               Console.WriteLine("Heyyyy now");
                return 4;
            }
           
        }
        




    


        
        public static void Load_Game(){try{
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            //Console.WriteLine(name);
           // string fileName = @"player_log.csv";
           
                //Players
                    List<Players> Playerlist = Databoy.Datalad();
                    var Playercheck = (from Players in Playerlist where Players._Screenname == name select Players._Screenname);
                            var Playerwin = (from Players in Playerlist where Players._Screenname == name select Players._wins);
                            var Playertie = (from Players in Playerlist where Players._Screenname == name select Players._ties);
                            var Playerlose = (from Players in Playerlist where Players._Screenname == name select Players._loses);
                            
                            var UnitPrice = from Players in Playerlist select Players._Screenname;
                            int [] totals = new int[3];
                            if (Playercheck.Count() == 0) {
                                Console.WriteLine($"{name}, your game could not be found.");
                                Error();

                            }
                            foreach(var selected in Playercheck){
                                Console.WriteLine(selected);
                            } 
                           // int[] outcomes = {};
                            foreach(var win in Playerwin){
                                foreach(var lose in Playerlose){
                                foreach(var tie in Playertie){
                                    totals = Databoy.Game(tie,win,lose,name);}}}
        //totals[0] = tie_num;
        //totals[1] = win_num;
        //totals[2] = lose_num;
                            //list.Where(w => w.Name == "height").ToList().ForEach(s => s.Value = 30);
                            // Playerlist.Where((w==w._Screenname == name).ToList().ForEach(s => s._wins = totals[1]));

                                        
                            while(true){
                                try{
                                
                                Console.WriteLine($" What would you like to do? \n1. Play Again\n2. View Player Statistics\n3. View Leaderboard\n4. Quit\nEnter choice:");
                                
                                    int selected = Convert.ToInt32(Console.ReadLine());
 
                                if(selected == 1){
                                    
                                foreach (var mc in Playerlist.Where(x => x._Screenname == name)) {mc._wins = totals[1];}
                                foreach (var mc in Playerlist.Where(x => x._Screenname == name)) {mc._ties = totals[0];}
                                foreach (var mc in Playerlist.Where(x => x._Screenname == name)) {mc._loses = totals[2];}
                            Playercheck = (from Players in Playerlist where Players._Screenname == name select Players._Screenname);
                            Playerwin = (from Players in Playerlist where Players._Screenname == name select Players._wins);
                            Playertie = (from Players in Playerlist where Players._Screenname == name select Players._ties);
                            Playerlose = (from Players in Playerlist where Players._Screenname == name select Players._loses);
                                 
        
                                    foreach(var win in Playerwin){
                                foreach(var lose in Playerlose){
                                foreach(var tie in Playertie){
                                    
                                    totals = Databoy.Game(tie,win,lose,name);}}}
                                
                                        //totals[0] = tie_num;
                                        //totals[1] = win_num;
                                        //totals[2] = lose_num;                                     

                                }
                                if(selected == 2){
                         Playercheck = (from Players in Playerlist where Players._Screenname == name select Players._Screenname);
                         foreach(var thing in Playercheck){
                            Playerwin = (from Players in Playerlist where Players._Screenname == name select Players._wins);
                            Playertie = (from Players in Playerlist where Players._Screenname == name select Players._ties);
                            Playerlose = (from Players in Playerlist where Players._Screenname == name select Players._loses);
                            foreach(var tiey in Playertie){
                            foreach(var winey in Playerwin){
                                foreach(var losey in Playerlose){
                                    double ratio = (double)winey/(double)losey;
                Console.WriteLine($"{name} Your stats are Wins:{winey}, Loses:{losey}, Ties:{tiey}\n---------------------\nYour Win/Lose ration is {ratio}");
                                }
                            }}
                         }
                            
                 
                            
                            
                                }
                                if(selected == 3){
                                    Leaderboard.Datalad();
                                }
                                if(selected == 4 ){
                                    LoadGameEnd(totals[1],totals[0],totals[2],name);
                                }

                            }
                            catch(System.FormatException){
                                Console.WriteLine("Woah now no strings here please");
                                continue;}
                            }
                            
        }
        catch(Exception e){
            Console.WriteLine($"Error, {e}");
        }
        }
    }
    }
        
    
    

