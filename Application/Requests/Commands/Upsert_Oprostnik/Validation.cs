using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_Oprostnik
{
    public partial class OprostnikUpsert
    {
        public class Validation :AbstractValidator<Command>
        {
            public Validation() { }
        }
    }
}
