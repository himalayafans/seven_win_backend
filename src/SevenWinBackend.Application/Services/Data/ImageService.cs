using SevenWinBackend.Application.Data;
using SevenWinBackend.Domain.Entities;

namespace SevenWinBackend.Application.Services.Data;

/// <summary>
/// 图片服务
/// </summary>
public class ImageService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory;

    public ImageService(IUnitOfWorkFactory unitOfWorkFactory)
    {
        this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
    }
    public async Task Add(Image image)
    {
        if (image == null)
        {
            throw new ArgumentNullException(nameof(image));
        }
        using var work = unitOfWorkFactory.Create();
        await work.Image.Insert(image);
    }

    /// <summary>
    /// 通过原始文件哈希值获取图片
    /// </summary>
    public async Task<Image?> GetWithOriginalFileHash(string hash)
    {
        using var work = unitOfWorkFactory.Create();
        return await work.Image.GetByOriginalFileHash(hash);
    }
    public async Task<Image?> getByDiscordUrl(string url)
    {
        using var work = unitOfWorkFactory.Create();
        return await work.Image.GetByDiscordUrl(url);
    }
}