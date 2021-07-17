using System;
using System.Collections.Generic;
using TemplateAppGenerator.Core.GenerateActions;

namespace TemplateAppGenerator.Core
{
    public interface IGenerateActionStore
    {
        public T QueryContent<T>() where T : class, IGenerateAction, new();
    }
    internal class GenerateActionStore : IGenerateActionStore
    {
        public T QueryContent<T>() where T : class, IGenerateAction, new()
        {
            if (this.actions.TryGetValue(typeof(T), out var template))
            {
                return this.actions[typeof(T)] as T;
            }
            else
            {
                var instance = new T();
                this.actions[typeof(T)] = instance;
                instance.Setup();
                return instance;
            }
        }
        private Dictionary<Type, IGenerateAction> actions = new Dictionary<Type, IGenerateAction>();
    }
}
