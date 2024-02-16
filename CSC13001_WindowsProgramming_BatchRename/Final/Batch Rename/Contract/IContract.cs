using System;
using System.Collections.Generic;

namespace Contract
{
    public interface IContract
    {
        // Get input like prefix, suffix, ...
        Dictionary<string, Object> Input { get; set; }

        // Rule's name
        string Name { get; }

        // Rule's description
        string Description { get; }

        // Folder or file
        string Type { get; }

        // Perform renaming
        string Rename(string original);

        // Reset attributes of rule
        void Reset();

        // Show Window
        bool Show();
    }
}
