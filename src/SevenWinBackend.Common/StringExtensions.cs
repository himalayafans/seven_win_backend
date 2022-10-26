using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace SevenWinBackend.Common;

public static class StringExtensions
{
    private const string Md5Key = "@ab+&?###";

    /// <summary>
    /// 将字符串转换为蛇形命名法
    /// <example>
    /// For example: LiveKarma -> live_karma
    /// </example>
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public static string ToSnakeCase(this string text)
    {
        // 代码来源：https://stackoverflow.com/a/63055998
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentNullException(nameof(text));
        }
        if (text.Length < 2)
        {
            return text.ToLower();
        }
        var sb = new StringBuilder();
        sb.Append(char.ToLowerInvariant(text[0]));
        for (int i = 1; i < text.Length; ++i)
        {
            char c = text[i];
            if (char.IsUpper(c))
            {
                sb.Append('_');
                sb.Append(char.ToLowerInvariant(c));
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// 判断是否包含子字符串（忽略大小写）
    /// </summary>
    public static bool ContainsIgnoreCase(this string? source, string childString)
    {
        return source?.IndexOf(childString, StringComparison.OrdinalIgnoreCase) >= 0;
    }

    /// <summary>
    /// 检查一个字符串是否是数字
    /// </summary>
    public static bool IsDecimal(this string source)
    {
        // 参考资料 https://www.c-sharpcorner.com/blogs/c-sharp-hidden-gems-sharp1-discards-variable
        return decimal.TryParse(source, out _);
    }

    /// <summary>
    /// 检查一个字符串是否是整数
    /// </summary>
    public static bool IsInteger(this string source)
    {
        return int.TryParse(source, out _);
    }

    /// <summary>
    /// 获取该字符串的SHA256哈希值
    /// </summary>
    public static string ToSha256Hash(this string text)
    {
        // 代码来源：https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/
        text = text + Md5Key;
        using SHA256 sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));
        StringBuilder builder = new StringBuilder();
        foreach (var t in bytes)
        {
            builder.Append(t.ToString("x2"));
        }
        return builder.ToString();
    }

    /// <summary>
    /// BASE64编码
    /// </summary>
    public static string ToBase64(this string plainText)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }

    /// <summary>
    /// BASE64解码
    /// </summary>
    public static string FromBase64(this string base64)
    {
        var base64EncodedBytes = Convert.FromBase64String(base64);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }
    /// <summary>
    /// 判断字符串是否是Uri
    /// </summary>
    public static bool IsUri(this string text)
    {
        return Uri.TryCreate(text, UriKind.Absolute, out _);
    }
    /// <summary>
    /// 判断字符串是否是全字母
    /// </summary>
    public static bool IsOnlyLetters(this string text)
    {
        return Regex.IsMatch(text, @"^[a-zA-Z]+$");
    }
    /// <summary>
    /// 获取URL的文件扩展名(不支持带？查询字符串的URL)
    /// </summary>
    public static string GetFileExtensionFromUrl(this string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentNullException(nameof(url));
        }
        // 代码来源： https://stackoverflow.com/a/52748299
        string result = Path.GetExtension(url);
        if (!result.IsOnlyLetters())
        {
            throw new InvalidOperationException($"URL参数不符合规范：{url}");
        }
        return result.ToLower();
    }
}