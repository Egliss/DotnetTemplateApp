using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TemplateAppGenerator.Core
{
    public sealed record InputRequest<T>
    {
        public string text { get; set; }
        public T defaultValue { get; set; }
        public bool usePasswordMode { get; set; } = false;
        public Func<object, ValidationResult> validator { get; init; } = (param) => ValidationResult.Success;
    }

    public sealed record SelectInputRequest<T>
    {
        public string text { get; set; }
        public T defaultValue { get; set; }
        public IEnumerable<T> items { get; set; }
        public Func<object, ValidationResult> validator { get; init; } = (param) => ValidationResult.Success;
    }

    public sealed record SelectMultiInputRequest<T>
    {
        public string text { get; set; }
        public IEnumerable<T> defaultValues { get; set; }
        public IEnumerable<T> items { get; set; }
        public Func<object, ValidationResult> validator { get; init; } = (param) => ValidationResult.Success;
    }
}
