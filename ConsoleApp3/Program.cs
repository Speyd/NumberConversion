

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
    if (binaryText.Length < 5)
        throw new Exception("Size binaryText less than 5");

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
    Console.WriteLine(binaryToDecimal("10000000"));
    Console.WriteLine(convertDecimalFractionToBinary(0.421, 4));
}catch(Exception e)
{
    Console.WriteLine(e.Message);
}