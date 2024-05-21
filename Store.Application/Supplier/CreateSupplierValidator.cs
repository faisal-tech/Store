using FluentValidation;
using Store.Application.Contract.Product.Dtos;
using Store.Application.Contract.Supplier.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Product
{
	public class CreateSupplierValidator : AbstractValidator<CreateSupplierDto>
	{
		public CreateSupplierValidator()
		{
			RuleFor(x => x.Name).NotNull().NotEmpty()
				.WithMessage("Name of the Supplier is required");

		}
	}
}
