using System;
using UnitTestDemoApplication.Models;

namespace UnitTestDemoApplication.Interfaces;

/// <summary>
/// Interface for a service that manages todo items.
/// </summary>
public interface ITodoService
{
    Task<TodoItem> AddAsync(TodoItem item);
    Task<TodoItem?> GetByIdAsync(int id);
}
