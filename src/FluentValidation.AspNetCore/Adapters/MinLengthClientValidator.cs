﻿namespace FluentValidation.AspNetCore {
    using Internal;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    using Validators;

    internal class MinLengthClientValidator : AbstractComparisonClientValidator<GreaterThanOrEqualValidator> {

        protected override object MinValue {
            get { return AbstractComparisonValidator.ValueToCompare;  }
        }

        protected override object MaxValue {
            get { return null; }
        }

        public MinLengthClientValidator(PropertyRule rule, IPropertyValidator validator)
            : base(rule, validator) {
        }

	    public override void AddValidation(ClientModelValidationContext context) {
			MergeAttribute(context.Attributes, "data-val", "true");
			MergeAttribute(context.Attributes, "data-val-minlength", GetErrorMessage(context));
			MergeAttribute(context.Attributes, "data-val-minlength-min", MinValue.ToString());
		}
	}
}