using AutoMapper;
using Bookly.Application.Common.Exceptions;
using Bookly.Domain.Repositories ;
using Bookly.Domain.UnitOfWorks;
using MediatR;
using Kategori = Bookly.Domain.Entities.Category;
namespace Bookly.Application.Features.Commands.Category.CreateCategory;

internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
{
    private readonly IRepository<Domain.Entities.Category> _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(IRepository<Domain.Entities.Category> categoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var exists = _categoryRepository.GetWhere(c => c.Name.Equals(request.Name)).Any();
        if (exists)
            throw new BusinessException("Bu İsimde Bir Kategori Zaten Mevcuttur.");

        Kategori category = _mapper.Map<Kategori>(request);
        await _categoryRepository.AddAsync(category,cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateCategoryCommandResponse("Kategori Bilgisi Başarıyla Oluşturuldu.");
    }
}
