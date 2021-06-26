using Sharprompt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TemplateAppGenerator.Core
{
    public interface IConsoleInputProcessor
    {
        public T WaitInput<T>(InputRequest<T> request);
        public T WaitSelectInput<T>(SelectInputRequest<T> request);
        public IEnumerable<T> WaitMultiSelectInput<T>(SelectMultiInputRequest<T> request);
    }

    internal class SharomptInputProcessor : IConsoleInputProcessor
    {
        public T WaitInput<T>(InputRequest<T> request)
        {
            var validators = new List<Func<object, ValidationResult>>()
            {
                request.validator
            };

            T data = default (T);
            if (request.usePasswordMode)
            {
                // TODO type 
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
        public IEnumerable<T> WaitMultiSelectInput<T>(SelectMultiInputRequest <T> request)
        {
            var data = Prompt.MultiSelect(request.text, defaultValues: request.defaultValues, items: request.items);

            // TODO validate date
            return data;
        }
    }
}
