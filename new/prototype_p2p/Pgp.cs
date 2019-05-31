using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DidiSoft.Pgp;

namespace decryptionTesting //prototype_p2p
    /*
    Change the namespace back to prototype_p2p when the class needs to be integrated with the rest of the program
    The seperate namespace is just for easy testing withnout needing to change any other class/component 
    */
{
    class SignAndEncryptString
    {

        /*
          Useful code examples can be found at https://www.didisoft.com/net-openpgp/examples/openpgp-sign-and-encrypt-in-net/ 
          
          Instructions on how to decrypt pgp messages through the command line can be found at:https://www.gnupg.org/gph/en/manual/x110.html 
          Use the "--ignore-mdc-error" parameter with console decryption if the decryption fails because the integrity is not protected.
         
          TODO: Add a simple error message if the wrong private key passphrase is entered.
          TODO: Make used public key a paremeter instead of a hardcoded path.
          TODO: Make the secret key path dynamic to the path where the program is located.
          TODO: Implement multiple recipient support
          Possible idea: use keyrings instead of files for keys.
        */
        public static String Demo(string toBeEncryptedData) //this paramter can be commented out if asking for the data later is desired.
        {

            String plainText = toBeEncryptedData; //this is here if a parameter is desired instead of the current readline
            //Console.WriteLine("Please enter the data you want to encrypt");
            //String plainText = Console.ReadLine();
            Console.Write("Please enter the passphrase of the chosen private key: ");
            String privatePassWord = Console.ReadLine();

            // create an instance of the library
            PGPLib pgp = new PGPLib();

            // sign and encrypt
            // The keys used here are added to the project data, the password for both is "lol". The keys are testing purposes only.
            String encryptedAndSignedString =
                 pgp.SignAndEncryptString(plainText,
                        new FileInfo(@"C:\Users\robin\Desktop\test keys\testes_secret.asc"), //secret key path
                        privatePassWord, //this is the password of the secret key
                        new FileInfo(@"C:\Users\robin\Desktop\test keys\testos_public.asc")); //public key path

            return encryptedAndSignedString; //Because it returns the encrypted message you can write it in the console, write it to a file or pass the data along. 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the data you want encrypted: ");
            Console.WriteLine(SignAndEncryptString.Demo(Console.ReadLine()));
        }
    }
}

