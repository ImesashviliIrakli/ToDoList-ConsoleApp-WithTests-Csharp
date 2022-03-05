using System;
using System.Linq;
using System.Text;
using ToDoListApplication.Domain;
using ToDoListApplication.Domain.Repo;
using AutoMapper;
using System.Collections.Generic;

namespace ToDoListApplication
{
    public class Program
    {
        #region GetAllTodos
        // <summary>
        // Gets every unfinished task in the database and displays it to the console
        // <summary>
        public void GetAllTodos()
        {
            Console.Clear();

            ToDoListRepo repo = new ToDoListRepo();

            var todoList = repo.GetAllTodos();

            if(todoList == null)
            {
                Console.WriteLine("You have no tasks\n");
            }
            else
            {
                foreach (Todo t in todoList)
                {
                    Console.WriteLine("=============================");
                    Console.WriteLine($"Title: {t.Title}");
                    Console.WriteLine($"Description: {t.Description}");
                    Console.WriteLine($"DueDate: {t.DueDate}");
                    Console.WriteLine("");
                }

            }

            Console.WriteLine("1) Mark a todo as finished");
            Console.WriteLine("2) Update an existing todo");
            Console.WriteLine("3) Add a new todo");
            Console.WriteLine("4) Remove a todo");
            Console.WriteLine("5) Exit");

            Console.WriteLine("\nInsert the number based on what you need");

            Program p = new Program();
            int task = int.Parse(Console.ReadLine());

            switch (task)
            {
                case 1:
                    p.MarkAsFinished();
                    break;
                case 2:
                    p.UpdateTodo();
                    break;
                case 3:
                    p.AddTodo();
                    break;
                case 4:
                    p.RemoveTodo();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion

        #region AddTodo
        // <summary>
        // Adds a new task to the database
        // Takes 3 parameters, Title, Description, Duedate.
        // Title must not be empty nor null, the rest can.
        // <summary>
        public void AddTodo()
        {
            Console.Clear();

            Console.WriteLine("Insert the following");

            Console.Write("TiTle: ");
            string title = Console.ReadLine();

            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Title must not be empty");
            }
            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Due date (mm/dd/yyy): ");
            string dueDate = Console.ReadLine();

            Todo res = new Todo
            {
                Title = title,
                Description = description,
                DueDate = DateTime.Parse(dueDate)
            };

            ToDoListRepo repo = new ToDoListRepo();

            var todoList = repo.AddTodo(res);

            if (!todoList)
            {
                Console.WriteLine("\nSomething went wrong, try again\n");
                return;
            }

            Console.WriteLine("\nAdded successfully\n");

            Console.WriteLine("1) View all todos");
            Console.WriteLine("2) Mark a todo as finished");
            Console.WriteLine("3) Update an existing todo");
            Console.WriteLine("4) Add a new todo");
            Console.WriteLine("5) Remove a todo");
            Console.WriteLine("6) Exit");

            Console.WriteLine("\nInsert the number based on what you need");

            int task = int.Parse(Console.ReadLine());
            Program p = new Program();

            switch (task)
            {
                case 1:
                    p.GetAllTodos();
                    break;
                case 2:
                    p.MarkAsFinished();
                    break;
                case 3:
                    p.UpdateTodo();
                    break;
                case 4:
                    p.AddTodo();
                    break;
                case 5:
                    p.RemoveTodo();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion

        #region MarkAsFinished
        // <summary>
        // Marks a task as finished.
        // When the status property of the to do class is set to true it means that the task is finished.
        // <summary>
        public void MarkAsFinished()
        {
            Console.Clear();
            ToDoListRepo repo = new ToDoListRepo();

            var todoList = repo.GetAllTodos();

            foreach (Todo t in todoList)
            {
                Console.WriteLine("=============================");
                Console.WriteLine($"Id: {t.Id}");
                Console.WriteLine($"Title: {t.Title}");
                Console.WriteLine($"Description: {t.Description}");
                Console.WriteLine($"DueDate: {t.DueDate}");
                Console.WriteLine("");
            }

            Console.WriteLine("Insert in the id to mark as finished");

            Console.Write("Task Id: ");
            int id = int.Parse(Console.ReadLine());

            var mark = repo.MarkAsFinished(id);

            if (!mark)
            {
                Console.WriteLine("\nSomething went wrong, try again\n");
                return;
            }

            Console.WriteLine("\nSuccessfully marked as finished\n");

            Console.WriteLine("1) View all todos");
            Console.WriteLine("2) Mark a todo as finished");
            Console.WriteLine("3) Update an existing todo");
            Console.WriteLine("4) Add a new todo");
            Console.WriteLine("5) Remove a todo");
            Console.WriteLine("6) Exit");

            Console.WriteLine("\nInsert the number based on what you need");

            Program p = new Program();

            int task = int.Parse(Console.ReadLine());

            switch (task)
            {
                case 1:
                    p.GetAllTodos();
                    break;
                case 2:
                    p.MarkAsFinished();
                    break;
                case 3:
                    p.UpdateTodo();
                    break;
                case 4:
                    p.AddTodo();
                    break;
                case 5:
                    p.RemoveTodo();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion

        #region UpdateTodo
        // <summary>
        // Updates a certain task
        // It takes the task id and uses it to update the task if it exists in the database
        // then you have to enter 3 propertis, Title, Description, Duedate
        // if you want to change the description alone, leave the rest empty and insert only the description
        // the program will know not to change your task
        // <summary>
        public void UpdateTodo()
        {
            Console.Clear();
            ToDoListRepo repo = new ToDoListRepo();

            var todoList = repo.GetAllTodos();

            foreach (Todo t in todoList)
            {
                Console.WriteLine("=============================");
                Console.WriteLine($"Id: {t.Id}");
                Console.WriteLine($"Title: {t.Title}");
                Console.WriteLine($"Description: {t.Description}");
                Console.WriteLine($"DueDate: {t.DueDate}");
                Console.WriteLine("");
            }

            Console.WriteLine("Insert in the id to mark as finished");

            Console.Write("Task Id: ");
            int id = int.Parse(Console.ReadLine());

            var todo = repo.GetTodoById(id);

            Console.Clear();

            Console.WriteLine("=============================");
            Console.WriteLine($"Id: {todo.Id}");
            Console.WriteLine($"Title: {todo.Title}");
            Console.WriteLine($"Description: {todo.Description}");
            Console.WriteLine($"DueDate: {todo.DueDate}");
            Console.WriteLine("");

            Console.WriteLine("Insert the following");
            Console.WriteLine("Note: If you leave the input fields empty, the old values won't be changed");

            Console.Write("TiTle: ");
            string title = Console.ReadLine();
            if (string.IsNullOrEmpty(title))
            {
                title = todo.Title;
            }

            Console.Write("Description: ");
            string description = Console.ReadLine();
            if (string.IsNullOrEmpty(description))
            {
                description = todo.Description;
            }

            Console.Write("Due date (mm/dd/yyy): ");
            string dueDate = Console.ReadLine();
            if (string.IsNullOrEmpty(dueDate))
            {
                dueDate = todo.DueDate.ToString();
            }

            Todo body = new Todo {
                Id = id,
                Title = title,
                Description = description,
                DueDate = DateTime.Parse(dueDate)
            };

            var updateTodo = repo.UpdateTodo(body);

            if (!updateTodo)
            {
                Console.WriteLine("\nSomething went wrong, try again\n");
                return;
            }

            Console.WriteLine("\nUpdated successfully\n");


            Console.WriteLine("1) View all todos");
            Console.WriteLine("2) Mark a todo as finished");
            Console.WriteLine("3) Update an existing todo");
            Console.WriteLine("4) Add a new todo");
            Console.WriteLine("5) Remove a todo");
            Console.WriteLine("6) Exit");

            Console.WriteLine("\nInsert the number based on what you need");

            Program p = new Program();

            int task = int.Parse(Console.ReadLine());

            switch (task)
            {
                case 1:
                    p.GetAllTodos();
                    break;
                case 2:
                    p.MarkAsFinished();
                    break;
                case 3:
                    p.UpdateTodo();
                    break;
                case 4:
                    p.AddTodo();
                    break;
                case 5:
                    p.RemoveTodo();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion

        #region RemoveTodo
        // <summary>
        // Deletes a task from the database
        // Takes the id from console and then deletes the task if it exists in the database
        // <summary>
        public void RemoveTodo()
        {
            Console.Clear();
            ToDoListRepo repo = new ToDoListRepo();

            var todoList = repo.GetAllTodos();

            foreach (Todo t in todoList)
            {
                Console.WriteLine("=============================");
                Console.WriteLine($"Id: {t.Id}");
                Console.WriteLine($"Title: {t.Title}");
                Console.WriteLine($"Description: {t.Description}");
                Console.WriteLine($"DueDate: {t.DueDate}");
                Console.WriteLine("");
            }

            Console.WriteLine("Insert in the id to remove the task");

            Console.Write("Task Id: ");
            int id = int.Parse(Console.ReadLine());

            var remove = repo.RemoveTodo(id);

            if (!remove)
            {
                Console.WriteLine("\nCould not remove something went wrong\n");
                return;
            }

            Console.WriteLine("\nSuccessfully removed\n");

            Console.WriteLine("1) View all todos");
            Console.WriteLine("2) Mark a todo as finished");
            Console.WriteLine("3) Update an existing todo");
            Console.WriteLine("4) Add a new todo");
            Console.WriteLine("5) Remove a todo");
            Console.WriteLine("6) Exit");

            Console.WriteLine("\nInsert the number based on what you need");

            Program p = new Program();

            int task = int.Parse(Console.ReadLine());

            switch (task)
            {
                case 1:
                    p.GetAllTodos();
                    break;
                case 2:
                    p.MarkAsFinished();
                    break;
                case 3:
                    p.UpdateTodo();
                    break;
                case 4:
                    p.AddTodo();
                    break;
                case 5:
                    p.RemoveTodo();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion

        static void Main()
        {
            Program p = new Program();

            Console.WriteLine("Welcome to Todo App");
            Console.WriteLine("Choose one of the following options\n");

            Console.WriteLine("1) View all todos");
            Console.WriteLine("2) Mark a todo as finished");
            Console.WriteLine("3) Update an existing todo");
            Console.WriteLine("4) Add a new todo");
            Console.WriteLine("5) Remove a todo");
            Console.WriteLine("6) Exit");

            Console.WriteLine("\nInsert the number based on what you need");

            int task = int.Parse(Console.ReadLine());

            switch (task) 
            {
                case 1:
                    p.GetAllTodos();
                    break;
                case 2:
                    p.MarkAsFinished();
                    break;
                case 3:
                    p.UpdateTodo();
                    break;
                case 4:
                    p.AddTodo();
                    break;
                case 5:
                    p.RemoveTodo();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }


        }

    }
}
