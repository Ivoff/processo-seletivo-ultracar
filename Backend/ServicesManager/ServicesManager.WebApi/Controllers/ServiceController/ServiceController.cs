namespace ServicesManager.WebApi.Controllers;

using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ServicesManager.Application.ServiceService;

[ApiController]
[Route("service")]
public class ServiceController : ControllerBase
{
    private readonly IValidator<NewServiceRequest> _newServiceRequestValidator;
    private readonly IValidator<ServiceIdRequest> _serviceIdRequestValidator;
    private readonly IValidator<AddPartRequest> _addPartRequestValidator;
    private readonly IValidator<RemovePartRequest> _removePartRequestValidator;
    private readonly IServiceAppService _serviceAppService;

    public ServiceController(
        IValidator<NewServiceRequest> newServiceRequestValidator, 
        IServiceAppService serviceAppService,
        IValidator<ServiceIdRequest> serviceIdRequestValidator,
        IValidator<AddPartRequest> addPartRequestValidator,
        IValidator<RemovePartRequest> removePartRequestValidator
    )
    {
        _newServiceRequestValidator = newServiceRequestValidator;
        _serviceAppService = serviceAppService;
        _serviceIdRequestValidator = serviceIdRequestValidator;
        _addPartRequestValidator = addPartRequestValidator;
        _removePartRequestValidator = removePartRequestValidator;
    }
    
    [HttpPost("create")]
    public IActionResult CreateService(NewServiceRequest request)
    {
        var result = _newServiceRequestValidator.Validate(request);
        if (result.IsValid == false)
        {
            return BadRequest(result.Errors.ToString());
        }

        try
        {
            _serviceAppService.CreateService(request.CarId, request.CollaboratorId);   
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode((int) HttpStatusCode.InternalServerError);
        }

        return Ok();
    }
    
    [HttpPost("begin")]
    public IActionResult BeginService(ServiceIdRequest idRequest)
    {
        var result = _serviceIdRequestValidator.Validate(idRequest);
        if (result.IsValid == false)
        {
            return BadRequest(result.Errors.ToString());
        }

        try
        {
            _serviceAppService.BeginService(idRequest.ServiceId);   
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode((int) HttpStatusCode.InternalServerError);
        }

        return Ok();
    }
    
    [HttpPost("finish")]
    public IActionResult FinishService(ServiceIdRequest idRequest)
    {
        var result = _serviceIdRequestValidator.Validate(idRequest);
        if (result.IsValid == false)
        {
            return BadRequest(result.Errors.ToString());
        }

        try
        {
            _serviceAppService.FinishService(idRequest.ServiceId);   
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode((int) HttpStatusCode.InternalServerError);
        }

        return Ok();
    }
    
    [HttpPost("addPart")]
    public IActionResult AddPartService(AddPartRequest request)
    {
        var result = _addPartRequestValidator.Validate(request);
        if (result.IsValid == false)
        {
            return BadRequest(result.Errors.ToString());
        }

        try
        {
            _serviceAppService.AddPart(request.serviceId, request.partId, request.Quantity);   
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode((int) HttpStatusCode.InternalServerError);
        }

        return Ok();
    }
    
    [HttpPost("removePart")]
    public IActionResult RemovePartService(RemovePartRequest request)
    {
        var result = _removePartRequestValidator.Validate(request);
        if (result.IsValid == false)
        {
            return BadRequest(result.Errors.ToString());
        }

        try
        {
            _serviceAppService.RemovePart(request.serviceId, request.partId);   
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode((int) HttpStatusCode.InternalServerError);
        }

        return Ok();
    }
}