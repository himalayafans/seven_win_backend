using SevenWinBackend.Application.Data;
using SevenWinBackend.Domain.Entities;

namespace SevenWinBackend.Application.Services;

/// <summary>
/// Discord图片服务
/// </summary>
public class DiscordImageService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory;

    public DiscordImageService(IUnitOfWorkFactory unitOfWorkFactory)
    {
        this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
    }
}