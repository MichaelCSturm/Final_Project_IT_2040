using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace Final_Project_2040{
    public class Leaderboard{
       public static void Datalad(){
        List<Players> Playerlist = Databoy.Datalad();
            var leaderladdy = (from Players in Playerlist orderby Players._wins descending select Players._Screenname);
            var leaderlads = (from Players in Playerlist orderby Players._wins+Players._ties+Players._loses descending select Players._Screenname);
            //leaderlads.Sort();
            Console.WriteLine($"Global Game Statistics\n---------------------\n----------------------");
            int i = 0;
            foreach(var thing in leaderlads){
            var leaderlads_loses = from Players in Playerlist where Players._Screenname == thing select Players._loses;
            var leaderlads_wins = from Players in Playerlist where Players._Screenname == thing select Players._wins;
            var leaderlads_ties = from Players in Playerlist where Players._Screenname == thing select Players._ties;
                    foreach(var selected in leaderlads_loses){
                        foreach(var thingy in leaderlads_ties){
                            foreach(var thingyy in leaderlads_wins){
                                i+=1;
                                if(i>5){
                                    break;
                                }
                                Console.WriteLine($"Player:{thing} with {thingy+thingyy+selected} total games!\n");
                            }}}
            }
            i=0;

            foreach(var thing in leaderladdy){
            var leaderlads_loses = from Players in Playerlist where Players._Screenname == thing select Players._loses;
            var leaderlads_name = (from Players in Playerlist where Players._Screenname == thing select Players._wins);
            
            foreach(double thingy in leaderlads_name){
                foreach(double jig in leaderlads_loses){
                    double ratio = (double)thingy/(double)jig;
                    Console.WriteLine($"Name:{thing}---------------------Ratio{ratio}");
                }

            }i+=1;if(i == 5){break;}
            }
            return;
        }
    }
}