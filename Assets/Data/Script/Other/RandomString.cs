using System;

public class RandomString
{
    private const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

    public static string GetRandomString(int length)
    {
        string result = "";

        if (length <= 0) return result;
        for (int i = 0; i < length; i++)
        {
            int order = UnityEngine.Random.Range(0, chars.Length);
            result += chars[order];
        }

        return result;
    }
}
