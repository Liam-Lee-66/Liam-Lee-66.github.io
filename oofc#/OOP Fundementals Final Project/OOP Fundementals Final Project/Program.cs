/*
 *  Should game difficulty exist?
 *      if i have time, leave gap for it for now
 *      
 *  Potion or magic item?
 *      HP potion yes
 *      magic item not yet
 */

/*
 *  Game - all private, console(program.cs) should not access it's content 
 *  everything else - all readonly, console(program.cs) should not access it's content
 */

/*
 *  give user default weapon (don't give them in a random small chance for "fun")
 *  user's main objective; investigate !
 *  user navigate through map
 *      place monstor in random grid at start mark them ?
 *          make list of different mosters give them chance 
 *      place boss in random grid at start mark them !
 *      place item in random grid at start mark them ?
 *      
 *      ? = 14 at most
 *          8 monstor 
 *          6 item => 10 items in total; 3 weapon, 3 armors, 4 potions
 *              random chance for armor/weapon/health potion
 *                  Armor (idk imma just put minecraft logic here?)
 *                      - Leather Armor = high dodge chance + low def
 *                      - Chainmail Armor = high dodge chance + mid def
 *                      - Iron Armor = mid dodge chance + high def
 *                      - Le Chonk Armor = no dodge + high def
 *                  Weapon
 *                      - Wooden Bat = low miss chance + low dmg        (low risk, low return)
 *                      - Iron Sword = mid miss chance + mid dmg        (mid risk, mid return)
 *                      - Rusty Sword = mid miss chance + low dmg       (mid risk, low return)
 *                      - Colt 45 = super high miss chance + high dmg   (high risk, high return)
 *                  Potion 
 *                      - Healing Potion = +10 Health
 *                      - Agility Potion = +20% Dodge chance for 2 turns
 *                      - Attack  Potion = +15 DMG boost for 2 turns
 *              
 *      ! = 1 at most
 *      ? = 1 easter egg?
 *      
 *      Extra: Random chance to move monster and boss; ever time user moves
 *      Extra: Random chance ! is simply an item box? (just for fun) 
 *      
 *      Game map: (55, 14); (57, 16) with boundry
 *      *********************************************************
 *      *         !                                             *
 *      *                            ?                   ?      *
 *      *                                                       *
 *      *                                                       *
 *      *        ?         ?                    ?               *
 *      *                                                       *
 *      *                                            ?          *
 *      *                            ?                          *
 *      *       ?                          ?                    *
 *      *                                                       *
 *      *                     ?                             ?   *
 *      *                                                       *
 *      *           ?             @                     ?       *           ? <-- easter egg?
 *      *                                     ?                 *
 *      *********************************************************
 *      
 *  encounter monster/boss 
 *      pokemone type of stuff
 *      win = new weapon/armor
 *      lose = game over
 *  
 *  encounter item box 
 *      receive random item
 *      
 *      *********************************************************
 *      *  ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⠤⠤⢤⣄⡀⠀⠀⢰⠿⢧⣿⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡴⠋⠁⠀⠀⠀⢀⣬⠽⠳⣤⢞⡴⠊⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
⠀⠀⠀⠀⠀⠀⠀⠀*⠀             ⠀⡾⠀⠀⢀⡀⠀⠠⠉⣠⣤⡄⠀⠸⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⢀⣶⣤⡀⠀⢠⡷⠋⣁⣀⢰⡀⠀⠘⠓⠊⠁⠀⠀⠘⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⠸⣧⣇⡩⣟⡛⠀⠸⠯⠍⡻⠛⠉⠉⢉⣽⠠⠤⠤⡀⠘⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⢸⠀⠀⠈⠀⢧⠤⠤⠖⢡⠀⠀⠀⣠⠄⠀⠸⣷⣤⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⢀⠎⠀⠀⠘⠀⢀⣠⡴⠚⡙⠀⠀⠀⠇⠉⠻⣯⠙⠲⠶⠛⣆⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣠⣿⡀⠸⠄⠶⣖⠒⠚⢉⣠⣴⡞⠁⠀⠀⠀⡆⠀⠀⣿⡇⠀⠰⡀⢹⠉⠛⠶⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⠀⠀⣰⠏⣔⢠⡿⢳⣄⠀⠀⠈⠉⠙⠛⠋⠁⠀⠀⠀⠀⡼⠀⠀⣼⡟⠀⢀⠀⣧⠸⡇⠀⠀⠈⠙⢶⣄⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⣰⠞⡿⣸⣿⠻⣷⠀⠙⠷⣄⡀⠀⠀⠀⠀⠀⠀⠀⣠⠞⠁⣠⣾⢏⢰⡿⢷⣅⢸⢠⡇⠀⠀⠀⠀⠀⠙⢦⡀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⢀⡾⠁⢰⡇⡇⠀⣆⠻⣦⣀⠀⠈⠙⠓⠶⠤⠤⠤⠶⠚⣁⣴⣺⠿⠋⠀⡎⢄⣰⡿⠈⣾⡇⠀⠀⠀⠀⠀⠀⠀⠙⢦⡀⠀⠀⠀ *
        *   ⠀⠀⠀⢀⡾⠀⠀⢸⡇⠃⣖⣱⡦⠙⠪⣓⡢⠤⠄⣀⣤⡤⠴⢒⡭⠗⠋⠁⠀⠀⠀⠀⠈⠀⠀⠀⢿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣄⠀⠀ *⠀
 *      *********************************************************
 *      *                   Monster.Name                        *
 *      *                     HP: int                           *
 *      *********************************************************
 *      *    Player.Name picked up Item.Name
 *      *    Player.Name equipped Item.Name
 *      *    Player.Name attacked Monster.Name
 *      *    Attack was effective
 *      *********************************************************
 *      *    Player.Name    
 *           HP: int    ATK: int    DEF: int     *
 *      *                                                       *
 *      *    Fight <                                            *
 *      *    Item                                               *
 *      *    Act                                                *                                                                 *
 *      *********************************************************
 *      
 *      *********************************************************
 *      *  ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⠤⠤⢤⣄⡀⠀⠀⢰⠿⢧⣿⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡴⠋⠁⠀⠀⠀⢀⣬⠽⠳⣤⢞⡴⠊⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
⠀⠀⠀⠀⠀⠀⠀⠀*⠀             ⠀⡾⠀⠀⢀⡀⠀⠠⠉⣠⣤⡄⠀⠸⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⢀⣶⣤⡀⠀⢠⡷⠋⣁⣀⢰⡀⠀⠘⠓⠊⠁⠀⠀⠘⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⠸⣧⣇⡩⣟⡛⠀⠸⠯⠍⡻⠛⠉⠉⢉⣽⠠⠤⠤⡀⠘⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⢸⠀⠀⠈⠀⢧⠤⠤⠖⢡⠀⠀⠀⣠⠄⠀⠸⣷⣤⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⢀⠎⠀⠀⠘⠀⢀⣠⡴⠚⡙⠀⠀⠀⠇⠉⠻⣯⠙⠲⠶⠛⣆⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣠⣿⡀⠸⠄⠶⣖⠒⠚⢉⣠⣴⡞⠁⠀⠀⠀⡆⠀⠀⣿⡇⠀⠰⡀⢹⠉⠛⠶⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⠀⠀⣰⠏⣔⢠⡿⢳⣄⠀⠀⠈⠉⠙⠛⠋⠁⠀⠀⠀⠀⡼⠀⠀⣼⡟⠀⢀⠀⣧⠸⡇⠀⠀⠈⠙⢶⣄⠀⠀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⠀⠀⣰⠞⡿⣸⣿⠻⣷⠀⠙⠷⣄⡀⠀⠀⠀⠀⠀⠀⠀⣠⠞⠁⣠⣾⢏⢰⡿⢷⣅⢸⢠⡇⠀⠀⠀⠀⠀⠙⢦⡀⠀⠀⠀⠀⠀ *
        *   ⠀⠀⠀⠀⢀⡾⠁⢰⡇⡇⠀⣆⠻⣦⣀⠀⠈⠙⠓⠶⠤⠤⠤⠶⠚⣁⣴⣺⠿⠋⠀⡎⢄⣰⡿⠈⣾⡇⠀⠀⠀⠀⠀⠀⠀⠙⢦⡀⠀⠀⠀ *
        *   ⠀⠀⠀⢀⡾⠀⠀⢸⡇⠃⣖⣱⡦⠙⠪⣓⡢⠤⠄⣀⣤⡤⠴⢒⡭⠗⠋⠁⠀⠀⠀⠀⠈⠀⠀⠀⢿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣄⠀⠀ *⠀
 *      *********************************************************
 *      *                   Monster.Name                        *
 *      *                     HP: int                           *
 *      *********************************************************
 *      *    Item.Name <
 *      *    Item.Name
 *      *    Item.Name
 *      *********************************************************

 *      *********************************************************
 *                       ░░░░░░▄▄▄░░▄██▄░░░
                         ░░░░░▐▀█▀▌░░░░▀█▄░░░
                         ░░░░░▐█▄█▌░░░░░░▀█▄░░
                         ░░░░░░▀▄▀░░░▄▄▄▄▄▀▀░░
                         ░░░░▄▄▄██▀▀▀▀░░░░░░░
                         ░░░█▀▄▄▄█░▀▀░░
                         ░░░▌░▄▄▄▐▌▀▀▀░░
                         ▄░▐░░░▄▄░█░▀▀ ░░
                         ▀█▌░░░▄░▀█▀░▀ ░░
                         ░░░░░░░▄▄▐▌▄▄░░░
                         ░░░░░░░▀███▀█░▄░░
                         ░░░░░░▐▌▀▄▀▄▀▐▄░░
                         ░░░░░░▐▀░░░░░░▐▌░░
                         ░░░░░░█░░░░░░░░█░░░            
 *      *********************************************************
 *      *                   Monster.Name                        *
 *      *                     HP: int                           *
 *      *********************************************************
 *      * Player                                                *
 *      *                                                       *
 *      * HP                                                    *
 *      * DEF                                                   *
 *      * ATK                                                   *          
 *      *                                                       *
 *      *********************************************************
 *      
 *      
 *      
 *      *********************************************************
                ⠀  ⠀⢀⢀⣠⣾⣶⣿⣿⠿⠿⠴⣤⣀⠰⠠⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                  ⠀⠸⢾⣿⣿⣿⣿⣿⣿⠿⠛⠉⠀⠈⠁⠀⠂⢦⣅⡢⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                  ⠀⠀⣼⣿⣿⣿⣿⠟⠃⠀⠀⠀⠀⢀⣤⠤⠤⠤⡘⣧⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                  ⠀⠀⠙⣿⣿⣿⣏⣤⣤⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠘⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                  ⠀⠀⠀⠈⢿⣿⠛⢉⠀⢄⡀⠀⠀⠀⡦⢲⣦⡈⠀⠄⠸⣴⠄⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀
                  ⠀⠀⠀⠀⠘⣿⣰⡥⣶⡆⠘⡇⠀⠀⠁⠈⠋⠁⠀⠀⠀⠀⠈⠉⠂⡀⠀⠀⠀⠀⠀⠀⠀
                  ⠀⠀⠀⠀⠀⠽⣿⣄⡙⠛⠀⣹⣄⡀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠁⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀  ⢀⣠⣿⡉⢂⣀⢲⣿⠟⠁⠀⡀⠀⠀⠀⠀⠀⠀⢠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀  ⠀⠀⣿⣿⣿⣿⣇⡈⠆⣿⣷⣾⣿⣹⣷⡆⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                  ⠀⠀⠀⠀⠹⠿⣿⣿⣿⣼⡠⢿⠏⣿⣿⣿⠿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                  ⠀⠀⠀⠀⠀⠀⠀⠋⠛⠻⢽⣦⣲⣬⣝⣢⢁⡁⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                  ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢛⣷⣯⡿⣟⡋⠀⢀⠀⠀⠀⠀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀
                  ⠀⠀⠀⠀⠀⠀⠀⠀⡀⢀⣰⣬⣽⣻⣿⣿⣽⡛⢃⣠⣶⣴⡀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀
                  ⠀⠀⠀⠀⠀⠠⠢⣄⢢⠫⣾⣿⣿⣿⣿⣶⣤⣶⣾⣿⣿⣿⡧⢠⢀⠄⠀⠂⠀⠀⠀⠀⠀
                  ⠀⠀⠀⠀⠀⠀⠀⠀⡇⢻⣿⣿⣿⣿⣷⡟⠉⠉⠛⣿⣿⣿⡏⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀
                  ⠀⠀⡀⠑⠀⠀⠀⢸⡴⢻⣿⣿⡿⠝⠅⠆⠀⠀⠀⠈⢫⠛⠃⠀⢀⢰⠀⠀⠀⠈⠀⠀⠀
                  ⠀⠐⠀⠀⣀⠀⠀⣸⠽⡘⠛⠁⠀⠀⠈⠆⠒⠀⠀⠀⠀⠁⠁⠀⠈⣌⠀⠀⠀⠀⠈⠀⠀
                  ⡊⠀⠀⠀⠀⠄⢨⡟⡆⢄⠀⠀⠀⢀⠔⢀⡀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⡀
 *      *********************************************************
 *      *                   Monster.Name                        *
 *      *                     HP: int                           *
 *      *********************************************************
 *      * Player                                                *
 *      *                                                       *
 *      * HP                                                    *
 *      * DEF                                                   *
 *      * ATK                                                   *          
 *      *                                                       *
 *      *********************************************************
 *      
 *      *********************************************************
 *      *    Player.Name                                        *
 *      *    HP: int    ATK: int    DEF: int    Hit%: int       *
 *      *********************************************************
 *      *    Resume <                                                   *
 *      *    Exit Game <
 *      
 *           Items:
 *                                                 *
 *      * HP                                                    *
 *      * DEF                                                   *
 *      * ATK                                                   *          
 *      *                                                       *
 *      *********************************************************
 */

// PDF does not mention about restarting game without leaving console

// code has placements for potion, but potions are never made. I was planning on creating them but ran out of time.
// Potions are not used in this game
// apparently "using static System.Console;" doens't want to work in some places. I removed it entirely

// Warning: game is totally unbalanced 

/*
 *  Main controlls:
 *      Arrow Keys; movement, moving selection
 *      Enter; select option
 *      ESC; Pause menu (only works while in Map or during Fight)
 */


using SD_300___OOP_Fundamentals___Final_Project;

Game game = new Game();
game.Start();