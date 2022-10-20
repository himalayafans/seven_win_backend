namespace SevenWinBackend.Common;

/// <summary>
/// List扩展方法
/// </summary>
public static class ListExtensions
{
    /// <summary>
    /// 随机从获取List中获取Item
    /// </summary>
    public static T GetRandomItem<T>(this List<T> list)
    {
        if (list.Count == 0)
        {
            throw new ArgumentNullException(nameof(list));
        }
        Random r = new Random();
        int randIndex  = r.Next(0, list.Count);
        return list[randIndex];
    }
}