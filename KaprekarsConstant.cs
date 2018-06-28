/*Using the C# language, have the function KaprekarsConstant(num) take the num parameter being passed which will be a 4-digit number with 
at least two distinct digits. Your program should perform the following routine on the number: Arrange the digits in descending order and 
in ascending order (adding zeroes to fit it to a 4-digit number), and subtract the smaller number from the bigger number. Then repeat the 
previous step. Performing this routine will always cause you to reach a fixed number: 6174. Then performing the routine on 6174 will always 
give you 6174 (7641 - 1467 = 6174). Your program should return the number of times this routine must be performed until 6174 is reached. 
For example: if num is 3524 your program should return 3 because of the following steps: 
(1) 5432 - 2345 = 3087, (2) 8730 - 0378 = 8352, (3) 8532 - 2358 = 6174. 
*/

using System;

class MainClass
{
    public static int KaprekarsConstant(int num)
    {
        String strNum = num.ToString();
        Char[] asc = new Char[4];
        Char[] dsc = new Char[4];
        Char temp;
        int ascNum, dscNum, diff;
        int count = 0;
        diff = num;
        bool swap=false;
        int length = 0;
        while (diff != 6174)
        {
            strNum = diff.ToString();
            if (strNum.Length < 4)  //fill in missing zeros to bring digit count to 4
            {
                length = strNum.Length;
                for (int x = 0; x < 4 - length; x++)
                {
                    strNum = strNum + "0";
                }
            }
            for (int x = 0; x < 4; x++)
            {
                asc[x] = strNum[x]; //copy string form of number to character arrays for sorting
                dsc[x] = strNum[x];
            }
            do
            {
                swap = false;
                for (int x = 0; x < 3; x++)
                {
                    if (asc[x] > asc[x + 1])
                    {
                        temp = asc[x];
                        asc[x] = asc[x + 1];
                        asc[x + 1] = temp;
                        swap = true;
                    }
                }
            } while (swap);
            swap = false;
            do
            {
                swap = false;
                for (int x = 0; x < 3; x++)
                {
                    if (dsc[x] < dsc[x + 1])
                    {
                        temp = dsc[x];
                        dsc[x] = dsc[x + 1];
                        dsc[x + 1] = temp;
                        swap = true;
                    }
                }
            } while (swap);
            ascNum = Convert.ToInt32(new String(asc));
            dscNum = Convert.ToInt32(new String(dsc));
            diff = dscNum - ascNum;
            Console.WriteLine("(" + (count + 1) + ")  " + dscNum + " - " + ascNum + " = " + diff);
            count++;
        }
        Console.WriteLine();
        return count;
    }

    static void Main()
    {
        Console.Write("Enter an integer:  ");
        int x=Convert.ToInt32(Console.ReadLine());
        Console.Write(KaprekarsConstant(Convert.ToInt32(x)));
        Console.Write(" times to reach 6174");
        Console.ReadKey();
    }
}