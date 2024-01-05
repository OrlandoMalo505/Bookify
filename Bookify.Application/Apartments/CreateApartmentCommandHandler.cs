using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Apartments;
internal sealed class CreateApartmentCommandHandler : ICommandHandler<CreateApartmentCommand, Guid>
{
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateApartmentCommandHandler(IApartmentRepository apartmentRepository, IUnitOfWork unitOfWork)
    {
        _apartmentRepository = apartmentRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<Result<Guid>> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
    {
        var apartment = new Apartment(
            Guid.NewGuid(),
            new Name("name"),
            new Description("desc"),
            new Address("Country", "State", "X", "zip", "str"),
            new Money(100, Currency.Eur),
            new Money(100, Currency.Eur),
            new List<Amenity> { Amenity.WiFi, Amenity.PetFriendly });



        _apartmentRepository.Add(apartment);
        try
        {
            await _unitOfWork.SaveChangesAsync();

            return apartment.Id;
        }
        catch (Exception e)
        {

            throw;
        }

        


    }
}
