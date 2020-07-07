using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Observer.WeakEventPattern
{
    // Подписка на события может увеличить жизнь объекта.
    // Здесь приведен пример того, как при удалении объекта Window его
    // фактическое удаление не происходит.

    // Один из способов контроля - использование прослушивателя слабых событий

    public class Demo
    {
        public static void Test()
        {
            var btn = new Button();
            //var window = new Window(btn);
            var window = new Window2(btn);
            var windowRef = new WeakReference(window);
            btn.Fire();

            Console.WriteLine("-Setting window to null-");
            window = null;

            FireGC();
            Console.WriteLine($"Window alive? {windowRef.IsAlive}");

            btn.Fire();

            Console.WriteLine("-Setting button to null-");
            btn = null;

            FireGC();

            Console.WriteLine($"Window alive? {windowRef.IsAlive}");
        }

        private static void FireGC()
        {
            Console.WriteLine("Starting GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("GC is done!");
        }
    }

    public class Button
    {
        public event EventHandler Clicked;

        public void Fire()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window
    {
        public Window(Button button)
        {
            button.Clicked += ButtonOnClicked;
        }

        private void ButtonOnClicked(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Button clicked (Window handler)");
        }

        ~Window()
        {
            Console.WriteLine("Window finalized");
        }
    }

    public class Window2
    {
        public Window2(Button button)
        {
            // Прослушиватель слабых событий
            WeakEventManager<Button, EventArgs>
              .AddHandler(button, "Clicked", ButtonOnClicked);
        }

        private void ButtonOnClicked(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Button clicked (Window2 handler)");
        }

        ~Window2()
        {
            Console.WriteLine("Window2 finalized");
        }
    }
}
