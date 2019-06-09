using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prototype_p2p
{
    public class ParseKeyID
    {
        public string[] privateKeyArrayPathAppended;
        public string[] publicKeyArrayPathAppended;
        public string[] publicKeyArrayNoPathAppended;
        public string[] privateKeyArrayNoPathAppended;

        char[] strSeperatorKeyInput = new char[] { ';', ',', ' ' };

        /* Constructor that builds arrays containing the keyfile paths
         * no path appended format example: "examplekey_private.asc"
         * path appended format example: "..\\..\\Keys\Private\examplekey_private.asc"
        */
        public ParseKeyID(string keysPathPrivate, string keysPathPublic)
        {
            try
            {
                privateKeyArrayPathAppended = Directory.GetFiles(keysPathPrivate);
                publicKeyArrayPathAppended = Directory.GetFiles(keysPathPublic);
                publicKeyArrayNoPathAppended = Directory.GetFiles(keysPathPublic).Select(p => Path.GetFileName(p)).ToArray();
                privateKeyArrayNoPathAppended = Directory.GetFiles(keysPathPrivate).Select(p => Path.GetFileName(p)).ToArray();
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Keys directory not found!");
                MessageBox.Show("Keys directory not found!");
            }
        }

        // Only used for the CLI, not used in the GUI.
        public void WriteLoadedKeyPaths(bool publicKeyPaths = true, bool privateKeyPaths = true)
        {
            if (privateKeyPaths)
            {
                for (int i = 0; i < privateKeyArrayPathAppended.Length; i++)
                {
                    Console.WriteLine(privateKeyArrayPathAppended[i] + " key ID:" + i);
                }
            }
            if (publicKeyPaths)
            {
                for (int i = 0; i < publicKeyArrayPathAppended.Length; i++)
                {
                    Console.WriteLine(publicKeyArrayPathAppended[i] + " key ID:" + i);
                }
            }
        }


        // Only used by the GUI, used to populate the available key boxes.
        public string ReturnLoadedKeyPathsAsStringNoPathPrefixed(bool privateKeys = false)
        {
            string[] keyArray = !privateKeys ? publicKeyArrayNoPathAppended : privateKeyArrayNoPathAppended;

            string keyPaths = "";
            for (int i = 0; i < keyArray.Length; i++)
            {
                keyPaths = keyPaths + keyArray[i] + Environment.NewLine;
            }
            return keyPaths;
        }



        // Only used by CLI
        public string ParseAndReturnVerifiedKeyPath(bool publicKey = false)
        {
            int keyIdInt = -1;
            bool keyValid = false;
            string[] keyArraytoCheck = publicKey ? publicKeyArrayPathAppended : privateKeyArrayPathAppended;
            while (!keyValid) //checks if the entered key ID is an int and if it is a valid ID number.
            {
                string enteredKey = Console.ReadLine();
                if (int.TryParse(enteredKey, out int enteredKeyInt)) //checks if int
                {
                    enteredKeyInt = Math.Abs(enteredKeyInt); //prevent negative ID's
                    if (enteredKeyInt < keyArraytoCheck.Length) //checks if ID is in range
                    {
                        keyIdInt = enteredKeyInt;
                        keyValid = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write("Enter ID again: ");
                    }
                }
                else
                {
                    Console.WriteLine("The ID must be a number, please try again!");
                    Console.Write("Enter ID again: ");
                }
            }
            if (keyValid)
            {
                return keyArraytoCheck[keyIdInt];
            }
            throw new NotImplementedException();
        }


        // Only used by CLI
        public string[] BuildVerifiedKeyIdPathArray()
        {

            // Used as the while loop exit condition
            bool keyValid = false;
            bool inputIsIntAndInRange = true;
            // Checks if the entered key ID is an int and if it is a valid ID number.
            while (!keyValid) 
            {

                Console.WriteLine("ID's need to seperated using a comma(,) a semicolon(;) or a space.");
                string recipientKeyIds = Console.ReadLine();

                // If the user enters a comma(",") a space(" ") a semicolon(";") or nothing("") the writeline and readline to get key ID's are repeated.
                if (recipientKeyIds == "" || recipientKeyIds == "," || recipientKeyIds == " " || recipientKeyIds == ";")
                {
                    Console.WriteLine("You didn't input anything!");

                    // Restarts the while loop
                    continue;
                }

                // Splits the ID's entered by the user, characters on which the string is split are defined by the class wide char array strSeperatorKeyInput
                string[] recipientKeySplit = recipientKeyIds.Split(strSeperatorKeyInput, StringSplitOptions.RemoveEmptyEntries);
                int[] keyIds = new int[recipientKeySplit.Length];
                for (int i = 0; i < recipientKeySplit.Length; i++)
                {
                    if (int.TryParse(recipientKeySplit[i], out int intValid))
                    {
                        intValid = Math.Abs(intValid);
                        if (intValid < publicKeyArrayPathAppended.Length)
                        {
                            keyIds[i] = intValid;
                        }
                        else
                        {
                            Console.WriteLine("ID's must correspond to an existing key, try again.");
                            inputIsIntAndInRange = false;
                            // Exits the for loop 
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID's must be a number, try again.");
                        inputIsIntAndInRange = false;
                        break;
                    }
                }

                // Restarts the while loop if the user entered anything other than an int or if the user entered an int ID that does not have a corresponding key
                // Implemented because using continue in the for loop would skip a for loop iteration instead of restarting the while loop
                if (!inputIsIntAndInRange)
                {
                    continue;
                }
                string[] recipientKeyPathsArr = new string[keyIds.Length];

                for (int j = 0; j < keyIds.Length; j++)
                {
                    recipientKeyPathsArr[j] = publicKeyArrayPathAppended[keyIds[j]];
                }

                // Ends the while loop
                keyValid = true;
                return recipientKeyPathsArr;
            }
            throw new NotImplementedException();
        }

        }
    }
    



