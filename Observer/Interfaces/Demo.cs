using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;


namespace Observer.Interfaces
{
    // Способ 1
    public class Demo1
    {
        public static void Test()
        {
            var person = new Person();

            // Используется System.Reactive.Linq (NuGet)
            person.OfType<FallsIllEvent>()
              .Subscribe(args => Console.WriteLine($"A doctor has been called to {args.Address}"));

            person.CatchACold();
        }
    }

    // Способ 2. Здесь сам класс - наблюдатель
    public class Demo2 : IObserver<Event>
    {
        public static void Test()
        {
            new Demo2();
        }

        public Demo2()
        {
            var person = new Person();
            var sub = person.Subscribe(this);

            person.CatchACold();
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(Event value)
        {
            if (value is FallsIllEvent args)
                Console.WriteLine($"A doctor has been called to {args.Address}");
        }
    }


    public class Event
    {
        // something that can happen
    }

    public class FallsIllEvent : Event
    {
        public string Address;
    }

    public class Person : IObservable<Event>
    {
        private readonly HashSet<Subscription> subscriptions
            = new HashSet<Subscription>();

        public void CatchACold()
        {
            foreach (var sub in subscriptions)
                sub.Observer.OnNext(new FallsIllEvent { Address = "123 London Road" });
        }

        #region IObservable

        public IDisposable Subscribe(IObserver<Event> observer)
        {
            var subscription = new Subscription(this, observer);
            subscriptions.Add(subscription);
            return subscription;
        }

        #endregion

        public class Subscription : IDisposable
        {
            private Person person;
            public IObserver<Event> Observer;

            public Subscription(Person person, IObserver<Event> observer)
            {
                this.person = person;
                Observer = observer;
            }

            public void Dispose()
            {
                person.subscriptions.Remove(this);
            }
        }
    }

    
}
