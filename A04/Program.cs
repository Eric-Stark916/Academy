// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on branch A04: Character Frequency.
// This program determines the 7 most frequent letters from the word list.
// ------------------------------------------------------------------------------------------------
using static System.Console;

var wordList = File.ReadAllLines ("C:/Work/Datas for code/words (1).txt");
Dictionary<char, int> letterFreq = [];
foreach (var ch in wordList.SelectMany (a => a))
   letterFreq[ch] = letterFreq.GetValueOrDefault (ch, 0) + 1;
WriteLine ("Character - Frequency");
foreach (var letter in letterFreq.OrderByDescending (a => a.Value).Take (7))
   WriteLine ($"{letter.Key,5}{"-",6}{letter.Value,8}");