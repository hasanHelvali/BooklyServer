using Bookly.Application.Features.Commands.Product.CreateProduct;
using Bookly.Application.Features.Commands.Product.DeleteProductById;
using Bookly.Application.Features.Commands.Product.UpdateProduct;
using Bookly.Application.Features.Queries.Product.GetAll;
using Bookly.Application.Features.Queries.Product.GetById;
using Bookly.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.Presentation.Controllers;

//● AuthenticationSchemes = "Bearer" — bu isteği hangi authentication scheme'in doğrulayacağını belirtir. Projende sadece bir
//  scheme var(JWT Bearer), bu yüzden yazmasan da aynı şeyi yapıyor.Birden fazla scheme olsaydı(örneğin hem Cookie hem JWT), o
//   zaman anlamlı olurdu.Şu an yazman zorunlu değil.

//  Roles = "Admin" — token doğrulandıktan sonra kullanıcının bu role sahip olup olmadığını kontrol eder.Yoksa 403 Forbidden
//  döner.

//  ---
//  İkisi farklı aşamayı kontrol eder:

//  ┌───────────────────────┬────────────────┬──────────────────┐
//  │       Attribute       │    Ne yapar    │ Başarısız olursa │
//  ├───────────────────────┼────────────────┼──────────────────┤
//  │ AuthenticationSchemes │ Kim doğrulasın │ 401 Unauthorized │
//  ├───────────────────────┼────────────────┼──────────────────┤
//  │ Roles                 │ Rolü var mı    │ 403 Forbidden    │
//  └───────────────────────┴────────────────┴──────────────────┘

//  ---
//  Kısaca: AuthenticationSchemes "sen kimsin" sorusunu, Roles "bu işi yapma yetkin var mı" sorusunu cevaplar.

/*
 Token decode edilince içindeki claim'lere bakar. Daha önce JwtBearerOptionsSetup'a şunu eklemiştik:

  options.TokenValidationParameters.RoleClaimType = ClaimTypes.Role;

  ClaimTypes.Role açılımı: http://schemas.microsoft.com/ws/2008/06/identity/claims/role

  Token'ın payload'ına baktığında bu key altındaki değer "Admin" ise Roles = "Admin" kontrolü geçer.

  Yani akış şöyle:

  İstek gelir
      ↓
  Bearer token decode edilir
      ↓
  TokenValidationParameters ile imza, issuer, audience, expiry kontrol edilir
      ↓
  RoleClaimType'a bakılır → "http://schemas.microsoft.com/.../role" : "Admin"
      ↓
  [Authorize(Roles = "Admin")] → eşleşiyor → 200
                               → eşleşmiyor → 403
 */
[Authorize(AuthenticationSchemes = "Bearer")]
public class ProductsController : ApiController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }
    [Authorize(Roles = "Admin")]

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
    {
       CreateProductCommandResponse response=await  _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllProducts()
    {
        GetAllProductsQueryRequest request = new GetAllProductsQueryRequest();
        List<GetAllProductsQueryResponse> response =  await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetProductById(Guid id,CancellationToken ct)
    {
        if (string.IsNullOrEmpty(id.ToString())) throw new Exception("Ürün Bulunamadı.");
        var request = new GetProductByIdQueryRequest(id);
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request,CancellationToken cancellationToken)
    {
        UpdateProductCommandResponse response =  await _mediator.Send(request,cancellationToken);
        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("DeleteProductById/{id}")]
    public async Task<IActionResult> DeleteProductById(Guid id, CancellationToken cancellationToken)
    {
        var request= new DeleteProductByIdCommandRequest(id);
        DeleteProductByIdCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


}
