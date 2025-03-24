using System;
using Xunit;
using Moq;
using UnitTestDemoApplication.Services;
using UnitTestDemoApplication.Interfaces;
using UnitTestDemoApplication.Models;

namespace UnitTestDemo.Tests;

public class TodoServiceTest
{

    // ONE ISSUE WITH TESTS IN THIS SCENARIO
    // we need to mock the actual database

    private readonly Mock<ITodoRepository> _mockRepo;
    private readonly TodoService _service;
    public TodoServiceTest()
    {
        //this mimics the todo repository - database functionality ()
        _mockRepo = new Mock<ITodoRepository>();
        //using the mock repository in our services file that we are test
        _service = new TodoService(_mockRepo.Object);
    }

    // GETTING ITEM
    // TODO: Test GET the correct todo item
    // TODO: Test input incorrect - item wasn't found (return null)

    // ADDING ITEM
    // TODO: Add an item, that it actually got added successfully
    [Fact]
    public async Task AddTodoAsync_AddsItem()
    {
        // Arrange
        // setting up our new todo item that we want to add
        TodoItem newItem = new() { Title = "Test Adding", IsCompleted = false };
        // setting up our mock repo to return the new item
        _mockRepo.Setup(x => x.AddAsync(It.IsAny<TodoItem>())).ReturnsAsync(newItem);

        // Act
        // call the adding functionality
        var result = await _service.AddTodoAsync("Test Adding");

        // Assert
        // result is equal to our newItem
        Assert.Equal(newItem, result); //making sure the objects match
        Assert.Equal("Test Adding", result.Title); //making sure the title is correct
        Assert.False(result.IsCompleted); //making sure 
        Assert.NotNull(result); //making sure it has id

    }

}
