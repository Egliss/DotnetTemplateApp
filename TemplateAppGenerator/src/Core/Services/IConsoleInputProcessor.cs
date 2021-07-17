using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateAppGenerator.Core.Services
{
    public interface IConsoleInputProcessor
    {
        public T WaitInput<T>(InputRequest<T> request);
        public bool WaitYesNoSelect(SelectYesNoInputRequest request);
        public T WaitSelectInput<T>(SelectInputRequest<T> request);
        public IEnumerable<T> WaitMultiSelectInput<T>(SelectMultiInputRequest<T> request);
    }

}
