using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateAppGenerator.Core
{
    public interface IProjectTemplateContentStore
    {
        public T QueryContent<T>() where T : class, IProjectTemplateContent, new();
    }
    internal class ProjectTemplateContentStore : IProjectTemplateContentStore
    {
        public T QueryContent<T>() where T : class, IProjectTemplateContent, new()
        {
            if (this.contents.TryGetValue(typeof(T), out var template))
            {
                return this.contents[typeof(T)] as T;
            }
            else
            {
                var instance = new T(); ;
                this.contents[typeof(T)] = instance;
                return instance;
            }
        }
        private Dictionary<Type, IProjectTemplateContent> contents = new Dictionary<Type, IProjectTemplateContent>();
    }
}
