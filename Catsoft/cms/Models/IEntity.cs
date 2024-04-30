using System;

namespace App.cms.Models
{
    public interface IEntity
    {
        Guid Id { get; }

        string Title { get; }

        DateTime DateCreated { get; }
        
        int Position { get; }

        string GetValueFromNameProperty(string nameProperty);

        string GetLinkFromNameProperty(string nameProperty);

        string GetTitleFromNameProperty(string nameProperty);
    }
}