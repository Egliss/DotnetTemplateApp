using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TemplateAppGenerator.Core
{
    public sealed record InputRequest<T>
    {
        public string text { get; set; }
        public T defaultValue { get; set; }
        public bool usePasswordMode { get; set; } = false;
        public Func<object, ValidationResult> validator { get; init; } = (param) => ValidationResult.Success;
    }
    public record MultiInputRequest<T> where T : struct, Enum
    {
        public string text { get; set; }
        public IEnumerable<T> defaultValues { get; set; }
        public bool usePasswordMode { get; set; } = false;
    }
}
