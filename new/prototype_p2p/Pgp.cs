using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DidiSoft.Pgp;

namespace prototype_p2p
{
    class SignAndEncryptString
    {

        /*
          Useful code examples can be found at https://www.didisoft.com/net-openpgp/examples/openpgp-sign-and-encrypt-in-net/ 
          
          Instructions on how to decrypt pgp messages through the command line can be found at:https://www.gnupg.org/gph/en/manual/x110.html 
          Use the "--ignore-mdc-error" parameter with console decryption if the decryption fails because the integrity is not protected.
         
          TODO: Make used public key a paremeter instead of a hardcoded path.
          TODO: Make the secret key path dynamic to the path where the program is located.
          TODO: Implement multiple recipient support
          Possible idea: use a user editable config file to point to the key locations.
          Possible idea: use keyrings instead of files for keys.
        */
        public static String Demo(string toBeEncryptedData) 
        {

            Console.Write("Please enter the passphrase of the chosen private key: ");
            String privatePassWord = Console.ReadLine();

            // create an instance of the library
            PGPLib pgp = new PGPLib();

            //Sign and encrypt
            //The keys used here are added to the project data, the password for both is "lol". The keys are testing purposes only.
            //Change the paths to the correct path for your pc untill adaptive pathing is implemented.
            try
            {
                String encryptedAndSignedString =
                     pgp.SignAndEncryptString(toBeEncryptedData,
                            new FileInfo(@"C:\Users\robin\Desktop\test keys\testes_secret.asc"), //secret key path
                            privatePassWord, //this is the password of the secret key
                            new FileInfo(@"C:\Users\robin\Desktop\test keys\testos_public.asc")); //public key path

            return encryptedAndSignedString; //Because it returns the encrypted message you can write it in the console, write it to a file or pass the data along. 
            }
            catch (System.IO.IOException e)
            {
                //In case of an input file not found or other I/O related error
                throw new ApplicationException("Error 551: File not found or other I/O related error."+e.Message);
            }
            catch (DidiSoft.Pgp.PGPException e)
            {
                if (e is DidiSoft.Pgp.Exceptions.WrongPrivateKeyException)
                {
                    throw new ApplicationException("Error 552: Key is not a private key.");
                    //The supplied private key source is not a private key at all  
                    //Or in the case with a KeyStore parameter, there is no private key with the specified Key ID or User ID
                }
               else if (e is DidiSoft.Pgp.Exceptions.WrongPasswordException)
                {
                    Console.WriteLine("The entered passphrase is incorrect, please try again.");
                    return  Demo(toBeEncryptedData);
                }
                else if (e is DidiSoft.Pgp.Exceptions.KeyIsExpiredException)
                {
                    throw new ApplicationException("Error 553: Key is expired.");
                    //Can be worked around by setting UseExpiredKeys to true
                }
                else if (e is DidiSoft.Pgp.Exceptions.KeyIsRevokedException)
                {
                    throw new ApplicationException("Error 554: Key is revoked.");
                    //Can be worked around by setting UseRevokedKeys to true
                }
                else
                {
                    throw new ApplicationException("Error 555: Something unexpected went wrong, contact support and explain your actions in detail and chronological order.");
                }
            }
        }
    }
    /*
     class Program
    {
        static void Main1(string[] args)
        {
            Console.Write("Enter the data you want encrypted: ");
            Console.WriteLine(SignAndEncryptString.Demo(Console.ReadLine()));
        }
    }
    */
}

