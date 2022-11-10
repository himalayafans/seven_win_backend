using SevenWinBackend.Application.Data;
using SevenWinBackend.Domain.Entities;

namespace SevenWinBackend.Application.Services.Data;

public class ImageService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory;

    public ImageService(IUnitOfWorkFactory unitOfWorkFactory)
    {
        this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
    }

    /// <summary>
    /// 通过原始文件哈希值获取图片
    /// </summary>
    public async Task<Image> GetWithOriginalFileHash(string hash)
    {
        using var work = unitOfWorkFactory.Create();
        return await work.DiscordImage.GetOriginalFileHash(hash);
    }
}