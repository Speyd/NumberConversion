

string positiveDecimalToBinary(int decimalNum)
{
    if (decimalNum < 0)
        throw new Exception("Add negative decimalNum in method 'positiveDecimalToBinary'");

    string result = "";
    for (; decimalNum > 0; decimalNum /= 2)
    {
        if(decimalNum % 2 == 0)
            result += '0';
        else if(decimalNum % 2 != 0)
        {
            decimalNum--;
            result += '1';
        }
    }
    result += "0";

    return new string(result.Reverse().ToArray());
}
string reverseBinaryText(string text)
{
    char[] resultArray = text.ToCharArray();

    for (int i = 0; i < resultArray.Length; i++)
    {
        if (resultArray[i] == '1')
            resultArray[i] = '0';
        else if (resultArray[i] == '0')
            resultArray[i] = '1';
    }

    return new string(resultArray);
}
string negativeDecimalToBinary(int decimalNum)
{
    decimalNum = decimalNum < 0 ? decimalNum * -1 : throw new Exception("Add positive decimalNum in method 'negativeDecimalToBinary'");
    char[] resultArray = reverseBinaryText(positiveDecimalToBinary(decimalNum)).ToCharArray();

    int numberMind = 1;
    for (int i = resultArray.Length - 1; i >= 0; i--)
    {
        if (resultArray[i] == '0' && numberMind == 1)
        {
            resultArray[i] = '1';
            numberMind = 0;
        }
        else if (resultArray[i] == '1' && numberMind == 1)
            resultArray[i] = '0';
        else
            break;
    }

    return new string(resultArray);
}
int binaryToDecimal(string binaryText)
{
    if (binaryText.Length <= 1)
        throw new Exception("Incorrect length (<= 1)");

    int result = 0;

    string tempText = binaryText;
    if (binaryText.First() == '1')
        tempText = reverseBinaryText(tempText);

    for(int exponent = 0, index = tempText.Length - 1; index > 0 ; exponent++, index--)
    {
        result += (int)(Convert.ToInt32(tempText[index].ToString()) * Math.Pow(2, exponent));
    }

    return binaryText.First() == '0' ? result : (result + 1) * -1;
}

int sumBinaryNumbersFunc(string firstBinary, string secondBinary)
{
    if (firstBinary == secondBinary)
        return binaryToDecimal(firstBinary) * 2;

    return binaryToDecimal(firstBinary) + binaryToDecimal(secondBinary);
}

#region Sum
void checkSizeText(ref string checkText, int size)
{
    if (checkText.Length < size)
        checkText = checkText.Insert(0, checkText.First().ToString());
}
void lengthEqualization(ref string firstBinary, ref string secondBinary)
{
    if (firstBinary == secondBinary)
        return;

    int maxSize = firstBinary.Length > secondBinary.Length ? firstBinary.Length : secondBinary.Length;
    int minSize = firstBinary.Length < secondBinary.Length ? firstBinary.Length : secondBinary.Length;

    for (int i = minSize + 1; i <= maxSize; i++)
    {
        checkSizeText(ref firstBinary, maxSize);
        checkSizeText(ref secondBinary, maxSize);
    }
}
char resultAddingBits(int index, ref int numberMind, ref string firstBinary, ref string secondBinary)
{
    if (numberMind == 1)
    {
        if (firstBinary[index] == '1' && secondBinary[index] == '1')
            return '1';
        if (firstBinary[index] == '0' && secondBinary[index] == '0')
        {
            numberMind = 0;
            return '1';
        }
        else
            return '0';
    }
    else if (numberMind == 0)
    {
        if (firstBinary[index] == '1' && secondBinary[index] == '1')
        {
            numberMind = 1;
            return '0';
        }
        if (firstBinary[index] == '0' && secondBinary[index] == '0')
            return '0';
        else
            return '1';
    }
    else
        throw new Exception("numberMind Error value!");
}
int sumBinaryNumbers(string firstBinary, string secondBinary)
{
    if(firstBinary.Length <= 1 || secondBinary.Length <= 1)
        throw new Exception("Incorrect firstBinary or secondBinary length (<= 1)");

    string result = "";
    int numberMind = 0;
    lengthEqualization(ref firstBinary, ref secondBinary);

    for(int i = firstBinary.Length - 1; i >= 0; i--)
    {
        result = result.Insert(0, resultAddingBits(i, ref numberMind, ref firstBinary, ref secondBinary).ToString());
    }

    return binaryToDecimal(result);
}
#endregion
string convertDecimalFractionToBinary(double decimalFraction, int precision)
{
    string result = "0.";
    double fraction = decimalFraction;

    for (int i = 0; i < precision; i++)
    {
        fraction *= 2;
        int bit = (int)fraction;
        result += bit.ToString();
        fraction -= bit;

        if (fraction == 0)
            break;
    }

    while (result.Length < precision + 2)
    {
        result += "0";
    }

    return result;
}

try
{
    Console.WriteLine(positiveDecimalToBinary(105));
    Console.WriteLine(negativeDecimalToBinary(-105));
    Console.WriteLine($"Manual sum: {sumBinaryNumbers("0000000000001101", "111011")}");
    Console.WriteLine($"Func sum: {sumBinaryNumbersFunc("0000000000001101", "111011")}");
    Console.WriteLine(binaryToDecimal("1111111111111011"));
    Console.WriteLine(binaryToDecimal("01101"));
    Console.WriteLine(binaryToDecimal("00010111"));
    Console.WriteLine(convertDecimalFractionToBinary(0.421, 4));
}catch(Exception e)
{
    Console.WriteLine(e.Message);
}