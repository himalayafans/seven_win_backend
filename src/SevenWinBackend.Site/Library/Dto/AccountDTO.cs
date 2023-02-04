using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Domain.Enums;

namespace SevenWinBackend.Site.Library.Dto
{
    public class AccountDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// 角色
        /// </summary>
        public RolesType Role { get; set; } = RolesType.User;

        /// <summary>
        /// 创建时间
        /// </summary>
        public long CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public long UpdatedAt { get; set; }
    }
}
