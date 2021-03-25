using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediator.ChatRoom
{
    public class Demo
    {
        public static void Test()
        {
            var room = new ChatRoom();

            var john = new Person("John");
            var jane = new Person("Jane");

            room.Join(john);
            room.Join(jane);

            john.Say("hi room");
            jane.Say("oh, hey john");

            var simon = new Person("Simon");
            room.Join(simon);
            simon.Say("hi everyone!");

            jane.PrivateMessage("Simon", "glad you could join us!");
        }
    }

    #region Person 

    public class Person
    {
        public string Name;
        public ChatRoom Room;  // ссылка на медиатор
        private List<string> chatLog = new List<string>();

        public Person(string name) => Name = name;

        // получаемое сообщение
        public void Receive(string sender, string message)
        {
            string s = $"{sender}: '{message}'";
            Console.WriteLine($"[{Name}'s chat session] {s}");
            chatLog.Add(s);
        }

        // публичное сообщение
        public void Say(string message) => Room.Broadcast(Name, message);

        // приватное сообщение
        public void PrivateMessage(string who, string message)
        {
            Room.Message(Name, who, message);
        }
    }

    #endregion


    #region ChatRoom - mediator

    public class ChatRoom
    {
        private List<Person> people = new List<Person>();

        public void Broadcast(string source, string message)
        {
            foreach (var p in people)
                if (p.Name != source)
                    p.Receive(source, message);
        }

        public void Join(Person p)
        {
            string joinMsg = $"{p.Name} joins the chat";
            Broadcast("room", joinMsg);

            p.Room = this;
            people.Add(p);
        }

        public void Message(string source, string destination, string message)
        {
            people.FirstOrDefault(p => p.Name == destination)?.Receive(source, message);
        }
    }

    #endregion
}
