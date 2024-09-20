using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoListApp
{
    class Program
    {
        static List<string> tasks = new List<string>();
        const string fileName = "tasks.txt";
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the To-Do List App!");
            
            LoadTaskFromFile();
            
            bool continueApp = true;
            
            while(continueApp)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. View Tasks");
                Console.WriteLine("2. Add Task");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Save & Exit");

                Console.Write("Enter your choice (1-4): ");
                string choice = Console.ReadLine();
                
                switch(choice)
                {
                    case "1":
                        ViewTask();
                        break;
                    case "2":
                        AddTask();
                        break;
                    case "3":
                        RemoveTask();
                        break;
                    case "4":
                        SaveTaskToFile();
                        continueApp = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            Console.WriteLine("Goodbye! Your tasks have been saved.");
        }
        
        static void ViewTask()
        {
            if(tasks.Count == 0)
            {
                Console.WriteLine("Your task list is empty.");
            }
            else
            {
                Console.WriteLine("\nHere are your tasks: ");
                for(int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
        }
        
        static void AddTask()
        {
            Console.Write("Enter the task you want to add: ");
            string newTask = Console.ReadLine();
            
            if(!string.IsNullOrWhiteSpace(newTask))
            {
                tasks.Add(newTask);
                Console.WriteLine($"Task '{newTask}' added successfully.");
            }
            else
            {
                Console.WriteLine("Task cannot be empty.");
            }
        }
        
        static void RemoveTask()
        {
            if(tasks.Count == 0)
            {
                Console.WriteLine("There are no tasks to remove.");
                return;
            }
            
            ViewTask();
            
            Console.Write("Enter the task number to remove: ");
            if(int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                string removeTask = tasks[taskNumber - 1];
                tasks.RemoveAt(taskNumber - 1);
                Console.WriteLine($"Task '{removeTask}' reomved successfully.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");    
            }
        }
        
        static void SaveTaskToFile()
        {
            File.WriteAllLines(fileName, tasks);
            Console.WriteLine("Tasks saved to file");
         }  
        static void LoadTaskFromFile()
        {
            if(File.Exists(fileName))
            {
                tasks = new List<string>(File.ReadAllLines(fileName));
                Console.WriteLine("Tasks loaded from file");
            }
        }
    }
}