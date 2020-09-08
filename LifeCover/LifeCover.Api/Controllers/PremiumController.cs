using System;
using System.Linq;
using FluentValidation;
using LifeCover.Api.Models;
using LifeCover.Services;
using Microsoft.AspNetCore.Mvc;

namespace LifeCover.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private readonly IPremiumCalculationService service;
        private readonly IValidator<LifePremiumModel> validator;

        public PremiumController(IPremiumCalculationService service, IValidator<LifePremiumModel> validator)
        {
            this.service = service;
            this.validator = validator;
        }

        [HttpPost]
        public ActionResult<decimal> CalculatePremium(LifePremiumModel model) // Can be made async when service is async
        {
            var validationResult = validator.Validate(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            var premium = 
                service.CalculatePremium(model.SumInsured, Enum.Parse<Occupation>(model.Occupation), model.Age.GetValueOrDefault());

            return Ok(premium); 
        }
    }
}