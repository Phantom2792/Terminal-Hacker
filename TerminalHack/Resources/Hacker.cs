using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int ch = 0;
    string pw,n;
    const string menu = "You may type menu at anytime.";
    string[] pw1= { "aloha" ,"slack" ,"mage" ,"library" };
    string[] pw2 = { "horysheet", "donutman", "marksman", "chaos" };
    string[] pw3 = { "thingamabob", "interplanetary", "satellite", "surmountable" };
    
    int level;//Game State
    enum Screen {MainMenu, PasswordWait, Win };
    Screen currentscreen = Screen.MainMenu;
    //private string name;
    // Start is called before the first frame update
    void Start()
    {
        displayMainMenu();
    }

    void displayMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to the Computer, User");
        /*Terminal.WriteLine("Please Enter your Name User:");
        name = Console.ReadLine();*/
        Terminal.WriteLine("Type 1 for the local library");
        Terminal.WriteLine("Type 2 for the police station");
        Terminal.WriteLine("Type 3 for NASA");
        Terminal.WriteLine("Enter your choice");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
            displayMainMenu();
        else if (input == "exit" || input == "quit" || input == "close")
            Application.Quit();
        else if (currentscreen == Screen.MainMenu)
            RunMainMenu(input);
        else if (currentscreen == Screen.PasswordWait)
            PasswordRead(input);


    }

    private void RunMainMenu(string input)
    {
        bool validlevelno = (input == "1" || input == "2" || input == "3");
        if (validlevelno)
        {
            level = int.Parse(input);
            LevelCheck();
        }
        else if (input == "007")
        {
            n = "007";
            Terminal.WriteLine("Go ahead Agent 007");
        }
        else
            Terminal.WriteLine("Please choose a valid level");
    }

    void PasswordRead(string input)
    {
        if (input == pw)
            WinDisplay();
        else
        {
            Terminal.WriteLine("GTFO jackass");
            ch = 1;
            LevelCheck();
        }
    }

    void WinDisplay()
    {
        Terminal.ClearScreen();
        currentscreen = Screen.Win;
        DisplayReward();
    }

    void DisplayReward()
    {
        ch = 0;
        Terminal.WriteLine("Congrats beesh!");
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Learn a new spell!");
                Terminal.WriteLine("Play Again for a greater challenge");
                Terminal.WriteLine(@"
     ______    
    /     /) 
   /     / /
  /_____/ /
 (______|/
");
                break;
            case 2:
                Terminal.WriteLine("Whip out a shot!");
                Terminal.WriteLine("An even greater challenge awaits you");
                Terminal.WriteLine(@"
    _________ ( 
   /  ______(  )
  / #(
 /__/
");
                break;
            case 3:
                Terminal.WriteLine("Here's a star for you!");
                Terminal.WriteLine(@"
     /\
____/  \____
\          /
 >        <
/___    ___\
    \  /
     \/        
");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
        currentscreen = Screen.MainMenu;
        Terminal.WriteLine(menu);
    }

    // Update is called once per frame
    void LevelCheck()
    {
        currentscreen = Screen.MainMenu;
        Terminal.ClearScreen();
        /*if(n!="007")
        {
            Terminal.WriteLine("Please enter your name:");
            n=Console.ReadLine();
        }*/
        switch (level)
        {
            case 1:
                pw = pw1[UnityEngine.Random.Range(0, pw1.Length)];
                if (ch == 0)
                {
                    Terminal.WriteLine("Level " + level + " it is");
                    Terminal.WriteLine(@"
         ____  _____  _____  _  _ 
        (  _ \(  _  )(  _  )( )/ )
         ) _ < )(_)(  )(_)(  )  ( 
        (____/(_____)(_____)(_)\_) ");
                }
                break;
            case 2:
                pw = pw2[UnityEngine.Random.Range(0, pw2.Length)];
                if (ch == 0)
                {
                    Terminal.WriteLine("Level " + level + " it is");
                    Terminal.WriteLine(@"
 ____  _____  __    ____  ___  ____ 
(  _ \(  _  )(  )  (_  _)/ __)( ___)
 )___/ )(_)(  )(__  _)(_( (__  )__) 
(__)  (_____)(____)(____)\___)(____)");
                }
                break;
            case 3:
                pw = pw3[UnityEngine.Random.Range(0, pw3.Length)];
                if (ch == 0)
                {
                    Terminal.WriteLine("Level " + level + " it is");
                    Terminal.WriteLine(@"
         _  _    __    ___    __   
        ( \( )  /__\  / __)  /__\  
         )  (  /(__)\ \__ \ /(__)\ 
        (_)\_)(__)(__)(___/(__)(__) ");
                }
                break;
            default:
                Terminal.WriteLine("Please choose a valid level");
                break;
        }
        RandomPassword();
    }

    void RandomPassword()
    {
        currentscreen = Screen.PasswordWait;
        //int c = 0,x=0;
        Terminal.WriteLine("Enter your password:- (Hint -> " + Encrypt1(pw).Anagram() + ", think a few steps ahead)");
    }

    string Encrypt1(string a)
    {
        string st = "";
        for (int i = 0; i < a.Length; i++)
        {
            char ch = a[i];
            ch = (char)(ch + 4);
            if (ch > 'z')
            {
                ch = (char)(ch - 26);
            }
            else if (ch < 'a')
            {
                ch = (char)(ch + 26);
            }
            st += ch;
        }
        return st;
    }

    /*string Encrypt2(string a)
    {
        string st = "";
        int s=0,x =0;
        char[] alph = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', };
        for (int i = 0; i < a.Length; i++)
        {
            for (int j=0;j<26;j++)
            {
                if (a[i] == alph[j])
                    x = j + 1;
            }
            s += x;
        }
        string b = s.ToString();
        for(int i=0;i<b.Length;i++)
        {
            char ch=' ';
            for (int j = 0; j < 26; j++)
            {
                if (b[i] == j)
                    ch = alph[j];
            }
            st += ch;
        }

        return st;
    }*/

    void Update()
    {
       
    }
}
