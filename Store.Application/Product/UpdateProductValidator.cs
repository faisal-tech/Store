using FluentValidation;
using Store.Application.Contract.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Product
{
	internal class UpdateProductValidator : AbstractValidator<UpdateProductDto>
	{
		public UpdateProductValidator()
		{
			RuleFor(x => x.Name).NotNull().NotEmpty()
				.WithMessage("Name of the product is required");

			RuleFor(x => x.UnitPrice).NotNull()
				.WithMessage("Price is required");

			RuleFor(x => x.UnitId).NotNull()
				.WithMessage("Unit is required");

			RuleFor(x => x.SupplierId).NotNull()
				.WithMessage("Supplier is required");

			RuleFor(x => x.OrderUnit).NotNull()
				.WithMessage("Order amount is required");

			RuleFor(x => x.ReorderLimit).NotNull()
				.WithMessage("The limit to reorder is required");

			RuleFor(x => x.UnitsInStock).NotNull()
				.WithMessage("The Stock amount to reorder is required");
		}
	}
}
