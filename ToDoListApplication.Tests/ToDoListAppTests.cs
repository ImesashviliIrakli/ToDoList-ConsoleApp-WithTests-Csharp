using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ToDoListApplication.Domain;
using ToDoListApplication.Domain.Repo;

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace ToDoListApplication.Tests
{
    [TestFixture]
    public class ToDoListAppTests
    {
        // Add a new task
        // Should return true and add new task
        [TestCase("TestTItle1", "TestDescription1", ExpectedResult = true)]
        [TestCase("TestTItle2", "TestDescription2", ExpectedResult = true)]
        [TestCase("TestTItle3", "TestDescription3", ExpectedResult = true)]
        [Order(0)]

        public bool AddTodoTestsSuccess(string title, string description)
        {
            ToDoListRepo repo = new ToDoListRepo();

            Todo body = new Todo
            {
                Title = title,
                Description = description,
                DueDate = DateTime.Now.AddDays(7),
            };

            var res = repo.AddTodo(body);
            return res;
        }

        // Add a new task error check
        // Should return false and not update
        [TestCase("", "", ExpectedResult = false)]
        [TestCase(null, null, ExpectedResult = false)]
        public bool AddToDoTestNoSuccess(string title, string description)
        {
            ToDoListRepo repo = new ToDoListRepo();

            Todo body = new Todo
            {
                Title = title,
                Description = description,
            };

            var res = repo.AddTodo(body);
            return res;
        }

        // Update a task
        // Should return true and update
        [TestCase("TestTItle1", "TestTItle1updated", "TestDescription1updated", ExpectedResult = true)]
        [TestCase("TestTItle2", "TestTItle2updated", "TestDescription2updated", ExpectedResult = true)]
        [TestCase("TestTItle3", "TestTItle3updated", "TestDescription3updated", ExpectedResult = true)]
        [Order(1)]
        public bool UpdateTodoTestsSuccess(string oldTitle, string newTitle, string newDescription)
        {
            ToDoListRepo repo = new ToDoListRepo();

            Todo body = new Todo
            {
                Id = repo.GetToDoByTitle(oldTitle),
                Title = newTitle,
                Description = newDescription,
                DueDate = DateTime.Now.AddDays(7),
            };

            var res = repo.UpdateTodo(body);
            return res;
        }

        // Update a task error check
        // Should return false and not update
        [TestCase("", "TestTItle1updated", "TestDescription1updated", ExpectedResult = false)]
        [TestCase(null, "TestTItle2updated", "TestDescription2updated", ExpectedResult = false)]
        [TestCase("NONExsitintTitle", "TestTItle3updated", "TestDescription3updated", ExpectedResult = false)]
        public bool UpdateTodoTestsNoSuccess(string oldTitle, string newTitle, string newDescription)
        {
            ToDoListRepo repo = new ToDoListRepo();

            Todo body = new Todo
            {
                Id = repo.GetToDoByTitle(oldTitle),
                Title = newTitle,
                Description = newDescription,
            };

            var res = repo.UpdateTodo(body);

            return res;
        }

        // Mark a task as finished
        // Should return true and mark a task as finished
        [TestCase("TestTItle1updated", ExpectedResult = true)]
        [TestCase("TestTItle2updated", ExpectedResult = true)]
        [TestCase("TestTItle3updated", ExpectedResult = true)]
        [Order(3)]
        public bool MarkAsFinishedTestsSuccess(string title)
        {
            ToDoListRepo repo = new ToDoListRepo();

            int id = repo.GetToDoByTitle(title);

            var res = repo.MarkAsFinished(id);

            return res;
        }

        // Mark a task as finished error check
        // Should return false and not mark as finished
        [TestCase("", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        [TestCase("NonExistingTitle", ExpectedResult = false)]
        public bool MarkAsFinishedTestsNoSuccess(string title)
        {
            ToDoListRepo repo = new ToDoListRepo();

            var id = repo.GetToDoByTitle(title);

            var res = repo.MarkAsFinished(id);

            return res;
        }

        // Remove a task
        // Should return true and remove task
        [TestCase("TestTItle1updated", ExpectedResult = true)]
        [TestCase("TestTItle2updated", ExpectedResult = true)]
        [TestCase("TestTItle3updated", ExpectedResult = true)]
        [Order(4)]
        public bool RemoveTodoTestsSuccess(string title)
        {
            ToDoListRepo repo = new ToDoListRepo();

            int id = repo.GetToDoByTitle(title);

            var res = repo.RemoveTodo(id);

            return res;
        }

        [TestCase("", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        [TestCase("NONExistingTask", ExpectedResult = false)]
        public bool RemoveTodoTestsNoSuccess(string title)
        {
            var repo = new ToDoListRepo();

            int id = repo.GetToDoByTitle(title);

            var res = repo.RemoveTodo(id);

            return res;
        }
    }
}
