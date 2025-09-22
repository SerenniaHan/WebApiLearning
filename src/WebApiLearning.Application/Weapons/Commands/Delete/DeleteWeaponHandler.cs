using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Weapons.Commands.Delete;

internal class DeleteWeaponHandler(IWeaponRepository repository)
    : IRequestHandler<DeleteWeaponCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(
        DeleteWeaponCommand command,
        CancellationToken cancellationToken
    )
    {
        try
        {
            return await repository.DeleteByIdAsync(command.Id, cancellationToken);
        }
        catch (Exception e)
        {
            return new Result<bool>(e);
        }
    }
}
