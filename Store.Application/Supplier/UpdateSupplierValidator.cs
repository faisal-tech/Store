using FluentValidation;
using Store.Application.Contract.Supplier.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Supplier
{
	public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierDto>
	{
		public UpdateSupplierValidator()
		{
			RuleFor(x => x.Id).NotNull().NotEmpty().NotEqual(0)
				.WithMessage("The Id of the Supplier is required");


			RuleFor(x => x.Name).NotNull().NotEmpty()
				.WithMessage("Name of the Supplier is required");

		}
	}
}
