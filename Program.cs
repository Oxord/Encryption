public class CaesarCipher
{
    const string RussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
    const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    private string CodeEncode(string text, int k, string language)
    {
        int letterQty;
        string fullalphabet;
        if (language == "русский"){ 
            fullalphabet = RussianAlphabet + RussianAlphabet.ToLower();
            letterQty = fullalphabet.Length;}
        else{
            fullalphabet = EnglishAlphabet + EnglishAlphabet.ToLower();
            letterQty = fullalphabet.Length;}

        var result = "";
        for (int i = 0; i < text.Length; i++)
        {
            var symbol = text[i];
            var temp = fullalphabet.IndexOf(symbol);
            if (temp < 0)
            {
                result += symbol.ToString();
            }
            else
            {
                var Index = (letterQty + temp + k) % letterQty;
                result += fullalphabet[Index];
            }
        }

        return result;
    }
    public string Encrypt(string Message, int key, string language)
        => CodeEncode(Message, key, language);

    public string Decrypt(string encryptedMessage, int key, string language)
        => CodeEncode(encryptedMessage, -key, language);
}

class Program
{
    static void Main(string[] args)
    {
        var cipher = new CaesarCipher();
        Console.Write("Введите текст: ");
        var text = Console.ReadLine();
        Console.Write("Введите ключ(для расшифровки используйте отрицательное число): ");
        var step = Convert.ToInt32(Console.ReadLine());
        Console.Write("На каком языке текст, который вы ввели(русский, английский): ");
        string language = Console.ReadLine();
        var encryptedText = cipher.Encrypt(text, step, language);
        Console.WriteLine("Зашифрованное сообщение: {0}", encryptedText);
        Console.WriteLine("Расшифрованное сообщение: {0}", cipher.Decrypt(encryptedText, step, language));
        Console.ReadLine();
    }
}
