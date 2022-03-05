using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoListApplication.Domain.Repo
{
    public class ToDoListRepo
    {
        // <summary>
        // Gets every unfinished task
        // <summary>
        public List<Todo> GetAllTodos()
        {
            using ToDoListDatabaseContext db = new ToDoListDatabaseContext();

            var todoList = db.Todos.Where(x => !x.Status).ToList();

            return todoList;

        }

        // <summary>
        // Gets every finished task
        // <summary>
        public List<Todo> GetAllFinishedTodos()
        {
            using ToDoListDatabaseContext db = new ToDoListDatabaseContext();

            var todoList = db.Todos.Where(x => x.Status).ToList();

            return todoList;
        }

        // <summary>
        // Gets a task with the id
        // <summary>
        public Todo GetTodoById(int id)
        {
            using ToDoListDatabaseContext db = new ToDoListDatabaseContext();

            Todo todo = db.Todos.Where(x => x.Id == id).FirstOrDefault();

            return todo;
        }

        // <summary>
        // Gets a task with the title
        // <summary>
        public int GetToDoByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return 0;
            }

            using ToDoListDatabaseContext db = new ToDoListDatabaseContext();

            var todo = db.Todos.Where(x => x.Title == title).FirstOrDefault();

            if (todo == null)
            {
                return 0;
            }

            return todo.Id;
        }

        // <summary>
        // Adds a task
        // it won't add if the title is empty
        // <summary>
        public bool AddTodo(Todo body)
        {
            if (string.IsNullOrEmpty(body.Title))
            {
                return false;
            }
            using ToDoListDatabaseContext db = new ToDoListDatabaseContext();

            try
            {
                db.Todos.Add(body);

                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        // <summary>
        // Marks a task as finished
        // get the task with the given id
        // Then updates the status
        // <summary>
        public bool MarkAsFinished(int id)
        {
            using ToDoListDatabaseContext db = new ToDoListDatabaseContext();

            try
            {
                Todo todo = db.Todos.Where(x => x.Id == id).FirstOrDefault();

                if (todo != null)
                {
                    todo.Status = true;

                    db.Todos.Update(todo);

                    db.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        // <summary>
        // Updates a task
        // update with the given object
        // <summary>
        public bool UpdateTodo(Todo body)
        {
            if (string.IsNullOrEmpty(body.Title))
            {
                return false;
            }
            using ToDoListDatabaseContext db = new ToDoListDatabaseContext();

            try
            {
                Todo todo = db.Todos.Where(x => x.Id == body.Id).FirstOrDefault();

                if (todo != null)
                {
                    todo.Title = body.Title;
                    todo.Description = body.Description;
                    todo.DueDate = body.DueDate;

                    db.Todos.Update(todo);

                    db.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // <summary>
        // Removes a task with the given id
        // If task doesn't exist, it will return false
        // Else it will delete and return true
        // <summary>
        public bool RemoveTodo(int id)
        {
            using ToDoListDatabaseContext db = new ToDoListDatabaseContext();

            try
            {
                Todo todo = db.Todos.Where(x => x.Id == id).FirstOrDefault();

                if (todo != null)
                {
                    db.Todos.Remove(todo);

                    db.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
