using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototype_p2p
{
    class ParseKeyID
    {
        public string[] keyArrayPathAppended;
        public ParseKeyID(string keysPath)
        {
            try
            {
                keyArrayPathAppended = Directory.GetFiles(keysPath);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Keys directory not found!");
            }
        }

        public void WriteAllLoadedKeyPaths()
        {
            for (int i = 0; i<keyArrayPathAppended.Length; i++)
            {
                Console.WriteLine(keyArrayPathAppended[i] + " key ID:" + i);
            }
        }


        public string ParseAndReturnVerifiedKeyPath()
        {
            int keyIdInt = -1;
            bool keyValid = false;
            while (!keyValid) //checks if the entered key ID is an int and if it is a valid ID number.
            {
                string enteredKey = Console.ReadLine();
                if (int.TryParse(enteredKey, out int enteredKeyInt)) //checks if int
                {
                    enteredKeyInt = Math.Abs(enteredKeyInt); //prevent negative ID's
                    if (enteredKeyInt < keyArrayPathAppended.Length) //checks if ID is in range
                    {
                        keyIdInt = enteredKeyInt;
                        keyValid = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The entered ID has no corresponding key, please enter the ID of an existing key!");
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
                return keyArrayPathAppended[keyIdInt];
            }
            throw new NotImplementedException();
        }
        public string[] BuildVerifiedKeyIdPathArray()
        {

            
            bool keyValid = false;
            bool inputIsIntAndInRange = true;
            while (!keyValid) //checks if the entered key ID is an int and if it is a valid ID number.
            {

                Console.WriteLine("ID's need to seperated using a comma(,) or a semicolon(;).");
                string recipientKeyIds = Console.ReadLine();
                if (recipientKeyIds == "" || recipientKeyIds == "," || recipientKeyIds == ";")
                {
                    Console.WriteLine("You didn't input anything!");
                    continue;
                }

                char[] strSeperatorKeyInput = new char[] { ';', ',' };
                string[] recipientKeySplit = recipientKeyIds.Split(strSeperatorKeyInput, StringSplitOptions.RemoveEmptyEntries);

                int[] keyIds = new int[recipientKeySplit.Length];
                for (int i = 0; i < recipientKeySplit.Length; i++)
                {
                    if(int.TryParse(recipientKeySplit[i],out int intValid))
                    {
                        intValid = Math.Abs(intValid);
                        if (intValid < keyArrayPathAppended.Length)
                        {
                            keyIds[i] = intValid;
                        }
                        else
                        {
                            Console.WriteLine("ID's must correspond to an existing key, try again.");
                            inputIsIntAndInRange = false;
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
                if (!inputIsIntAndInRange)
                {
                    continue;
                }
                string[] recipientKeyPathsArr = new string[keyIds.Length];

                for (int j = 0; j < keyIds.Length; j++)
                {
                    recipientKeyPathsArr[j] = keyArrayPathAppended[keyIds[j]];
                }
                keyValid = true;
                return recipientKeyPathsArr;
            }
            throw new NotImplementedException();
        }
    }

}
