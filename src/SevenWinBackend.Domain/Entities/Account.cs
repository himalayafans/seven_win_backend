using SevenWinBackend.Common;
using SevenWinBackend.Domain.Base;
using SevenWinBackend.Domain.Enums;

namespace SevenWinBackend.Domain.Entities;

/// <summary>
/// 登录账户
/// </summary>
public class Account : BaseEntity
{
    /// <summary>
    /// 账户名称
    /// </summary>
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// 登录密码(哈希值)
    /// </summary>
    public string PasswordHash { get; set; } = String.Empty;

    /// <summary>
    /// 角色
    /// </summary>
    public RolesType Role { get; set; } = RolesType.User;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// 创建登录账户
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public static Account Create(string name, string password, RolesType role = RolesType.User)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentNullException(nameof(password));
        }
        return new Account()
        {
            Id = Guid.NewGuid(),
            Name = name.Trim().ToLower(),
            PasswordHash = password.Trim().ToSha256Hash(),
            Role = role,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }
    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="newPassword">新的密码明文</param>
    public void ModifyPassword(string newPassword)
    {
        PasswordHash = newPassword.Trim().ToSha256Hash();
        UpdatedAt = DateTime.Now;
    }
    /// <summary>
    /// 验证密码是否正确
    /// </summary>
    /// <param name="password">密码明文</param>
    /// <returns>正确则返回true，否则返回false</returns>
    public bool VerifyPassword(string password)
    {
        return PasswordHash == password.Trim().ToSha256Hash();
    }
}