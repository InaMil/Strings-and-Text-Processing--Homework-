//7.Write a program that encodes and decodes a string using given encryption key (cipher). 
//The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) 
//operation over the first letter of the string with the first of the key, the second – with the second, etc. 
//When the last key character is reached, the next is the first.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EncodeDecodeString
{
    static void Main()
    {
        string message = "Some secret text message";
        string key1 = "*7/.+-=:1";
        string key2 = "85*%+=%2*+/&#!4";
        
        Console.Write("The encrypted text is:".PadRight(25));
        string encrypted = Encrypt(message, key1);
        Console.WriteLine(encrypted);

        Console.Write("The original message is: ");
        string decrypted = Decrypt(encrypted, key1, key2);
        Console.WriteLine(decrypted);
    }

    static string Encrypt(string message, string key)
    {

        StringBuilder encryptedMessage = new StringBuilder();
        for (int i = 0, k = 0; i < message.Length; i++, k++)
        {
            if (k == key.Length)
            {
                k = 0;
            }
            encryptedMessage.Append((char)(message[i] ^ key[k]));
        }

        return encryptedMessage.ToString();
    }
    static string Decrypt(string encryptedMessage, string key1, string key2)
    {
        StringBuilder decryptedMessage = new StringBuilder();
        encryptedMessage = Encrypt(encryptedMessage, key2); //encrypt wiht first key
        encryptedMessage = Encrypt(encryptedMessage, key2); //decrypt with first key 

        for (int i = 0, k = 0; i < encryptedMessage.Length; i++, k++)
        {
            if (k == key1.Length)
            {
                k = 0;
            }
            decryptedMessage.Append((char)(encryptedMessage[i] ^ key1[k]));
        }
        return decryptedMessage.ToString();
                
    }
}
