using Sharprompt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TemplateAppGenerator.Core.Services;

namespace TemplateAppGenerator.Core.Cli
{
    internal class SharomptInputProcessor : IConsoleInputProcessor
    {
        public T WaitInput<T>(InputRequest<T> request)
        {
            var validators = new List<Func<object, ValidationResult>>()
            {
                request.validator
            };

            T data = default(T);
            if (request.usePasswordMode)
            {
                throw new NotImplementedException("password mode is not implemented");
            }
            else
            {
                data = Prompt.Input<T>(request.text, request.defaultValue, validators);
            }
            return data;
        }
        public T WaitSelectInput<T>(SelectInputRequest<T> request)
        {
            var data = Prompt.Select(request.text, defaultValue: request.defaultValue, items: request.items);

            // TODO validate
            return data;
        }
        public IEnumerable<T> WaitMultiSelectInput<T>(SelectMultiInputRequest<T> request)
        {
            var data = Prompt.MultiSelect(request.text, defaultValues: request.defaultValues, items: request.items);

            // TODO validate date
            return data;
        }

        public bool WaitYesNoSelect(SelectYesNoInputRequest request)
        {
            var data = Prompt.Select(request.text, defaultValue: request.defaultValue, items: new bool[] { true, false });
            return data;
        }
    }
}
