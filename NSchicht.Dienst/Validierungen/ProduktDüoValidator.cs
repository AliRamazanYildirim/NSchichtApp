using FluentValidation;
using NSchicht.Kern.DÜOe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Dienst.Validierungen
{
    public class ProduktDüoValidator:AbstractValidator<ProduktDüo>
    {
        public ProduktDüoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName}({ID}) is required").NotEmpty().WithMessage("{PropertyName} ist erforderlich");
            RuleFor(x => x.Preis).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} muss größer als 0 sein");
            RuleFor(x => x.Vorrat).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} muss größer als 0 sein");

        }
    }
}
