using System;
using System.Collections.Generic;

namespace MovieAppMenu
{
    class Program
    {
        static int id = 1;
        static List<Movie> movies = new List<Movie>();
        static void Main(string[] args)
        {
            var mov1 = new Movie()
            {
                Id = id++,
                Title = "Avatar",
                Year = 2007,
                Genre = "Drama",
                Country = "USA"
            };

            movies.Add(mov1);

            movies.Add(new Movie
            {
                Id = id++,
                Title = "Deadpool",
                Year = 2010,
                Genre = "Comedy",
                Country = "USA"
            }) ;

            Console.WriteLine($"{mov1.Title} {mov1.Year} {mov1.Genre} {mov1.Country}");


            string[] menuItems = {
                "List All Movies",
                "Add Movie",
                "Delete Movie",
                "Edit Movie",
                "Exit" };

            var selection = ShowMenu(menuItems);

            while(selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListMovies();
                        break;
                    case 2:
                        AddMovie();
                        break;
                    case 3:
                        DeleteMovie();
                        break;
                    case 4:
                        EditMovie();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye Bye");
            Console.ReadLine();
        }

        private static void EditMovie()
        {
            var movieFound = FindMovieById();

            Console.WriteLine("Title: ");
            movieFound.Title = Console.ReadLine();

            Console.WriteLine("Genre: ");
            movieFound.Genre = Console.ReadLine();

            Console.WriteLine("Country: ");
            movieFound.Country = Console.ReadLine();

            Console.WriteLine("Year: ");
            movieFound.Year = int.Parse(Console.ReadLine());
        }

        private static Movie FindMovieById()
        {
            Console.WriteLine("Insert customer Id: ");
            int id;

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            foreach (var movie in movies)
            {
                if (movie.Id == id)
                {
                    return movie;
                }
            }
            return null;
        }

        private static void DeleteMovie()
        {
            var movieFound = FindMovieById();

            if(movieFound != null)
            {
                movies.Remove(movieFound);
            }
        }

        private static void AddMovie()
        {
            Console.WriteLine("Movie Title: ");
            var title = Console.ReadLine();

            Console.WriteLine("Movie Genre: ");
            var genre = Console.ReadLine();

            Console.WriteLine("Movie Country: ");
            var country = Console.ReadLine();

            Console.WriteLine("Movie Year: ");
            int year = int.Parse(Console.ReadLine());

            movies.Add(new Movie
            {
                Id = id++,
                Title = title,
                Genre = genre,
                Country = country,
                Year = year
            }) ;
                
        }

        private static void ListMovies()
        {
            foreach (var movie in movies)
            {
                Console.WriteLine("\nAll Movies:");
                Console.WriteLine($"ID: {movie.Id}, Title: {movie.Title}, Genre: {movie.Genre}, Country: {movie.Country}, Year: {movie.Year}");
            }
        }

        private static int ShowMenu(string[] menuItems)
        {
            //Console.Clear();
            Console.WriteLine("\nSelect What Do You Want: ");

            Console.WriteLine("");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while(!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 5)
            {
                Console.WriteLine("Choose correct number, from 1-5");
            }
            Console.WriteLine("Selection: " + selection);
            return selection;   
        }

    }
    }

