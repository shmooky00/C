using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wordle_app_final_project
{
    public partial class Form1 : Form
    {
        private string wordleWord;

        private int wordLength = 5;
        private int maxAttempts = 6;
        private int currAttempt = 0;

        private TextBox[,] tB;

        public Form1()
        {
            InitializeComponent();
            InitializetB();
            InitializeFButtons();

            this.KeyPreview = true;

            this.KeyDown += Form1_KeyDown;


            wordleWord = RandWord("wordlistwordle.txt").ToUpper(); // chooses random word from file, makes uppercase  

            wordleWord = DrMadeirasWord();  //can get the wordle from either class

            WordList("wordlistwordle.txt");

        }

        private List<WordData> wordList = new List<WordData>();


        private void WordList(string filePath)
        {
            string[] words = File.ReadAllLines(filePath);

            foreach (string word in words)
            {
                wordList.Add(new WordData(word.Trim().ToUpper())); // Store each word with its usage count
            }
        }

        public class WordData //to keep track of how many times a word has been used 
        {
            public string Word { get; set; }
            public int TimesUsed { get; set; }

            public WordData(string word)
            {
                Word = word;

                TimesUsed = 0;
            }
        }


        private string DrMadeirasWord()
        {
            string sWord = specialWord.Text.ToUpper();

            if (string.IsNullOrEmpty(sWord) && sWord.Length == wordLength)
            {
                return sWord;


            }

            return RandWord("wordlistwordle.txt");
        }


        private void InitializetB()
        {
            tB = new TextBox[6, 5] //array
            {
                { tB1, tB2, tB3, tB4, tB5 },
                { tB6, tB7, tB8, tB9, tB10 },
                { tB11, tB12, tB13, tB14, tB15 },
                { tB16, tB17, tB18, tB19, tB20 },
                { tB21, tB22, tB23, tB24, tB25 },
                { tB26, tB27, tB28, tB29, tB30 }
            };

            foreach (TextBox t in tB)
            {

                t.Enabled = false; // Disable all initially

                t.KeyPress += tB_KeyPress;

                t.KeyDown += tB_KeyDown;
            }


            EnableRow(0);
        }



        private void EnableRow(int row)
        {
            for (int col = 0; col < wordLength; col++)
            {
                tB[row, col].Enabled = true;
            }

            this.ActiveControl = tB1; //focus tb1

            tB[row, 0].Focus(); //focus rest of tbs
        }

        private string RandWord(string filePath)
        {
            string[] words = File.ReadAllLines(filePath);

            Random random = new Random();

            int randomIndex = random.Next(words.Length); //chooses random word from file

            return words[randomIndex];
        }

        /*
        private bool IsValidWord(string word) //cant seem to make it work. ive been working on this for over 15 hours at this point
        {
            string filePath = "wordlistwordle.txt";

            string line;

            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Trim().ToUpper() == word.ToUpper())
                    {
                        return true;  //this was a solo project
                                        sorry for it being sloppy 
                    }
                }
            }

            return false;
        }
        */

        private void tB_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; //no non letters 
            }

            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar); //all letters caps

                goForward(textBox);
            }
        }



        private void tB_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;


            if (e.KeyCode == Keys.Back && textBox.Text == string.Empty) //for backspacing in the array
            {
                goBack(textBox);
            }
        }

        private void goForward(TextBox currTextBox) //forward 
        {
            int row = 0;

            int col = 0;



            for (int i = 0; i < tB.GetLength(0); i++) //textboxes within array
            {
                for (int j = 0; j < tB.GetLength(1); j++)
                {
                    if (tB[i, j] == currTextBox)
                    {
                        row = i;

                        col = j;

                        break;
                    }
                }

            }


            if (col < wordLength - 1)
            {
                tB[row, col + 1].Focus(); //moves focus to next row
            }
            else
            {
                CheckUser(row);
            }
        }


        private void goBack(TextBox currTextBox) //backward
        {
            int row = 0;

            int col = 0;


            for (int i = 0; i < tB.GetLength(0); i++)
            {
                for (int j = 0; j < tB.GetLength(1); j++)
                {
                    if (tB[i, j] == currTextBox)
                    {
                        row = i;

                        col = j;

                        break;
                    }
                }
            }


            if (col > 0)
            {
                tB[row, col - 1].Focus();
            }
        }


        private void CheckUser(int row)
        {
            string word = " ";

            string guess = "";

            for (int i = 0; i < wordLength; i++)
            {
                guess += tB[row, i].Text.ToUpper(); //get guess from the textboxes
            }

            if (guess.Length < wordLength)
            {
                MessageBox.Show("Please fill in all letters.");
                return;
            }

            /* 
             
            if (!IsValidWord(guess))
            {
                MessageBox.Show("Invalid word.");

                return;
            }

            */

            ColorText(row); //colors to coorespond to guess and user word



            if (word == wordleWord) //compares user word to wordle word
            {
                MessageBox.Show("Good job! You guessed the Wordle!");

                DisabletB();
            }
            else
            {
                currAttempt++;

                if (currAttempt < maxAttempts)
                {
                    MessageBox.Show("Try again!");

                    EnableRow(currAttempt); //start on next row
                }
                else
                {
                    MessageBox.Show($"Game over! The Wordle was: {wordleWord}");

                    DisabletB();
                }
            }

            IncrementWordUsage(guess);

            SaveGameData();
        }

        private void IncrementWordUsage(string guessedWord)
        {
            foreach (var wordData in wordList)
            {
                if (wordData.Word == guessedWord)
                {
                    wordData.TimesUsed++;

                    break;
                }
            }
        }

        private void SaveGameData()
        {
            SaveList("wordlistwordle.txt");
        }

        private void SaveList(string filePath) //savewords used to list
        {
            var lines = wordList.Select(w => $"{w.Word},{w.TimesUsed}").ToList(); // https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where?view=net-6.0

            File.WriteAllLines(filePath, lines);
        }


        private void DisabletB()
        {
            foreach (TextBox t in tB)
            {
                t.Enabled = false; //disable tbs
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; //user pressing enter key results
            }
        }

        private void ColorText(int row)
        {
            string guess = "";


            for (int i = 0; i < wordLength; i++) //makes letters into a full word to check
            {
                guess += tB[row, i].Text.ToUpper(); //compile
            }


            for (int i = 0; i < wordLength; i++) //checks the single letters if in right position, turns green if so
            {
                char userG = guess[i];

                if (userG == wordleWord[i])
                {
                    tB[row, i].BackColor = Color.Green;
                }
                else
                {
                    tB[row, i].BackColor = Color.Gray; //checks if letter is absent, turns gray if so
                }
            }


            for (int i = 0; i < wordLength; i++) //same as above but if letter is in word, turns yellow
            {
                char userG = guess[i];


                if (tB[row, i].BackColor != Color.Green && wordleWord.Contains(userG))
                {

                    int repeatsWordle = wordleWord.Count(c => c == userG); //check for repeats in word/placement

                    int repeatsGuess = guess.Count(c => c == userG);


                    if (repeatsGuess <= repeatsWordle)
                    {
                        tB[row, i].BackColor = Color.Yellow; //turns yellow only for the number of correct letters in word
                    }
                }
            }

            
        }
        
        /*
        private Button[] letterButtons; 

        public void InitializeButtons()
        {
            letterButtons = new Button[] { buttonA, buttonB, buttonC, buttonD, buttonE, buttonF, buttonG, buttonH,
                                            buttonI, buttonJ, buttonK, buttonL, buttonM, buttonN, buttonO, buttonP,
                                 buttonQ, buttonR, buttonS, buttonT, buttonU, buttonV, buttonW, buttonX,buttonY, buttonZ };
        }

        failed button array for color buttons
        */

        private string GetRandomWord()
        {
            var unusedWords = wordList.Where(w => w.TimesUsed == 0).ToList(); //source: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where?view=net-6.0

            if (unusedWords.Count == 0)
            {
                

                foreach (var wordData in wordList)
                {
                    wordData.TimesUsed = 0;//reset once all words have been used 
                }

                unusedWords = wordList.ToList(); 
            }

            Random random = new Random();

            var randomWordData = unusedWords[random.Next(unusedWords.Count)];

            
            randomWordData.TimesUsed++;

            return randomWordData.Word;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void ResetGame() //resets all game functions/methods
        {

            foreach (var textbox in tB)
            {
                textbox.Text = " ";

                textbox.BackColor = Color.White;

                textbox.Enabled = false;
            }


            currAttempt = 0;


            wordleWord = RandWord("wordlistwordle.txt").ToUpper(); //gets new word for game


            EnableRow(0);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            ResetGame(); //acts as the load button as well.
                         //i figured the submit button for custom word also counted as the load new word requirement?
        }

        private void InitializeFButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Name.StartsWith("button"))
                {
                    button.Click += fakeButton_Click;
                }
            }
        }

        private void fakeButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("boop");
        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Enter a guess for a five letter word. " +
                "The app will provide feedback through a color change behind the word. " +
                "Green means the letter is in the correct spot. " +
                "Yellow means the letter appears in the word. " +
                "Grey means the letter is not in the word. Have fun!");
        }

        private void hintB_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hmmm, maybe its a five letter word...");
        }

        private void button27_Click_2(object sender, EventArgs e)
        {
            string sWord = specialWord.Text.Trim().ToUpper();

            if (!string.IsNullOrEmpty(sWord) && sWord.Length == wordLength)
            {
                wordleWord = sWord; //assigns special word using the same rules for wordleWord

                MessageBox.Show("Custom word has been set.");
            }
            else
            {
                MessageBox.Show($"Please enter a valid five letter word");
            }
        }

       
    }
}


   












