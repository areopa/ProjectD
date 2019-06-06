using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DidiSoft.Pgp;
using System.Windows.Forms;

namespace prototype_p2p
{
    class SignAndEncryptString
    {

        /* 
          Instructions on how to decrypt pgp messages through the command line can be found at:https://www.gnupg.org/gph/en/manual/x110.html 
          Use the "--ignore-mdc-error" parameter with console decryption if the decryption fails because the integrity is not protected.
        */
        public static String StringEncrypter(string toBeEncryptedData, string secretKeyPath, string publicKeyPath)
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
                            new FileInfo(secretKeyPath), //secret key path
                            privatePassWord, //this is the password of the secret key
                            new FileInfo(publicKeyPath)); //public key path

                return encryptedAndSignedString; //Because it returns the encrypted message you can write it in the console, write it to a file or pass the data along. 
            }
            catch (System.IO.IOException e)
            {
                //In case of an input file not found or other I/O related error
                throw new ApplicationException("Error 551: File not found or other I/O related error." + e.Message);
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
                    return StringEncrypter(toBeEncryptedData, secretKeyPath, publicKeyPath);
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
    class EncryptFileMultipleRecipients
    {

        public void EncryptFileMultiRec(string[] recipientPublicKeyPaths, string inputFilePath, string outputPathName, string privateKeyfile)
        {
            string privatePassWord;
            
            
                Console.Write("Please enter the passphrase of the chosen private key: ");
                privatePassWord = Console.ReadLine();
           
            
               
            
            

            // create an instance of the library
            PGPLib pgp = new PGPLib();

            // specify should the output be ASCII or binary
            bool asciiArmor = true;
            // should additional integrity information be added
            // set to true for compatibility with GnuPG 2.2.8+
            bool withIntegrityCheck = true;

            FileInfo inputFile = new FileInfo(inputFilePath);
            //FileInfo privateKey = new FileInfo(privateKeyfile);
            FileInfo outputname = new FileInfo(outputPathName);

            FileInfo[] fileinputs = new FileInfo[recipientPublicKeyPaths.Length];

            int i = 0;
            foreach (string s in recipientPublicKeyPaths)
            {
                fileinputs[i] = new FileInfo(s);
                i++;
            }


            pgp.SignAndEncryptFile(inputFile, new FileInfo(privateKeyfile), privatePassWord, fileinputs,
                outputname, asciiArmor, withIntegrityCheck);



            //    pgp.EncryptFile(inputFilePath,
            //           recipientPublicKeyPaths,
            //          outputPathName,
            //         asciiArmor,
            //        withIntegrityCheck);
        }

        public static String MultiRecipientStringEncrypter(string toBeEncryptedData, string secretKeyPath, string[] recipientPublicKeyPaths, bool gui = false)
        {
            string privatePassWord;

            FileInfo secKeyPathInfo = new FileInfo(secretKeyPath);
            FileStream secKeyStream = secKeyPathInfo.OpenRead();

            
            PGPLib pgp = new PGPLib();
            MemoryStream streamString = new MemoryStream(Encoding.UTF8.GetBytes(toBeEncryptedData));
            

            FileStream[] recipientPublicKeyPathsStream = new FileStream[recipientPublicKeyPaths.Length];
            for(int i = 0; i < recipientPublicKeyPaths.Length; i++)
            {
                FileInfo publicKeyInfo = new FileInfo(recipientPublicKeyPaths[i]);
                recipientPublicKeyPathsStream[i] = publicKeyInfo.OpenRead();
            }


            if (!gui)
            {
                Console.Write("Please enter the passphrase of the chosen private key: ");
                privatePassWord = Console.ReadLine();
            }
            else
            {
                privatePassWord = Prompt.ShowDialog("Enter the password of the chosen secret key", "Password entry",false,false,false);
            }

            MemoryStream encryptedOutputStream = new MemoryStream();
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string filler = unixTimestamp.ToString(); //needed for the encryption, decided that it may as well have a semi-useful value

            pgp.SignAndEncryptStream(streamString, filler, secKeyStream, privatePassWord, recipientPublicKeyPathsStream, encryptedOutputStream, true, true);
            string encryptedMultiRecipientString = Encoding.ASCII.GetString(encryptedOutputStream.ToArray());


            return encryptedMultiRecipientString;
        }       
    }

    class DecryptAndVerifyString
    {
        public static void Decrypt(string encryptedMessage, string secretKeyPath, string publicKeyPath, bool gui = false)
        {
            string plainTextExtracted;
            string privatePassWord;
            if (!gui)
            {
                Console.Write("Please enter the passphrase of the chosen private key: ");
                privatePassWord = Console.ReadLine();
            }
            else
            {
                privatePassWord = Prompt.ShowDialog("Enter the password of the chosen secret key", "Password entry",false,false,false);
            }


            // create an instance of the library
            PGPLib pgp = new PGPLib();

            // decrypt and verify
            try
            {
                SignatureCheckResult signatureCheck =
                    pgp.DecryptAndVerifyString(encryptedMessage,
                             new FileInfo(secretKeyPath), //secret key path
                             privatePassWord, //this is the password of the secret key
                             new FileInfo(publicKeyPath),
                             out string plainTextExtract);
                plainTextExtracted = plainTextExtract;

                // print the results
                if (signatureCheck == SignatureCheckResult.SignatureVerified)
                {
                    Console.WriteLine("Signature OK");
                    if (gui)
                        MessageBox.Show("Signature OK");
                }
                else if (signatureCheck == SignatureCheckResult.SignatureBroken)
                {
                    Console.WriteLine("Signature of the message is either broken or forged");
                    if (gui)
                        MessageBox.Show("Signature of the message is either broken or forged");
                }
                else if (signatureCheck == SignatureCheckResult.PublicKeyNotMatching)
                {
                    Console.WriteLine("The provided public key doesn't match the signature");
                    if (gui)
                        MessageBox.Show("The provided public key doesn't match the signature");
                }
                else if (signatureCheck == SignatureCheckResult.NoSignatureFound)
                {
                    Console.WriteLine("This message is not digitally signed");
                    if (gui)
                        MessageBox.Show("This message is not digitally signed");
                }


                if (!gui)
                {
                    Console.WriteLine("Extracted message: \n" + plainTextExtracted);
                }
                else
                {
                    SimpleReportViewer.ShowDialog(plainTextExtracted, "Decrypted data", Program.form1);
                }
            }
            catch (Exception e)
            {
                if (e is DidiSoft.Pgp.Exceptions.WrongPrivateKeyException)
                {
                    Console.WriteLine("The chosen private key is either not a private key or not suited to decrypt this message.");
                    if (gui)
                        MessageBox.Show("The chosen private key is either not a private key or not suited to decrypt this message.");
                    //The supplied private key source is not a private key at all  

                }
                else if (e is DidiSoft.Pgp.Exceptions.WrongPasswordException)
                {
                    Console.WriteLine("The entered passphrase is incorrect, please try again.");
                    if (!gui)
                    {
                        Decrypt(encryptedMessage, secretKeyPath, publicKeyPath);
                    }
                    else
                    {
                        MessageBox.Show("The entered passphrase is incorrect, please try again.");
                    }
                }
                else if (e is DidiSoft.Pgp.Exceptions.WrongPublicKeyException)
                {
                    
                    if (!gui)
                    {
                        Console.WriteLine("The chosen public key is either not a public key or not suited to verify this message.");
                    }
                    else
                    {
                        MessageBox.Show("The chosen public key is either not a public key or not suited to verify this message.");
                    }
                }
                else if (e is DidiSoft.Pgp.Exceptions.KeyIsExpiredException)
                {
                    Console.WriteLine("The public key you want to encrypt for is expired and cannot be used.");
                    if (gui)
                        MessageBox.Show("The public key you want to encrypt for is expired and cannot be used.");
                    //Can be worked around by setting UseExpiredKeys to true
                }
                else if (e is DidiSoft.Pgp.Exceptions.KeyIsRevokedException)
                {
                    Console.WriteLine("The public key you want to encrypt for appears to be revoked and cannot be used.");
                    if (gui)
                        MessageBox.Show("The public key you want to encrypt for appears to be revoked and cannot be used.");
                    //Can be worked around by setting UseRevokedKeys to true
                }
                else if (e is DidiSoft.Pgp.Exceptions.NonPGPDataException)
                {
                    Console.WriteLine("The data you want to decrypt is not encrypted with PGP.");
                    if (gui)
                        MessageBox.Show("The data you want to decrypt is not encrypted with PGP.");
                    //Can be worked around by setting UseRevokedKeys to true
                }
                else if (e is IOException)
                {
                    Console.WriteLine("IO Exception has occured, decrypting of unencrypted data is not possible.");
                    if (gui)
                        MessageBox.Show("IO Exception has occured, decrypting of unencrypted data is not possible.");
                    //Can be worked around by setting UseRevokedKeys to true
                }
                else
                {
                    throw new ApplicationException("Something unexpected went wrong, contact support and explain your actions in detail and chronological order.");
                }
            }
        }
        
    }

}

