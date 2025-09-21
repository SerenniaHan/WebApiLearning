using MediatR;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Weapons.Commands.Delete;

internal class DeleteWeaponHandler(ICrudRepository<Weapon> repository)
    : IRequestHandler<DeleteWeaponCommand>
{
    public async Task Handle(DeleteWeaponCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await repository.DeleteByIdAsync(command.Id, cancellationToken);
        }
        catch (Exception e)
        {
            await Task.FromException(e);
        }
    }
}
