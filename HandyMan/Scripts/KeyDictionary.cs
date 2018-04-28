using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;

namespace HandyMan.Types
{
    public class KeyDictionaries
    {
        public static readonly Dictionary<char, char> CirillycLatinKeys = new Dictionary<char, char>
        {
            {'a' , 'а' },            {'A' , 'А' },
            {'b' , 'б' },            {'B' , 'Б' },
            {'c' , 'с' },            {'C' , 'С' },
            {'d' , 'д' },            {'D' , 'Д' },
            {'e' , 'э' },            {'E' , 'Э' },
            {'f' , 'ф' },            {'F' , 'Ф' },
            {'g' , 'г' },            {'G' , 'Г' },
            {'h' , 'х' },            {'H' , 'Х' },
            {'i' , 'и' },            {'I' , 'И' },
            {'j' , 'й' },            {'J' , 'Й' },
            {'k' , 'к' },            {'K' , 'К' },
            {'l' , 'л' },            {'L' , 'Л' },
            {'m' , 'м' },            {'M' , 'М' },
            {'n' , 'н' },            {'N' , 'Н' },
            {'o' , 'о' },            {'O' , 'О' },
            {'p' , 'п' },            {'P' , 'П' },
            {'q' , 'ж' },            {'Q' , 'Ж' },
            {'r' , 'р' },            {'R' , 'Р' },
            {'s' , 'ш' },            {'S' , 'Ш' },
            {'t' , 'т' },            {'T' , 'Т' },
            {'u' , 'у' },            {'U' , 'У' },
            {'v' , 'в' },            {'V' , 'В' },
            {'w' , 'щ' },            {'W' , 'Щ' },
            {'x' , 'ь' },            {'X' , 'ъ' },
            {'y' , 'ы' },            {'Y' , 'Ы' },
            {'z' , 'з' },            {'Z' , 'З' },
            {'á' , 'я' },            {'Á' , 'Я' },
            {'é' , 'е' },            {'É' , 'Е' },
            {'ó' , 'ё' },            {'Ó' , 'Ё' },
            {'ú' , 'ю' },            {'Ú' , 'Ю' },
            {'ö' , 'ч' },            {'Ö' , 'Ч' },
            {'ü' , 'ц' },            {'Ü' , 'Ц' }            
        };

        public static readonly Dictionary<char, int> LatinVkey = new Dictionary<char, int>
        {
            {'a' , 0x41 },            
            {'b' , 0x42 },           
            {'c' , 0x43 }, 
            {'d' , 0x44 },   
            {'e' , 0x45 },        
            {'f' , 0x46 },     
            {'g' , 0x47 },      
            {'h' , 0x48 },            
            {'i' , 0x49 },         
            {'j' , 0x4A },         
            {'k' , 0x4B },       
            {'l' , 0x4C },       
            {'m' , 0x4D },  
            {'n' , 0x4E },        
            {'o' , 0x4F },       
            {'p' , 0x50 },          
            {'q' , 0x51 },         
            {'r' , 0x52 },          
            {'s' , 0x53 },            
            {'t' , 0x54 },           
            {'u' , 0x55 },          
            {'v' , 0x56 },            
            {'w' , 0x57 },           
            {'x' , 0x58 },
            {'y' , 0x59 },
            {'z' , 0x5A },          
            {'á' , 0xDE },            
            {'é' , 0xBA },          
            {'ó' , 0xBB },           
            {'ú' , 0xDD },           
            {'ö' , 0xC0 },           
            {'ü' , 0xBF }          
        };

        public static readonly Dictionary<Key, char> LatinKey = new Dictionary<Key, char>
        {
            {Key.A, 'a' },
            {Key.B, 'b' },
            {Key.C, 'c' },
            {Key.D, 'd' },
            {Key.E, 'e' },
            {Key.F, 'f' },
            {Key.G, 'g' },
            {Key.H, 'h' },
            {Key.I, 'i' },
            {Key.J, 'j' },
            {Key.K, 'k' },
            {Key.L, 'l' },
            {Key.M, 'm' },
            {Key.N, 'n' },
            {Key.O, 'o' },
            {Key.P, 'p' },
            {Key.Q, 'q' },
            {Key.R, 'r' },
            {Key.S, 's' },
            {Key.T, 't' },
            {Key.U, 'u' },
            {Key.V, 'v' },
            {Key.W, 'w' },
            {Key.X, 'x' },
            {Key.Y, 'y' },
            {Key.Z, 'z' },
            {Key.D1, 'á' },
            {Key.D2, 'é' },
            {Key.D3, 'ó' },
            {Key.D4, 'ú' },
            {Key.D5, 'ö' },
            {Key.D6, 'ü' }
        };

        public static bool ContainsKey<T, U>(Dictionary<T, U> dic, T key)
        {
            List<T> keys = dic.Keys as List<T>;
            return keys.Contains(key);            
        }
    }
}