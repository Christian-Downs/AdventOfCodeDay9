using System;
using System.Collections.Generic;
using System.IO;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> inputList = new List<long>();
            StreamReader reader = File.OpenText("input.txt");

            int howFarBack = 25;

            while(!reader.EndOfStream)
            {
                long currentNumber = long.Parse(reader.ReadLine());
                inputList.Add(currentNumber);
                
            }
            reader.Close();

            int index1 = 0;
            for(; index1<inputList.Count; index1++)
            {
                
                bool valid = false;
                if(index1>=howFarBack)
                {
                    long currentNumberToEqual = inputList[index1];
                    for(int index2 = index1-howFarBack; index2<index1; index2++)
                    {
                        for(int index3 = index1-howFarBack;index3<index1;index3++)
                        {
                            if(index3!=index2)
                            {
                                if(currentNumberToEqual==inputList[index2]+inputList[index3])
                                {

                                    valid = true;
                                    index2++;
                                    break;
                                }
                            }
                        }
                        if(valid)
                        {
                            break;
                        }


                    }
                    if(!valid)
                    {
                        Console.WriteLine(currentNumberToEqual);
                        bool found = false;
                        for (int index2 = 0; index2 < index1 && !found; index2++)
                        {
                            
                            for (int index3 = 1; index3 < index1 && !found; index3++)
                            {
                                long sumOfTheSetOfNumbers = 0,
                                     highestNumber = 0,
                                     smallestNumber = 0,
                                     currentNumber = 0;
                                if(index3>index2)
                                {
                                   
                                    for(int index4 = index2; index4<=index3 && !found;index4++)
                                    {
                                        if (smallestNumber == 0)
                                            smallestNumber = inputList[index4];
                                        currentNumber = inputList[index4];

                                        if (currentNumber > highestNumber)
                                            highestNumber = currentNumber;
                                        else if (currentNumber < smallestNumber)
                                            smallestNumber = currentNumber;
                                        sumOfTheSetOfNumbers += inputList[index4];
                                        if(sumOfTheSetOfNumbers==currentNumberToEqual)
                                        {
                                            //Console.WriteLine(inputList[index3] + " " + inputList[index2]);
                                            //Console.WriteLine(highestNumber + " " + smallestNumber);
                                            Console.WriteLine(highestNumber + smallestNumber);
                                            found = true;
                                        }
                                        else if(sumOfTheSetOfNumbers>currentNumberToEqual)
                                        {
                                            break;
                                        }
                                    }
                                }
                                else if (index3<index2)
                                {
                                    for (int index4 = index3; index4 <= index2; index4++)
                                    {
                                        if (smallestNumber == 0)
                                            smallestNumber = inputList[index4];
                                        currentNumber = inputList[index4];

                                        if (currentNumber > highestNumber)
                                            highestNumber = currentNumber;
                                        else if (currentNumber < smallestNumber)
                                            smallestNumber = currentNumber;
                                        
                                        sumOfTheSetOfNumbers += inputList[index4];
                                        if (sumOfTheSetOfNumbers == currentNumberToEqual)
                                        {
                                            //Console.WriteLine(inputList[index3] + " " + inputList[index2]);
                                            Console.WriteLine(highestNumber  + smallestNumber);
                                        }
                                        else if (sumOfTheSetOfNumbers > currentNumberToEqual)
                                        {
                                            break;
                                        }
                                    }
                                }
                                
                            }
                        }
                    }
                }
                else
                {
                    valid = true;
                }
                if(!valid)
                {
                    break;
                }
            }

        }
    }
}
