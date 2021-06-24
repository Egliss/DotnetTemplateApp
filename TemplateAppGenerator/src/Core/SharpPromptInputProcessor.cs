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
        public IEnumerable<T> WaitMultiInput<T>(MultiInputRequest<T> request) where T : struct, Enum;
    }

    internal class SharpPromptInputProcessor : IConsoleInputProcessor
    {
        public T WaitInput<T>(InputRequest<T> request)
        {
            var validators = new List<Func<object, ValidationResult>>()
            {
                request.validator
            };
            var data = Prompt.Input<T>(request.text, request.defaultValue, validators);
            return data;
        }

        public IEnumerable<T> WaitMultiInput<T>(MultiInputRequest<T> request) where T : struct, Enum
        {
            var data = Prompt.MultiSelect<T>(request.text, defaultValues: request.defaultValues);
            return data;
        }
    }
}
